using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinsALMCheckinPolicies.UnitTests
{
	[TestClass]
	public class OneWorkItemPolicyTests
	{
		[TestMethod]
		[TestCategory("OneWorkItem")]
		public void TestPolicyFails_If_NoWorkItemTypes_Configured()
		{
			var policy = new OneWorkItemPolicy() { Config = new OneWorkItemPolicyConfig() };

			using (var context = ShimsContext.Create())
			{
				var checkin = FakeUtils.CreatePendingCheckin(FakeUtils.CreateWorkItem("Task", "Bob"));

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.AreEqual(1, failures.Length);
				Assert.AreEqual("No Work Item Type has been specified for the One Work Item Policy. Please contact your TFS administrator", failures[0].Message);
			}
		}

		[TestMethod]
		[TestCategory("OneWorkItem")]
		public void TestPolicyFails_IfNoWorkItemsAssociated()
		{
			var policy = new OneWorkItemPolicy() { Config = new OneWorkItemPolicyConfig() { WorkItemType = "Task", ExactlyOne = true } };

			using (var context = ShimsContext.Create())
			{
				var checkin = FakeUtils.CreatePendingCheckin(new List<ShimWorkItem>() { null });

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.AreEqual(1, failures.Length);
				Assert.IsTrue(failures[0].Message.StartsWith("Changeset is required to be associated with exactly one work item of type 'Task' that has been assigned to you."));
			}
		}

		[TestMethod]
		[TestCategory("OneWorkItem")]
		public void TestPolicyFails_IfNoWorkItems_OfType_Associated()
		{
			var policy = new OneWorkItemPolicy() { Config = new OneWorkItemPolicyConfig() { WorkItemType = "Task", ExactlyOne = true } };

			using (var context = ShimsContext.Create())
			{
				var checkin = FakeUtils.CreatePendingCheckin(FakeUtils.CreateWorkItem("Bug", "Bob"));

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.AreEqual(1, failures.Length);
				Assert.IsTrue(failures[0].Message.StartsWith("Changeset is required to be associated with exactly one work item of type 'Task' that has been assigned to you."));
			}
		}

		[TestMethod]
		[TestCategory("OneWorkItem")]
		public void TestPolicyFails_IfWorkItems_OfType_AssignedToDifferentUser_Associated()
		{
			var policy = new OneWorkItemPolicy() { Config = new OneWorkItemPolicyConfig() { WorkItemType = "Task", ExactlyOne = true } };

			using (var context = ShimsContext.Create())
			{
				var checkin = FakeUtils.CreatePendingCheckin(FakeUtils.CreateWorkItem("Task", "Joe"));

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.AreEqual(1, failures.Length);
				Assert.IsTrue(failures[0].Message.StartsWith("Changeset is required to be associated with exactly one work item of type 'Task' that has been assigned to you."));
			}
		}

		[TestMethod]
		[TestCategory("OneWorkItem")]
		public void TestPolicyFails_If_TwoWorkItems_OfType_Associated_And_OnlyOneAllowed()
		{
			var policy = new OneWorkItemPolicy() { Config = new OneWorkItemPolicyConfig() { WorkItemType = "Task", ExactlyOne = true } };

			using (var context = ShimsContext.Create())
			{
				var list = new List<ShimWorkItem>() 
				{
					FakeUtils.CreateWorkItem("Task", "Bob"),
					FakeUtils.CreateWorkItem("Task", "Bob")
				};
				var checkin = FakeUtils.CreatePendingCheckin(list);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.AreEqual(1, failures.Length);
				Assert.IsTrue(failures[0].Message.StartsWith("Changeset is required to be associated with exactly one work item of type 'Task' that has been assigned to you."));
			}
		}

		[TestMethod]
		[TestCategory("OneWorkItem")]
		public void TestPolicyFails_If_OneWorkItem_OfWrongType_IsAssociated()
		{
			var policy = new OneWorkItemPolicy() { Config = new OneWorkItemPolicyConfig() { WorkItemType = "Task", ExactlyOne = true } };

			using (var context = ShimsContext.Create())
			{
				var list = new List<ShimWorkItem>() 
				{
					FakeUtils.CreateWorkItem("Bug", "Bob"),
				};
				var checkin = FakeUtils.CreatePendingCheckin(list);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.AreEqual(1, failures.Length);
				Assert.IsTrue(failures[0].Message.StartsWith("Changeset is required to be associated with exactly one work item of type 'Task' that has been assigned to you."));
			}
		}

		[TestMethod]
		[TestCategory("OneWorkItem")]
		public void TestPolicyFails_If_OneWI_AssignedToSomeoneElse_And_OneWIAssignedToMe()
		{
			var policy = new OneWorkItemPolicy() { Config = new OneWorkItemPolicyConfig() { WorkItemType = "Task", ExactlyOne = true } };

			using (var context = ShimsContext.Create())
			{
				var list = new List<ShimWorkItem>() 
				{
					FakeUtils.CreateWorkItem("Task", "Joe"),
					FakeUtils.CreateWorkItem("Task", "Bob"),
				};
				var checkin = FakeUtils.CreatePendingCheckin(list);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.AreEqual(1, failures.Length);
				Assert.IsTrue(failures[0].Message.StartsWith("Changeset is required to be associated with exactly one work item of type 'Task' that has been assigned to you."));
			}
		}

		[TestMethod]
		[TestCategory("OneWorkItem")]
		public void TestPolicySucceeds_If_TwoWorkItems_OfType_Associated_And_AtLeastAllowed()
		{
			var policy = new OneWorkItemPolicy() { Config = new OneWorkItemPolicyConfig() { WorkItemType = "Task", ExactlyOne = false } };

			using (var context = ShimsContext.Create())
			{
				var list = new List<ShimWorkItem>() 
				{
					FakeUtils.CreateWorkItem("Task", "Bob"),
					FakeUtils.CreateWorkItem("Task", "Bob")
				};
				var checkin = FakeUtils.CreatePendingCheckin(list);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.AreEqual(0, failures.Length);
			}
		}

		[TestMethod]
		[TestCategory("OneWorkItem")]
		public void TestPolicySucceeds_If_OneWorkItem_OfType_Associated()
		{
			var policy = new OneWorkItemPolicy() { Config = new OneWorkItemPolicyConfig() { WorkItemType = "Task", ExactlyOne = true } };

			using (var context = ShimsContext.Create())
			{
				var list = new List<ShimWorkItem>() 
				{
					FakeUtils.CreateWorkItem("Task", "Bob")
				};
				var checkin = FakeUtils.CreatePendingCheckin(list);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.AreEqual(0, failures.Length);
			}
		}

		[TestMethod]
		[TestCategory("OneWorkItem")]
		public void TestPolicySucceeds_If_OneWorkItem_OfType_And_CodeReview_Associated()
		{
			var policy = new OneWorkItemPolicy() { Config = new OneWorkItemPolicyConfig() { WorkItemType = "Task", ExactlyOne = true } };

			using (var context = ShimsContext.Create())
			{
				var list = new List<ShimWorkItem>() 
				{
					FakeUtils.CreateWorkItem("Task", "Bob"),
					FakeUtils.CreateWorkItem("Code Review Request", "Bob")
				};
				var checkin = FakeUtils.CreatePendingCheckin(list);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.AreEqual(0, failures.Length);
			}
		}
	}
}
