using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.VersionControl.Client.Fakes;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinsALMCheckinPolicies.UnitTests
{
	internal static class FakeUtils
	{
		internal static ShimWorkItem CreateCodeReviewResponse(int id, string state, string reviewResult)
		{
			var responseFields = new List<Field>()
				{
					new ShimField()
					{ 
						NameGet = () => CodeReviewPolicy.ClosedStatus,
						ValueGet = () => reviewResult
					}
				};
			var fakeResponseFields = new ShimFieldCollection()
			{
				ItemGetString = (s) => responseFields.SingleOrDefault(f => f.Name == s)
			};

			var responseWorkItem = new ShimWorkItem()
			{
				TypeGet = () => new ShimWorkItemType()
				{
					NameGet = () => "Code Review Response"
				},
				IdGet = () => id,
				StateGet = () => state,
				FieldsGet = () => fakeResponseFields,
			};
			return responseWorkItem;
		}

		internal static ShimWorkItem CreateCodeReviewRequest(int id, string state, string closedStatus, List<WorkItem> responses)
		{
			var requestFields = new List<Field>()
				{
					new ShimField()
					{ 
						NameGet = () => CodeReviewPolicy.ClosedStatus,
						ValueGet = () => closedStatus
					}
				};
			var fakeRequestFields = new ShimFieldCollection()
			{
				ItemGetString = (s) => requestFields.SingleOrDefault(f => f.Name == s)
			};

			var links = new List<WorkItemLink>();
			foreach(var response in responses)
			{
				links.Add(new ShimWorkItemLink()
					{
						LinkTypeEndGet = () => new ShimWorkItemLinkTypeEnd()
						{
							NameGet = () => "Child",
						},
						TargetIdGet = () => response.Id
					});
			}
			var fakeLinks = new ShimWorkItemLinkCollection();
			fakeLinks.Bind(links);

			var fakeProject = new ShimProject()
			{
				StoreGet = () => new ShimWorkItemStore()
				{
					GetWorkItemInt32 = (i) => responses.SingleOrDefault(r => r.Id == i)
				}
			};

			var reviewWorkItem = new ShimWorkItem()
			{
				TypeGet = () => new ShimWorkItemType()
				{
					NameGet = () => "Code Review Request"
				},
				StateGet = () => state,
				FieldsGet = () => fakeRequestFields,
				WorkItemLinksGet = () => fakeLinks,
				ProjectGet = () => fakeProject
			};

			return reviewWorkItem;
		}

		internal static IPendingCheckin CreatePendingCheckin(ShimWorkItem item)
		{
			return CreatePendingCheckin(new List<ShimWorkItem>() { item });
		}

		internal static IPendingCheckin CreatePendingCheckin(List<ShimWorkItem> items)
		{
			return CreatePendingCheckin(items, new List<PendingChange>()
				{
					new ShimPendingChange()
					{
						ServerItemGet = () => "$/Project/Folder/Item1.cs"
					},
					new ShimPendingChange()
					{
						ServerItemGet = () => "$/Project/Folder/Item2.cs"
					},
					new ShimPendingChange()
					{
						ServerItemGet = () => "$/Project/Folder/SubFolder/Item3.cs"
					},
				});
		}

		internal static IPendingCheckin CreatePendingCheckin(List<ShimWorkItem> items, List<PendingChange> changes)
		{
			var checkin = new StubIPendingCheckin()
			{
				WorkItemsGet = () => new StubIPendingCheckinWorkItems()
				{
					CheckedWorkItemsGet = () =>
					{
						var list = new List<WorkItemCheckinInfo>();
						items.Where(i => i != null).ToList().ForEach(i =>
							{
								list.Add(new WorkItemCheckinInfo(i, WorkItemCheckinAction.Associate));
							});
						return list.ToArray();
					}
				},
				PendingChangesGet = () => new StubIPendingCheckinPendingChanges()
				{
					CheckedPendingChangesGet = () => changes.ToArray(),
					WorkspaceGet = () => new ShimWorkspace()
					{
						OwnerDisplayNameGet = () => "Bob"
					}
				}
			};
			return checkin;
		}

		internal static ShimWorkItem CreateWorkItem(string workItemType, string assignedTo)
		{
			var fields = new List<Field>()
			{
				new ShimField()
				{ 
					NameGet = () => "System.AssignedTo",
					ValueGet = () => assignedTo
				}
			};
			var fakeRequestFields = new ShimFieldCollection()
			{
				ItemGetString = (s) => fields.SingleOrDefault(f => f.Name == s),
				ContainsString = (s) => fields.Any(f => f.Name == s)
			};

			return new ShimWorkItem()
			{
				TypeGet = () => new ShimWorkItemType()
				{
					NameGet = () => workItemType
				},
				FieldsGet = () => fakeRequestFields
			};
		}
	}
}
