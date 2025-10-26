using System.Xml.Serialization;
namespace Lab3;

[XmlInclude(typeof(Word))]
[XmlInclude(typeof(Punctuation))]
public abstract class Token
{
    [XmlText]
    public abstract string Value { get; set; }

    public override string ToString()
    {
        return Value;
    }

} 