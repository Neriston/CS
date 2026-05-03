public static class CollectionUtils
{
    public static List<T> Distinct<T>(List<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        var seen = new HashSet<T>();
        var result = new List<T>();
        foreach (var item in source)
            if (seen.Add(item)) result.Add(item);
        return result;
    }

    public static Dictionary<TKey, List<TValue>> GroupBy<TValue, TKey>(
        List<TValue> source,
        Func<TValue, TKey> keySelector) where TKey : notnull
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
        var result = new Dictionary<TKey, List<TValue>>();
        foreach (var item in source)
        {
            var key = keySelector(item);
            if (!result.TryGetValue(key, out var list))
            {
                list = new List<TValue>();
                result[key] = list;
            }
            list.Add(item);
        }
        return result;
    }

    public static Dictionary<TKey, TValue> Merge<TKey, TValue>(
        Dictionary<TKey, TValue> first,
        Dictionary<TKey, TValue> second,
        Func<TValue, TValue, TValue> conflictResolver) where TKey : notnull
    {
        if (first == null) throw new ArgumentNullException(nameof(first));
        if (second == null) throw new ArgumentNullException(nameof(second));
        if (conflictResolver == null) throw new ArgumentNullException(nameof(conflictResolver));
        var result = new Dictionary<TKey, TValue>(first);
        foreach (var kv in second)
        {
            if (result.TryGetValue(kv.Key, out var existing))
                result[kv.Key] = conflictResolver(existing, kv.Value);
            else
                result[kv.Key] = kv.Value;
        }
        return result;
    }

    public static T MaxBy<T, TKey>(List<T> source, Func<T, TKey> selector)
        where TKey : IComparable<TKey>
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        if (source.Count == 0)
            throw new InvalidOperationException("Collection is empty.");
        var best = source[0];
        var bestKey = selector(best);
        for (int i = 1; i < source.Count; i++)
        {
            var key = selector(source[i]);
            if (key.CompareTo(bestKey) > 0)
            {
                best = source[i];
                bestKey = key;
            }
        }
        return best;
    }
}

class Product
{
    public int Id {get;}
    public string Name {get;}
    public decimal Price {get;}
    public Product(int id, string name, decimal price) {Id = id; Name = name; Price = price;}
    public override string ToString() => $"#{Id} {Name} ({Price})";
}

class Program
{
    static void Main()
    {
        var ints = new List<int> {1, 2, 2, 3, 1, 4, 3, 5};
        Console.WriteLine($"distinct ints: [{string.Join(", ", CollectionUtils.Distinct(ints))}]");

        var strs = new List<string> {"a", "b", "a", "c", "b", "d"};
        Console.WriteLine($"distinct strings: [{string.Join(", ", CollectionUtils.Distinct(strs))}]");

        var words = new List<string> {"cat", "dog", "bird", "fish", "ant", "wolf"};
        var grouped = CollectionUtils.GroupBy(words, w => w.Length);
        Console.WriteLine("group by length:");
        foreach (var kv in grouped)
            Console.WriteLine($"  {kv.Key}: [{string.Join(", ", kv.Value)}]");

        var counts1 = new Dictionary<string, int> { ["hello"] = 2, ["world"] = 1, ["foo"] = 3 };
        var counts2 = new Dictionary<string, int> { ["world"] = 4, ["foo"] = 1, ["bar"] = 5 };
        var merged = CollectionUtils.Merge(counts1, counts2, (a, b) => a + b);
        Console.WriteLine("merge:");
        foreach (var kv in merged)
            Console.WriteLine($"  {kv.Key} = {kv.Value}");

        var prods = new List<Product>
        {
            new(1, "Книга", 500),
            new(2, "Ноутбук", 75000),
            new(3, "Мышь", 1500),
        };
        Console.WriteLine($"max by price: {CollectionUtils.MaxBy(prods, p => p.Price)}");

        try
        {
            CollectionUtils.MaxBy(new List<int>(), x => x);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"empty MaxBy: {ex.Message}");
        }
    }
}
