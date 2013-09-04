//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Fault data contract.
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
   public class Fault
   {
      [XmlElement("value", Namespace = "")]
      public FaultValue Value { get; set; }
   }

   public class FaultValue
   {
      [XmlArray("struct", Namespace = ""), XmlArrayItem("member", Namespace = "")]
      public List<Member> Member { get; set; }
   }
}
