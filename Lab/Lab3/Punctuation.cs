using System.Xml.Serialization;
namespace Lab3;

public class Punctuation : Token
{
    [XmlText]
    public override string Value { get; set; }
    public Punctuation() { }
    public Punctuation(string value)
    {
        Value = value;
    }
}