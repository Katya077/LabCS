namespace Lab3;

public class Punctuation : Token
{
    public override string Value { get; }

    public Punctuation(string value)
    {
        Value = value;
    }
}