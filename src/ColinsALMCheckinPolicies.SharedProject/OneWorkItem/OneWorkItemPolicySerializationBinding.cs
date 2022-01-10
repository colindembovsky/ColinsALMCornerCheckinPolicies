using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ColinsALMCheckinPolicies
{
	internal sealed class OneWorkItemPolicySerializationBinding : BaseSerializationBinding
	{
		internal const string PolicyAsmName = "ColinsALMCheckinPolicies.OneWorkItemPolicy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

		public override string AsmName
		{
			get	{ return PolicyAsmName;	}
		}
	}
}
