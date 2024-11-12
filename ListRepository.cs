using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace ConsoleApp1;

public class ListRepository : IRepository
{
    public IList<NamedCollection<int>> Cache { get; set; }


    BinaryFormatter formatter { get; set; }

    public NamedCollection<int> ActiveTable { get; set; }

    public string FilePath { get; set; } = "list.txt";

    public void Save()
    {
        using (FileStream fs = new FileStream(FilePath, FileMode.Open))
            formatter.Serialize(fs, Cache);
    }

    public ListRepository()
    {
        formatter = new();
        ReadToCache();
        
    }

public void ReadToCache() 
    {
        if (!File.Exists(FilePath))
        {
            using (File.Create(FilePath)) ;

            Cache = new List<NamedCollection<int>>();
            return;
        }
        Cache = (IList<NamedCollection<int>>)formatter.Deserialize(File.Open(FilePath,FileMode.Open));
    } 
    
    public void Start(int option,string tableName) 
    { 
        ActiveTable = Cache.FirstOrDefault(p => p.Name == tableName) ?? throw new InvalidOperationException();
        
        if (option == 4)
        {
            SortHelper.QuickSort(ActiveTable.Value, 0, ActiveTable.Value.Count - 1);
            ActiveTable.ViewElements();
            return;
        }
        
        int  n = int.Parse(Console.ReadLine()); 

        switch (option) 
        { 
            case 1:  
                ActiveTable?.Add(n); 
                break; 
            case 2: 
                ActiveTable?.Remove(n); 
                break; 
            case 3:  
                Console.WriteLine("индекс"); 
                int j = int.Parse(Console.ReadLine()); 
                ActiveTable.Edit(j,n);; 
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
            Cache.Add(new NamedCollection<int>() 
            { 
                Name = tableName, 
                Value = new List<int>() 
            }); 
        } 
    } 
}