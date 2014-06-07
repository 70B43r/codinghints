//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Method call value.
//
// Copyright          : (c) 2014 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace tobaer.CSharp.codinghints.XmlRpc.Part2.SimpleMethod
{
	[Serializable]
	public class MethodCallValue
	{
		private object value;

		[XmlChoiceIdentifier("ValueChoice"),
		 XmlElement("int", typeof(int), Namespace = ""),
		 XmlElement("i4", typeof(int), Namespace = ""),
		 XmlElement("string", typeof(string), Namespace = ""),
		 XmlElement("datetime", typeof(DateTime), Namespace = ""),
		 XmlElement("double", typeof(double), Namespace = ""),
		 XmlElement("base64", typeof(string), Namespace = ""),
		 XmlElement("array", typeof(ArrayList), Namespace = "")]
		public object Value
		{
			get { return value; }
			set
			{
				this.value = value;

				if (value is int)
					ValueChoice = ValueType.i4;

				if (value is DateTime)
					ValueChoice = ValueType.datetime;

				if (value is string)
					ValueChoice = ValueType.@string;

				if (value is double || value is float || value is decimal)
					ValueChoice = ValueType.@double;

				if (value is Stream || value is byte[])
					ValueChoice = ValueType.base64;

				if (value is IEnumerable)
					ValueChoice = ValueType.array;
			}
		}

		public enum ValueType
		{
			@string,
			@int,
			@i4,
			@datetime,
			@double,
			base64,
			array
		}

		[XmlIgnore]
		public ValueType ValueChoice { get; private set; }

	   public static implicit operator int(MethodCallValue value) { return (int)value.Value; }

	   public static implicit operator MethodCallValue(int value) { return new MethodCallValue { Value = value, ValueChoice = ValueType.@i4 }; }

      public static implicit operator string(MethodCallValue value) { return (string)value.Value; }

      public static implicit operator MethodCallValue(string value) { return new MethodCallValue { Value = value, ValueChoice = ValueType.@string }; }

      public static implicit operator DateTime(MethodCallValue value) { return (DateTime)value.Value; }

      public static implicit operator MethodCallValue(DateTime value) { return new MethodCallValue { Value = value, ValueChoice = ValueType.datetime }; }

      public static implicit operator double(MethodCallValue value) { return (double)value.Value; }

      public static implicit operator MethodCallValue(double value) { return new MethodCallValue { Value = value, ValueChoice = ValueType.@double }; }
	}
}