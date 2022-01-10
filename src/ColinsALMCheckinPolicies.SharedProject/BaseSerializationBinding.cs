using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ColinsALMCheckinPolicies
{
	internal abstract class BaseSerializationBinding : SerializationBinder
	{
		public virtual string AsmName
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
		{
			var assembly = serializedType.Assembly;
			if (assembly.Equals(Assembly.GetExecutingAssembly()))
			{
				assemblyName = AsmName;
			}
			else
			{
				assemblyName = assembly.FullName;
			}
			typeName = serializedType.FullName;
		}

		public override Type BindToType(string assemblyName, string typeName)
		{
			throw new NotImplementedException();
		}
	}
}
