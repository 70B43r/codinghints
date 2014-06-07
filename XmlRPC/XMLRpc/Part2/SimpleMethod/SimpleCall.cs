//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Simple method call.
//
// Copyright          : (c) 2014 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Xml.Serialization;

namespace tobaer.CSharp.codinghints.XmlRpc.Part2.SimpleMethod
{
   public class SimpleCall : MethodCall
   {
      [XmlArray("params", Namespace = ""), XmlArrayItem("param", Namespace = "")]
      public List<MethodCallArgument> Arguments { get; set; }
   }
}