using System.Xml.Serialization;
namespace Lab3
{
    [XmlRoot("Text")]
    public class Text
    {
        [XmlElement("Sentence")] 
        public List<Sentence> Sentences { get; set; } = new List<Sentence>();

        public Text()
        {
        }

        public void AddSentence(Sentence sentence)
        {
            Sentences.Add(sentence);
        }

        public void PrintAllSentences()
        {
            Console.WriteLine("\nВсе предложения:");
            for (int i = 0; i < Sentences.Count; i++)
                Console.WriteLine($"{i + 1}: {Sentences[i]}");
        }

        public void PrintAllWords()
        {
            Console.WriteLine("\nВсе слова текста:");
            foreach (var sentence in Sentences)
            foreach (var word in sentence.GetWords())
                Console.WriteLine(word.Value);
        }

        public void ExportToXml(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Text));
                using (var writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, this);
                }

                Console.WriteLine($"\nТекст экспортирован в XML: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при экспорте XML: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
        }

        // метод для вывода предложений по количеству слов
        public List<Sentence> GetSentencesSortedByWordCount()
        {
            if (Sentences == null || Sentences.Count == 0)
            {
                Console.WriteLine("Ошибка: текст не содержит предложений.");
                return new List<Sentence>();
            }

            var sortedSentences = Sentences
                .OrderBy(s => s.GetWords().Count)
                .ToList();

            Console.WriteLine("\nПредложения в порядке возрастания количества слов:");
            foreach (var sentence in sortedSentences)
            {

                var words = sentence.GetWords().Select(w => w.Value).ToList();
                string sentenceText = string.Join(" ", words);

                Console.WriteLine($"{sentenceText} (слов: {words.Count})");
            }

            return sortedSentences;
        }

        // метод для вывода предложений по возрастанию их длины 
        public List<Sentence> GetSentencesSortedByLength()
        {
            if (Sentences == null || Sentences.Count == 0)
            {
                Console.WriteLine("Ошибка: текст не содержит предложений.");
                return new List<Sentence>();
            }

            var sentencePairs = Sentences.Select(s => new
            {
                Sentence = s,
                Text = string.Join(" ", s.GetWords().Select(w => w.Value))
            }).ToList();
            var sortedPairs = sentencePairs
                .OrderBy(p => p.Text.Length)
                .ToList();

            Console.WriteLine("\nПредложения в порядке возрастания длины:");
            foreach (var pair in sortedPairs)
            {
                Console.WriteLine($"{pair.Text} (длина: {pair.Text.Length} символов)");
            }

            return sortedPairs.Select(p => p.Sentence).ToList();
        }
        
        public void RemoveStopWords(string stopWordsFilePath)
        {
            if (!File.Exists(stopWordsFilePath))
            {
                Console.WriteLine($"Ошибка: файл со стоп-словами '{stopWordsFilePath}' не найден.");
                return;
            }

            var stopWords = File.ReadAllLines(stopWordsFilePath)
                .Select(w => w.Trim().ToLower())
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .ToHashSet();

            int removedCount = 0;

            foreach (var sentence in Sentences)
            {
                var words = sentence.GetWords();
                var filtered = words
                    .Where(w => !stopWords.Contains(w.Value.ToLower()))
                    .ToList();

                if (filtered.Count != words.Count)
                {
                    removedCount += words.Count - filtered.Count;
                    sentence.SetWords(filtered);
                }
            }

            Console.WriteLine($"\nУдалено {removedCount} стоп-слов из текста.");
        }
        
        public void BuildWordIndex()
        {
            SortedDictionary<string, (int Count, SortedSet<int> Lines)> index =
                new SortedDictionary<string, (int, SortedSet<int>)>(StringComparer.OrdinalIgnoreCase);

            for (int line = 0; line < Sentences.Count; line++)
            {
                var words = Sentences[line].GetWords();

                foreach (var word in words)
                {
                    string w = word.Value.ToLower();

                    if (!index.ContainsKey(w))
                        index[w] = (0, new SortedSet<int>());

                    var entry = index[w];
                    entry.Count++;                   
                    entry.Lines.Add(line + 1);       
                    index[w] = entry;
                }
            }

            Console.WriteLine("\nСловарь:");
            foreach (var pair in index)
            {
                Console.Write($"{pair.Key}... {pair.Value.Count}: ");

                foreach (var ln in pair.Value.Lines)
                    Console.Write(ln + " ");
                Console.WriteLine();
            }
        }
    }
}