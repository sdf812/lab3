namespace ConsoleApp1;

public interface IRepository
{
    public void Save();
    public void ReadToCache();
    public void Start(int option, string tableName);
    public void CreateCollection(string tableName);
}