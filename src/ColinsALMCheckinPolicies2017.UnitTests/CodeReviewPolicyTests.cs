﻿using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.VersionControl.Client.Fakes;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ColinsALMCheckinPolicies.UnitTests
{
	[TestClass]
	public class CodeReviewPolicyTests
	{
		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyFails_When_NoReview()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood
				}
			};

			using (var context = ShimsContext.Create())
			{
				var checkin = FakeUtils.CreatePendingCheckin(new List<ShimWorkItem>() { null });

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length > 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyFails_When_NoReview_FilesFound_InConfigPath()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood,
					Paths = new List<string>() { "$/" }
				}
			};

			using (var context = ShimsContext.Create())
			{
				var checkin = FakeUtils.CreatePendingCheckin(new List<ShimWorkItem>() { null });

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length > 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyFails_When_Review_FilesFound_AtRootLevel_InConfigPath()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood,
					Paths = new List<string>() { "$/Project/Folder" }
				}
			};

			using (var context = ShimsContext.Create())
			{
				var checkin = FakeUtils.CreatePendingCheckin(new List<ShimWorkItem>() { null }, new List<PendingChange>()
				{
					new ShimPendingChange()
					{
						ServerItemGet = () => "$/Project/Folder/Item1.cs"
					}
				});

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length > 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyFails_When_NotCheckMostRecent_And_OldResponseFailed()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					CheckOnlyMostRecentReview = false,
					MinPassLevel = PassLevel.WithComments
				}
			};

			using (var context = ShimsContext.Create())
			{
				var oldResponses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Needs Work"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Looks Good")
				};
				var oldReview = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", oldResponses);
				var newResponses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Looks Good")
				};
				var newReview = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", newResponses);
				var checkin = FakeUtils.CreatePendingCheckin(new List<ShimWorkItem>() { oldReview, newReview });

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length > 0);
			}
		}


		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyPasses_When_NoReview_NoFilesFound_InConfigPath()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood,
					Paths = new List<string>() { "$/Project/MAIN" }
				}
			};

			using (var context = ShimsContext.Create())
			{
				var checkin = FakeUtils.CreatePendingCheckin(new List<ShimWorkItem>() { null });

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length == 0);
			}
		}

        [TestMethod]
        [TestCategory("CodeReveiw")]
        public void TestPolicyPasses_When_NoReview_NoFilesFound_InSimilarConfigPath()
        {
            var policy = new CodeReviewPolicy()
            {
                Config = new CodeReviewPolicyConfig()
                {
                    RequireReviewToBeClosed = true,
                    FailIfAnyResponseIsNeedsWork = true,
                    MinPassLevel = PassLevel.LooksGood,
                    Paths = new List<string>() { "$/Project/DEV" }
                }
            };

            using (var context = ShimsContext.Create())
            {
                var checkin = FakeUtils.CreatePendingCheckin(new List<ShimWorkItem>() { null }, "$/Project/DEV-Feature1");

                policy.Initialize(checkin);
                var failures = policy.Evaluate();
                Assert.IsTrue(failures.Length == 0);
            }
        }

        [TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicySucceeds_When_RequireClose_And_ReviewIsClosed()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Looks Good")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length == 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyFails_When_RequireClose_And_ReviewIsNotClosed()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Looks Good")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Requested", "", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length > 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicySucceeds_When_AnyNeedsWorkFails_And_NoNeedsWorkResponses()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.WithComments
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Looks Good"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "With Comments")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length == 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyFails_When_AnyNeedsWorkFails_And_OneResponseIsNeedsWork()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Looks Good"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Needs Work")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length > 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyPasses_When_AnyNeedsWorkPasses_And_OneResponseIsNeedsWork()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = false,
					MinPassLevel = PassLevel.LooksGood
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Looks Good"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Needs Work")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length == 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicySucceeds_When_PassLevelIsWithComments_And_OneResponseIsWithComments()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.WithComments
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Looks Good"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "With Comments")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length == 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicySucceeds_When_PassLevelIsWithComments_And_AllResponsesAreLooksGood()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.WithComments
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Looks Good"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Looks Good")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length == 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicySucceeds_When_PassLevelIsLooksGood_And_AllResponsesAreLooksGood()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Looks Good"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Looks Good")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length == 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyFails_When_PassLevelIsLooksGood_And_NotAllResponsesAreLooksGood()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "With Comments"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Looks Good")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length > 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyFails_When_MinPassLeveIsWithComments_And_RequestHasNoResponses()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.WithComments
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>();
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length > 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyFails_When_MinPassLeveIsLooksGood_And_RequestHasNoResponses()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>();
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length > 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyFails_When_MinPassLeveIsLooksGood_And_RequestHasOnlyDeclinedResponses()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Declined"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Declined")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length > 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyFails_When_MinPassLeveIsLooksGood_And_RequestIsAbandoned()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.LooksGood
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Declined"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Declined")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Abandoned", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length > 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicyPassess_When_MinPassLeveIsWithComments_And_RequestHasDeclinedResponses()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					MinPassLevel = PassLevel.WithComments
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Declined"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "With Comments")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length == 0);
			}
		}

        [TestMethod]
        [TestCategory("CodeReveiw")]
        public void TestPolicyFails_When_MinPassLeveIsNone_And_NoRequests()
        {
            var policy = new CodeReviewPolicy()
            {
                Config = new CodeReviewPolicyConfig()
                {
                    RequireReviewToBeClosed = false,
                    FailIfAnyResponseIsNeedsWork = false,
                    MinPassLevel = PassLevel.None
                }
            };

            using (var context = ShimsContext.Create())
            {
                var checkin = FakeUtils.CreatePendingCheckin(new List<ShimWorkItem>());

                policy.Initialize(checkin);
                var failures = policy.Evaluate();
                Assert.IsTrue(failures.Length > 0);
            }
        }

        [TestMethod]
        [TestCategory("CodeReveiw")]
        public void TestPolicyPassess_When_MinPassLeveIsNone_And_RequestHasNoResponses()
        {
            var policy = new CodeReviewPolicy()
            {
                Config = new CodeReviewPolicyConfig()
                {
                    RequireReviewToBeClosed = false,
                    FailIfAnyResponseIsNeedsWork = false,
                    MinPassLevel = PassLevel.None
                }
            };

            using (var context = ShimsContext.Create())
            {
                var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Requested", "", new List<WorkItem>());
                var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

                policy.Initialize(checkin);
                var failures = policy.Evaluate();
                Assert.IsTrue(failures.Length == 0);
            }
        }

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicySucceeds_When_CheckMostRecent_And_SingleResponse()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					CheckOnlyMostRecentReview = true,
					MinPassLevel = PassLevel.WithComments
				}
			};

			using (var context = ShimsContext.Create())
			{
				var responses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Looks Good"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Looks Good")
				};
				var reviewWorkItem = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", responses);
				var checkin = FakeUtils.CreatePendingCheckin(reviewWorkItem);

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length == 0);
			}
		}

		[TestMethod]
		[TestCategory("CodeReveiw")]
		public void TestPolicySucceeds_When_CheckMostRecent_And_MultipleResponses()
		{
			var policy = new CodeReviewPolicy()
			{
				Config = new CodeReviewPolicyConfig()
				{
					RequireReviewToBeClosed = true,
					FailIfAnyResponseIsNeedsWork = true,
					CheckOnlyMostRecentReview = true,
					MinPassLevel = PassLevel.WithComments
				}
			};

			using (var context = ShimsContext.Create())
			{
				var oldResponses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(2, "Closed", "Needs Work"),
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Looks Good")
				};
				var oldReview = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", oldResponses);
				var newResponses = new List<WorkItem>()
				{
					FakeUtils.CreateCodeReviewResponse(3, "Closed", "Looks Good")
				};
				var newReview = FakeUtils.CreateCodeReviewRequest(1, "Closed", "Closed", newResponses);
				var checkin = FakeUtils.CreatePendingCheckin(new List<ShimWorkItem>() { oldReview, newReview });

				policy.Initialize(checkin);
				var failures = policy.Evaluate();
				Assert.IsTrue(failures.Length == 0);
			}
		}
	}
}
