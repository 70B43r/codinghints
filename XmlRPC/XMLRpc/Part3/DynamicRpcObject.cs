//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Part 3 of xml rpc post.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using System;
using System.Dynamic;

using CookComputing.XmlRpc;

namespace tobaer.CSharp.codinghints.XmlRpc.Part3
{
	public class DynamicRpcObject : DynamicObject
	{
		public XmlRpcStruct RpcStruct
		{
			get;
			private set;
		}

		public DynamicRpcObject(XmlRpcStruct xmlRpcStruct)
		{
			RpcStruct = xmlRpcStruct;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = RpcStruct[binder.Name] ?? RpcStruct[binder.Name.ToLower()];

			if (result is XmlRpcStruct)
				result = new DynamicRpcObject((XmlRpcStruct)result);

			var array = result as Array;
			if (array != null)
			{
				for (var idx = 0; idx < array.Length; idx++)
				{
					var arrayItem = array.GetValue(idx) as XmlRpcStruct;
					if (arrayItem != null)
						array.SetValue(new DynamicRpcObject(arrayItem), idx);
				}
			}

			return result != null || base.TryGetMember(binder, out result);
		}
	}
}