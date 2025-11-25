using System.Xml.Serialization;
namespace Lab3;

public class Sentence
{
    private List<Token> _tokens = new List<Token>();

    public Sentence() { }
    public void AddToken(Token token)
    {
        _tokens.Add(token);
    }

    public void AddWord(Word word)
    {
        _tokens.Add(word);
    }

    [XmlIgnore] 
    public List<Token> Tokens => _tokens;
    
    [XmlElement("Word")]
    public List<Word> WordsForXml
    {
        get
        {
            var words = new List<Word>();
            foreach (var token in _tokens)
            {
                if (token is Word word)
                    words.Add(word);
            }
            return words;
        }
        set
        {
            _tokens.Clear();
            if (value != null)
            {
                foreach (var word in value)
                    _tokens.Add(word);
            }
        }
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
    public void SetWords(List<Word> newWords)
    {
        if (newWords == null)
            throw new ArgumentNullException(nameof(newWords), "Список слов не может быть null.");
        _tokens.Clear();
        foreach (var word in newWords)
        {
            _tokens.Add(word);
        }
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