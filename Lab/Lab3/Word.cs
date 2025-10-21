namespace Lab3;

    public class Word : Token
    {
        public override string Value { get; }

        public Word(string value)
        {
            Value = value;
        }
    }
