using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinsALMCheckinPolicies
{
	public enum PassLevel
	{
		WithComments,
		LooksGood
	}

	[Serializable]
	public class CodeReviewPolicyConfig
	{
		public bool RequireReviewToBeClosed { get; set; }
		public bool FailIfAnyResponseIsNeedsWork { get; set; }
		public PassLevel MinPassLevel { get; set; }
		public List<string> Paths { get; set; }

		public CodeReviewPolicyConfig()
		{
			// default to the entire collection
			Paths = new List<string>() { "$/" };
		}
    }
}
