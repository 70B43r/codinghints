//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Member values.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Xml.Serialization;

namespace tobaer.CSharp.codinghints.XmlRpc.Part2
{
   public class Member
   {
      [XmlElement("name", Namespace = "")]
      public string Name { get; set; }

      [XmlElement("value", Namespace = "")]
      public MemberValue Value { get; set; }
   }

   public class MemberValue
   {
      [XmlChoiceIdentifier("ValueChoice"),
      XmlElement("int", typeof(int), Namespace = ""),
      XmlElement("string", typeof(string), Namespace = ""),
      XmlElement("datetime", typeof(DateTime), Namespace = ""),
      XmlElement("double", typeof(double), Namespace = ""),
      XmlElement("base64", typeof(string), Namespace = ""),
      XmlElement("array", typeof(ArrayList), Namespace = "")]
      public object Value { get; set; }

      public enum ValueType
      {
         @string,
         @int,
         @datetime,
         @double,
         base64,
         array
      }

      [XmlIgnore]
      public virtual ValueType ValueChoice { get; set; }
   }
}
