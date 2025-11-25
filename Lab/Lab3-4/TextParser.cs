namespace Lab3;

public class TextParser
{
    public Text Parse(string inputText)
    {
        Text text = new Text();

        if (string.IsNullOrEmpty(inputText))
            return text;

        string[] sentencesStrings = SplitIntoSentences(inputText);

        foreach (var sentenceStr in sentencesStrings)
        {
            Sentence sentence = ParseSentence(sentenceStr);
            text.AddSentence(sentence);
        }

        return text;
    }
    static string[] SplitIntoSentences(string text)
    {
        var sentences = new List<string>();
        int start = 0;

        char[] punctuationMarks = { '.', '!', '?', ';', ':', '…' }; 

        for (int i = 0; i < text.Length; i++)
        {
            if (punctuationMarks.Contains(text[i])) 
            {
                string sentence = text.Substring(start, i - start + 1).Trim();
                if (!string.IsNullOrEmpty(sentence))
                {
                    sentences.Add(sentence);
                }
                start = i + 1;
            }
        }

        if (start < text.Length)
        {
            string remaining = text.Substring(start).Trim();
            if (!string.IsNullOrEmpty(remaining))
            {
                sentences.Add(remaining);
            }
        }

        return sentences.ToArray();
    }

    static Sentence ParseSentence(string sentenceText)
    {
        Sentence sentence = new Sentence();
        string currentWord = "";

        for (int i = 0; i < sentenceText.Length; i++)
        {
            char c = sentenceText[i];

            if (char.IsLetterOrDigit(c))
            {
                currentWord += c;
            }
            else
            {
                if (!string.IsNullOrEmpty(currentWord))
                {
                    sentence.AddWord(new Word(currentWord));
                    currentWord = "";
                }
                
                if (char.IsPunctuation(c))
                {
                    sentence.AddToken(new Punctuation(c.ToString()));
                }
            }
        }

        if (!string.IsNullOrEmpty(currentWord))
        {
            sentence.AddToken(new Word(currentWord));
        }
        return sentence;
    }
}