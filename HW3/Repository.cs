public interface IEntity
{
    int Id { get; }
}

public class Repository<T> where T : IEntity
{
    private readonly Dictionary<int, T> _items = new();

    public int Count => _items.Count;

    public void Add(T item)
    {
        if (_items.ContainsKey(item.Id))
            throw new InvalidOperationException($"Element with Id={item.Id} already exists.");
        _items[item.Id] = item;
    }

    public bool Remove(int id) => _items.Remove(id);

    public T? GetById(int id) => _items.TryGetValue(id, out var v) ? v : default;

    public IReadOnlyList<T> GetAll() => _items.Values.ToArray();

    public IReadOnlyList<T> Find(Predicate<T> predicate)
    {
        var result = new List<T>();
        foreach (var item in _items.Values)
            if (predicate(item)) result.Add(item);
        return result;
    }
}

class Product : IEntity
{
    public int Id {get;}
    public string Name {get;}
    public decimal Price {get;}
    public Product(int id, string name, decimal price) {Id = id; Name = name; Price = price;}
    public override string ToString() => $"#{Id} {Name} ({Price})";
}

class User : IEntity
{
    public int Id {get;}
    public string Name {get;}
    public User(int id, string name) {Id = id; Name = name;}
    public override string ToString() => $"#{Id} {Name}";
}

class Program
{
    static void Main()
    {
        var products = new Repository<Product>();
        products.Add(new Product(1, "Книга", 500));
        products.Add(new Product(2, "Ноутбук", 75000));
        products.Add(new Product(3, "Мышь", 1500));

        var users = new Repository<User>();
        users.Add(new User(1, "Alice"));
        users.Add(new User(2, "Bob"));

        Console.WriteLine($"products: {products.Count}, users: {users.Count}");
        Console.WriteLine($"GetById(2): {products.GetById(2)}");
        Console.WriteLine($"GetById(99): {products.GetById(99)?.ToString() ?? "null"}");

        Console.WriteLine("GetAll:");
        foreach (var p in products.GetAll())
            Console.WriteLine($"{p}");

        Console.WriteLine("дороже 1000:");
        foreach (var p in products.Find(p => p.Price > 1000))
            Console.WriteLine($"{p}");

        try
        {
            products.Add(new Product(1, "Дубликат", 1));
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine($"Remove(2) -> {products.Remove(2)}, осталось {products.Count}");
        Console.WriteLine($"Remove(999) -> {products.Remove(999)}");
    }
}
