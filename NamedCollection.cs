namespace ConsoleApp1;

[Serializable]
public class NamedCollection<T>
{
    public string Name { get; set; }
    
    public List<T> Value { get; set; }

    public void Add(T n) => Value.Add(n);
    public void Remove(T n) => Value.Remove(n);
    public void Edit(int index,T n) => Value[index] = n;
    public void ViewElements()
    {
        for (int i = 0; i < Value.Count; i++)
        {
            Console.WriteLine($"[{i}]: {Value[i]}");
        }
    }
    
    
}

[Serializable]
public class NamedCollection<TKey,TValue>
{
    public string Name { get; set; }
    
    public SortedDictionary<TKey,TValue> Value { get; set; }

    public void Add(TKey n,TValue value) => Value.Add(n,value);
    public void remove(TKey n) => Value.Remove(n);
    public void Edit(TKey index,TValue n) => Value[index] = n;
    public void ViewElements()
    {
        foreach (var item in Value)
        {
            Console.WriteLine($"[{item.Key}]: {item.Value}");
        }
    }
}