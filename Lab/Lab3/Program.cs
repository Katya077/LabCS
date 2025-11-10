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

		


		 text.ExportToXml("text_output.xml");
		 Console.WriteLine("Создан XML файл: text_output.xml");
		
	}
}
