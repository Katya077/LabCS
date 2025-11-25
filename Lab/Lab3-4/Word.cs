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
    
    public int CountWord
    {
        get
        {
            List<Token> test = new List<Token>();
            test.Add(this);
            return CountWord = test.Count;
        }

        set
        {
         CountWord = value;{}   
        }
    }

}