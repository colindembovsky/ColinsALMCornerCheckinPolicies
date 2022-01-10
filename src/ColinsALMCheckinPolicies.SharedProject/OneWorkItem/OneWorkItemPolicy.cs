using Microsoft.TeamFoundation.VersionControl.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColinsALMCheckinPolicies
{
	[Serializable]
	public sealed class OneWorkItemPolicy : PolicyBase
	{
		[NonSerialized]
		private IPendingCheckin pendingCheckin;

		public OneWorkItemPolicyConfig Config { get; set; }

		#region base properties
		public override string Description
		{
			get { return "Ensures that this changeset has one work item assigned to the current user associated with it"; }
		}

		public override string Type
		{
			get { return "One Work Item Policy"; }
		}

		public override string TypeDescription
		{
			get { return "This policy ensures that the changeset is associated with exactly one work item assigned to the current user (excluding code review)"; }
		}

		public override bool CanEdit
		{
			get { return true; }
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
			return OneWorkItemPolicySerializationBinding.PolicyAsmName;
		}

		public override BinaryFormatter GetBinaryFormatter()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Binder = new OneWorkItemPolicySerializationBinding();
			return formatter;
		}
		#endregion

		public override bool Edit(IPolicyEditArgs policyEditArgs)
		{
			if (Config == null)
			{
				Config = new OneWorkItemPolicyConfig();
			}

			using (var form = new OneWorkItemPolicyForm(Config, policyEditArgs.TeamProject))
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

			if (string.IsNullOrEmpty(Config.WorkItemType))
			{
				failures.Add(new PolicyFailure("No Work Item Type has been specified for the One Work Item Policy. Please contact your TFS administrator", this));
				return failures.ToArray();
			}

			var items = pendingCheckin.WorkItems.CheckedWorkItems.Where(w =>
				  Config.WorkItemType == w.WorkItem.Type.Name &&
				  w.WorkItem.Type.Name != "Code Review Request");

			var fails = false;
			if (items.Count() == 0)
			{
				fails = true;
			}
			else
			{
				var workspaceOwner = PendingCheckin.PendingChanges.Workspace.OwnerDisplayName;
				var assignedToMe = items.Where(w => w.WorkItem.Fields.Contains("System.AssignedTo") && w.WorkItem.Fields["System.AssignedTo"].Value.ToString().Equals(workspaceOwner, StringComparison.OrdinalIgnoreCase)).Count();
				var assignedToOthers = items.Count() - assignedToMe;

				if ((Config.ExactlyOne && assignedToMe != 1) ||
					(!Config.ExactlyOne && assignedToMe < 1))
				{
					fails = true;
				}

				if (assignedToOthers > 0)
				{
					fails = true;
				}
			}

			if (fails)
			{
				failures.Add(new PolicyFailure(string.Format("Changeset is required to be associated with {0} one work item of type '{1}' that has been assigned to you.",
					Config.ExactlyOne ? "exactly" : "at least",
					Config.WorkItemType), this));
			}
			
			return failures.ToArray();
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
