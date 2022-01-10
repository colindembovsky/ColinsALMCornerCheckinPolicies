using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinsALMCheckinPolicies
{
	[Serializable]
	public class OneWorkItemPolicyConfig
	{
		public string WorkItemType { get; set; }

		public bool ExactlyOne { get; set; }
	}
}
