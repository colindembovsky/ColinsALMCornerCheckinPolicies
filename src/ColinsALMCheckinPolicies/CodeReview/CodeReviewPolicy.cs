using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColinsALMCheckinPolicies
{
	[Serializable]
    public sealed class CodeReviewPolicy : PolicyBase
    {
		public const string ClosedStatus = "Microsoft.VSTS.CodeReview.ClosedStatus";

		[NonSerialized]
		private IPendingCheckin pendingCheckin;

		public CodeReviewPolicyConfig Config { get; set; }

		#region base properties
		public override string Description
		{
			get { return "Ensures that a code review has been performed on this changeset"; }
		}

		public override string Type
		{
			get { return "Code Review Policy"; }
		}

		public override string TypeDescription
		{
			get { return "This policy ensures that a code review has been performed on the changeset"; }
		}

		public override bool CanEdit
		{
			get	{ return true; }
		}
		#endregion

		#region handle change event
		public override void Initialize(IPendingCheckin pendingCheckin)
		{
			base.Initialize(pendingCheckin);

			this.pendingCheckin = pendingCheckin;
			pendingCheckin.WorkItems.CheckedWorkItemsChanged += WorkItems_CheckedWorkItemsChanged;
		}

		void WorkItems_CheckedWorkItemsChanged(object sender, EventArgs e)
		{
			if (!Disposed)
			{
				OnPolicyStateChanged(Evaluate());
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			pendingCheckin.WorkItems.CheckedWorkItemsChanged -= WorkItems_CheckedWorkItemsChanged;
		}
		#endregion

		#region serialization stuff
		public override string GetAssemblyName()
		{
			return CodeReviewPolicySerializationBinding.PolicyAsmName;
		}

		public override BinaryFormatter GetBinaryFormatter()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Binder = new CodeReviewPolicySerializationBinding();
			return formatter;
		} 
		#endregion

		public override bool Edit(IPolicyEditArgs policyEditArgs)
		{
			if (Config == null)
			{
				Config = new CodeReviewPolicyConfig()
				{
					FailIfAnyResponseIsNeedsWork = true,
					RequireReviewToBeClosed = true,
					MinPassLevel = PassLevel.LooksGood
				};
			}

			using (var form = new CodeReviewPolicyForm(Config, policyEditArgs.TeamProject.TeamProjectCollection.GetService<VersionControlServer>()))
			{
				var res = form.ShowDialog(policyEditArgs.Parent);
				if (res == DialogResult.OK)
				{
					Config = form.Config;
					return true;
				}
				return false;
			}
		} 

		public override PolicyFailure[] Evaluate()
		{
			var failures = new List<PolicyFailure>();
			var hasBeenReviewed = true;

			var serverPathsAffected = new List<string>();
			pendingCheckin.PendingChanges.CheckedPendingChanges.ToList().ForEach(i => {
				var p = Path.GetDirectoryName(i.ServerItem);
				if (!serverPathsAffected.Contains(p))
				{
					serverPathsAffected.Add(p);
				}
			});

			// only check the code review if one item is in the paths of the config
			if (Config.Paths.Count == 0 ||
				serverPathsAffected.Any(itemPath =>
				    Config.Paths.Any(configPath =>
                    {
                        // make the path have a trailing slash to distinguish $/Project/DEV from $/Project/DEV-Feature1
                        if (configPath != "$/")
                        {
                            configPath += "\\";
                        }
						var cleanItemPath = itemPath.Replace('/', '\\');
						var cleanConfigPath = configPath.Replace('/', '\\');

						return cleanItemPath.StartsWith(cleanConfigPath) || $"{cleanItemPath}\\".Equals(cleanConfigPath, StringComparison.OrdinalIgnoreCase);
                    })))
			{
				var requests = pendingCheckin.WorkItems.CheckedWorkItems.Where(w =>
				w.WorkItem.Type.Name == "Code Review Request");

				if (requests.Count() == 0)
				{
					hasBeenReviewed = false;
				}
				else
				{
					foreach (var request in requests)
					{
						if (!RequestWasSuccessfullyCompleted(request.WorkItem))
						{
							hasBeenReviewed = false;
							break;
						}
					}
				}

				if (!hasBeenReviewed)
				{
					failures.Add(new PolicyFailure("Please request a code review for this changeset before attempting check-in. The code review may be required to be Closed and have no 'Needs Work' responses to pass, depending the policy configuration.", this));
				}
			}
			
			return failures.ToArray();
		}

		private bool RequestWasSuccessfullyCompleted(WorkItem codeReviewRequest)
		{
			if (Config.RequireReviewToBeClosed)
			{
				if (codeReviewRequest.State != "Closed" || codeReviewRequest.Fields[ClosedStatus].Value.ToString() == "Abandoned")
				{
					return false;
				}
			}
			
			var responses = GetResponsesForRequest(codeReviewRequest);

			if (Config.FailIfAnyResponseIsNeedsWork)
			{
				if (responses.Any(r => r.Fields[ClosedStatus].Value.ToString() == "Needs Work"))
				{
					return false;
				}
			}

			var positiveResponses = responses.Where(r => r.Fields[ClosedStatus].Value.ToString() != "Needs Work" && r.Fields[ClosedStatus].Value.ToString() != "Declined");

            if (Config.MinPassLevel == PassLevel.None)
            {
                return true;
            }
			else if (Config.MinPassLevel == PassLevel.WithComments)
			{
				return positiveResponses.Count() > 0;
			}
			else
			{
				return positiveResponses.Count() > 0 && positiveResponses.All(r => r.Fields[ClosedStatus].Value.ToString() == "Looks Good");
			}
		}

		private List<WorkItem> GetResponsesForRequest(WorkItem codeReviewRequest)
		{
			var ids = new List<int>();
			foreach (WorkItemLink link in codeReviewRequest.WorkItemLinks)
			{
				if (link.LinkTypeEnd.Name == "Child")
				{
					ids.Add(link.TargetId);
				}
			}

			var responses = new List<WorkItem>();
			foreach (var id in ids)
			{
				var response = codeReviewRequest.Project.Store.GetWorkItem(id);
				if (response.Type.Name == "Code Review Response" && response.State == "Closed")
				{
					responses.Add(response);
				}
			}

			return responses;
        }

        public override string InstallationInstructions
        {
            get
            {
                return Constants.InstallationInstructions;
            }
        }
    }
}
