using System.Runtime.CompilerServices;


using ConsoleApp1;
Console.WriteLine("Выберите тип коллекции (1 - List, 2 - Dictionary): ");
int choice = int.Parse(Console.ReadLine() ?? string.Empty);
Console.WriteLine("Назовите новую  или введите название старой колекции");
var collectionName = Console.ReadLine();
IRepository repository;
if (choice == 2)
{
    repository = new DictionaryRepository();
}
else
{
    repository = new ListRepository();
}
repository.CreateCollection(collectionName);
try
{
    while (true)
    {
        Console.WriteLine("1. Добавить элемент");
        Console.WriteLine("2. Удалить элемент");
        Console.WriteLine("3. Редактировать элемент");
        Console.WriteLine("4. Просмотреть элементы");
        Console.WriteLine("0. Выйти");
        
        int option = int.Parse(Console.ReadLine());
        if (option == 0)
        {
            return;
        }
        repository.Start(option,collectionName);
    }
}
finally
{
    repository.Save();
}


        