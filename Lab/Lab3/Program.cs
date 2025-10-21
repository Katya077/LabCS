namespace Lab3;

class Program 
{
	static void Main(string[] args)
	{
		Console.WriteLine("Введите текст для анализа: ");
		string inputText = Console.ReadLine();
		
		TextParser parser = new TextParser();
		Text text = parser.Parse(inputText);
		text.PrintAllSentences();
		text.PrintAllWords();
	}
	
}
