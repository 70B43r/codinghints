//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Request data contracts.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace tobaer.CSharp.codinghints.XmlRpc.Part2
{
	[XmlRoot("methodCall", Namespace = "")]
	public class Request : MethodCall
	{
		[XmlArray("params", Namespace = ""), XmlArrayItem("param", Namespace = "")]
		public List<Param> Params { get; set; }
	}

	public class Param
	{
		[XmlElement("value", Namespace = "")]
		public Value Value { get; set; }
	}

	public class Value
	{
		[XmlArray("struct", Namespace = ""), XmlArrayItem("member", Namespace = "")]
		public List<Member> Member { get; set; }
	}
}