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
        
        Console.WriteLine($"Файл {filePath} успешно прочитан");
        
		 TextParser parser = new TextParser();
		 Text text = parser.Parse(inputText);
		 
	
		 text.ExportToXml("text_output.xml");
		 Console.WriteLine("Создан XML файл: text_output.xml");
        
		 Console.WriteLine("\nПрограмма завершена!");
	}
}
