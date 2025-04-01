namespace App.Practice6;

public class DisplacementCache<T> : IDisplacementCache<T>
{
    public Dictionary<string, (T Item, DateTime LastTime)> cache;
    private LinkedList<string> orders;

    public int Capacity { get; set; }
    public TimeSpan Ttl { get; set; }
    public ITimeService TimeService { get; }

    public DisplacementCache(int capacity, TimeSpan ttl, ITimeService timeService)
    {
        Capacity = capacity;
        Ttl = ttl;
        TimeService = timeService;
        cache = new Dictionary<string, (T Item, DateTime LastTime)>();
        orders = new LinkedList<string>();
    }

    private void CheckOrders()
    {
        if (orders.Count == 0)
        {
            throw new InvalidOperationException("Orders is empty");
        }
    }

    private void CheckCache()
    {
        if (cache.Count == 0)
        {
            throw new InvalidOperationException("Cache is empty");
        }
    }
    public IReadOnlyDictionary<string, T> GetAllCacheItems()
    {
        CheckCache();
        var dictionary = new Dictionary<string, T>();
        foreach (var key in cache.Keys)
        {
            dictionary[key] = cache[key].Item;
        }

        return dictionary;
    }

    public void AddOrUpdate(string key, T item)
    {
        if (key == null)
        {
            throw new ArgumentException("key cannot be null");
        }

        if (cache.ContainsKey(key))
        {
            orders.Remove(key);
            orders.AddLast(key);
        }

        else if (cache.Count >= Capacity)
        {
            CheckOrders();
            var oldestKey = orders.First.Value;
            orders.RemoveFirst();
            cache.Remove(oldestKey);
        }

        cache[key] = (item, TimeService.GetNowTime());
        orders.AddLast(key);
    }

    public T TryGet(string key)
    {
        if (!cache.ContainsKey(key))
        {
            return default;
        }

        var (item, lastTime) = cache[key];
        if (TimeService.GetNowTime() - lastTime > Ttl)
        {
            orders.Remove(key);
            cache.Remove(key);
            return default;
        }

        orders.Remove(key);
        orders.AddLast(key);
        return item;
    }

    public void ClearExpiredItems()
    {
        var keysToRemove = new List<string>();

        foreach (var key in cache.Keys)
        {
            if (TimeService.GetNowTime() - cache[key].LastTime > Ttl)
            {
                keysToRemove.Add(key);
            }
        }

        foreach (var key in keysToRemove)
        {
            cache.Remove(key);
            orders.Remove(key);
        }
    }
}