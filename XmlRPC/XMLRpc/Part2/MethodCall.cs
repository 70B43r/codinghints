//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Method call base class.
//
// Copyright          : (c) 2014 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using System.Xml.Serialization;

namespace tobaer.CSharp.codinghints.XmlRpc.Part2
{
   public abstract class MethodCall
   {
      [XmlElement("methodName", Namespace = "")]
      public string Method { get; set; }
   }
}