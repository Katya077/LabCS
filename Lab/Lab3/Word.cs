using System.Xml.Serialization;

namespace Lab3;

    public class Word : Token
    {
        [XmlText]
        public override string Value { get; set; }
        public Word() { }
        public Word(string value)
        {
            Value = value;
        }
    }
