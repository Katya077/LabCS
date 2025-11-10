namespace Lab3;

public class Punctuation : Token
{
    public override string Value { get; set; }
    public Punctuation() { }
    public Punctuation(string value)
    {
        Value = value;
    }
}