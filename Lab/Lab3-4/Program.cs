
 namespace Lab3;

class Program 
{
	static void Main(string[] args)
	{
		string filePath = "Input.txt";
		
		if (!File.Exists(filePath))
		{
			Console.WriteLine($"Ошибка: Файл {filePath} не найден!");
			return;
		}
        string inputText =  File.ReadAllText(filePath);
		 
        if (string.IsNullOrWhiteSpace(inputText))
        {
	        Console.WriteLine($"Ошибка: Файл {filePath} пуст!");
	        return;
        }
        
		 TextParser parser = new TextParser();
		 Text text = parser.Parse(inputText);
		 
		List<string> Words = new List<string>();
		foreach (var sentence in text.Sentences)
		{
		 foreach (var word in sentence.GetWords())
			 {
				 Words.Add(word.Value);
			 }
		 }
		Console.WriteLine("\nВсе слова из текста: ");
		foreach(string word in Words)
		{
		 Console.WriteLine(word);
		}
		
	
		Console.WriteLine("\n1.Сортировка предложений по количеству слов:");
		var sorted = text.GetSentencesSortedByWordCount();

		Console.WriteLine("\n2.Сортировка предложений по длине:");
		var sortedByLength = text.GetSentencesSortedByLength();
		
		string stopWordsFile = "stopwords_ru.txt"; 
		text.RemoveStopWords(stopWordsFile);

		Console.WriteLine("\n6.Текст после удаления стоп-слов:");
		text.PrintAllWords();
		
		 text.ExportToXml("text_output.xml");
		 Console.WriteLine("7.Создан XML файл: text_output.xml");
		 
		 Console.WriteLine("\n8. Слова и их частота использования:"); 
		 
		 SortedDictionary<string, (int Count, SortedSet<int> Lines)> gg =new SortedDictionary<string, (int Count, SortedSet<int> Lines)>();
		 gg = text.BuildWordIndex();
		
		 foreach (var pair in gg)
		 {
			 Console.Write($"{pair.Key} — {pair.Value.Count}, предложения: ");
			 foreach (var ln in pair.Value.Lines)
				 Console.Write(ln + " ");
			 Console.WriteLine();
		 }
		 SortedDictionary<int, char> Test =  new SortedDictionary<int, char>();
		 int a1 = 0;
		 char a2 = (char)((int)'a'-1);
		 for (int i = 0; i < 100; i++)
		 {
			 a1 = a1 + 1;
			 a2 = (char)((int)'a'+1);
			 Test.Add(a1,a2);
		 }

		 foreach (var data in Test)
		 {
			 Console.WriteLine($"{Test.Keys}" +  " "  + Test.Values);
		 }
		 
		 

	}
}
