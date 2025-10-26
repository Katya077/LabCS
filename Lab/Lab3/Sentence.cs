using System.Xml.Serialization;
namespace Lab3;

public class Sentence
{
    private List<Token> _tokens;

    public Sentence()
    {
        _tokens = new List<Token>();
    }
    public void AddToken(Token token)
    {
        _tokens.Add(token);
    }

    public void AddWord(Word word)
    {
        _tokens.Add(word);
    }
    public void AddPunctuation(Punctuation punctuation)
    {
        _tokens.Add(punctuation);
    }

    [XmlIgnore] 
    public List<Token> Tokens => _tokens;
    
    [XmlElement("Word", typeof(Word))]
    [XmlElement("Punctuation", typeof(Punctuation))]
    public List<Token> TokensForXml
    {
        get => _tokens;
        set => _tokens = value;
    }
    public List<Word> GetWords()
    {
        var words = new List<Word>();
        foreach (var token in _tokens)
        {
            if (token is Word word)
            {
                words.Add(word);
            }
        }
        return words;
    }
    public override string ToString()
    {
        var result = " ";
        foreach (var token in _tokens)
        {
            result += token.ToString();
        }
        return result.Trim();
    }
}