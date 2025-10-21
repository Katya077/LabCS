namespace Lab3;

public abstract class Token
{
    public abstract string Value { get; }

    public override string ToString()
    {
        return Value;
    }

}