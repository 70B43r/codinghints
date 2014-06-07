//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Simple method call argument.
//
// Copyright          : (c) 2014 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using System.Xml.Serialization;

namespace tobaer.CSharp.codinghints.XmlRpc.Part2.SimpleMethod
{
   public class MethodCallArgument
   {
      [XmlElement("value", Namespace = "")]
      public MethodCallValue Value { get; set; }
   }
}