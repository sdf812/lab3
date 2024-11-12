using System.Globalization;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace ConsoleApp1;


public class DictionaryRepository : IRepository
{
    public  IList<NamedCollection<int, string>> Cache { get; set; }
    BinaryFormatter formatter { get; set; }
    
    public  NamedCollection<int, string>? ActiveTable { get; set; }
    
    public  string FilePath { get; set; } = "dictionary.txt";
    
     
    public void Save()
    {
        using (FileStream fs = new FileStream(FilePath, FileMode.Open))
            formatter.Serialize(fs, Cache);
    }

    public DictionaryRepository()
    {
        GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
        formatter = new();
        ReadToCache();
        
    }

    public void ReadToCache() 
    {
        if (!File.Exists(FilePath))
        {
            using (File.Create(FilePath)) ;

            Cache = new List<NamedCollection<int,string>>();
            return;
        }
        Cache = (IList<NamedCollection<int,string>>)formatter.Deserialize(File.Open(FilePath,FileMode.Open));
    } 
    
    public void Start(int option,string tableName)
    {
        if(ActiveTable == null)
            ActiveTable = Cache.FirstOrDefault(p => p.Name == tableName);

        if (option == 4)
        {
            ActiveTable.ViewElements();
            return;
        }
        string j = null;
        if (option is 1
            or 3)
        {
            Console.WriteLine("значение");
            j = Console.ReadLine();
        }
        int n = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 1: 
                
                ActiveTable?.Add(n,j);
                break;
            case 2:
                ActiveTable?.Value.Remove(n);
                break;
            case 3: 
                
                ActiveTable.Edit(n,j);
                
                break;
            default:
                Console.WriteLine("Некорректный ввод");
                break;
            
        }
    }

    public void CreateCollection(string tableName)
    {
        if (Cache.FirstOrDefault(p => p.Name == tableName) == null)
        {
            Cache.Add(new NamedCollection<int,string>()
            {
                Name = tableName,
                Value = new SortedDictionary<int, string>()
            });
        }
    }
}