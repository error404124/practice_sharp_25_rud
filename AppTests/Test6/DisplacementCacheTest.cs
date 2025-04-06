using App.Practice6;

namespace AppTests.Test6;


public class DisplacementCacheTest
{
    [Test]
    public void DisplacementCacheTest1()
    {
        var timeService = new TimeService(DateTime.Now);
        var displacementCache = new DisplacementCache<int>(3, new TimeSpan(0, 0, 10), timeService);

        var key = "test1";
        var testObject = 5;

        displacementCache.AddOrUpdate(key, testObject);

        Assert.That(displacementCache.cache.Count, Is.EqualTo(1));
        Assert.That(displacementCache.cache[key].Item, Is.EqualTo(testObject));
        Assert.That(displacementCache.cache[key].LastTime.Second, Is.EqualTo(timeService.GetNowTime().Second));
    }

    [Test]
    public void DisplacementCacheTest2()
    {
        var timeService = new TimeService(DateTime.Now);
        var displacementCache = new DisplacementCache<int>(3, new TimeSpan(0, 0, 2), timeService);

        var key1 = "test1";
        var testObject1 = 5;
        displacementCache.AddOrUpdate(key1, testObject1);
        Assert.That(displacementCache.TryGet(key1), Is.EqualTo(5));

        var key2 = "test2";
        var testObject2 = 55;
        displacementCache.AddOrUpdate(key2, testObject2);
        timeService.Advance(TimeSpan.FromSeconds(3));
        Assert.That(displacementCache.TryGet(key2), Is.EqualTo(0));
    }

    [Test]
    public void DisplacementCacheTest3()
    {
        var timeService = new TimeService(DateTime.Now);
        var displacementCache = new DisplacementCache<int>(3, new TimeSpan(0, 0, 10), timeService);

        var key1 = "test1";
        var testObject1 = 5;
        displacementCache.AddOrUpdate(key1, testObject1);
        timeService.Advance(TimeSpan.FromSeconds(3));
        displacementCache.AddOrUpdate(key1, testObject1);
        Assert.That(displacementCache.cache[key1].LastTime.Second, Is.EqualTo(timeService.GetNowTime().Second));
    }

    [Test]
    public void DisplacementCacheTest4()
    {
        var timeService = new TimeService(DateTime.Now);
        var displacementCache = new DisplacementCache<int>(3, new TimeSpan(0, 0, 2), timeService);

        var key1 = "test1";
        var testObject1 = 5;
        displacementCache.AddOrUpdate(key1, testObject1);

        var key2 = "test2";
        var testObject2 = 55;
        displacementCache.AddOrUpdate(key2, testObject2);
        timeService.Advance(TimeSpan.FromSeconds(3));

        var key3 = "test3";
        var testObject3 = 6;
        displacementCache.AddOrUpdate(key3, testObject3);

        var key4 = "test4";
        var testObject4 = 66;
        displacementCache.AddOrUpdate(key4, testObject4);

        displacementCache.ClearExpiredItems();
        Assert.That(displacementCache.cache.Count, Is.EqualTo(2));
    }

    [Test]
    public void DisplacementCacheTest5()
    {
        var timeService = new TimeService(DateTime.Now);
        var displacementCache = new DisplacementCache<int>(3, new TimeSpan(0, 0, 2), timeService);

        var key1 = "test1";
        var testObject1 = 5;
        displacementCache.AddOrUpdate(key1, testObject1);

        var key2 = "test2";
        var testObject2 = 55;
        displacementCache.AddOrUpdate(key2, testObject2);
        
        timeService.Advance(TimeSpan.FromSeconds(3));

        displacementCache.AddOrUpdate(key1, testObject1);
        displacementCache.AddOrUpdate(key2, testObject2);
        displacementCache.ClearExpiredItems();
        Assert.That(displacementCache.cache.Count, Is.EqualTo(2));
    }

    [Test]
    public void DisplacementCacheTest6()
    {
        var timeService = new TimeService(DateTime.Now);
        var displacementCache = new DisplacementCache<int>(2, new TimeSpan(0, 0, 10), timeService);

        var key1 = "test1";
        var testObject1 = 5;
        displacementCache.AddOrUpdate(key1, testObject1);

        var key2 = "test2";
        var testObject2 = 55;
        displacementCache.AddOrUpdate(key2, testObject2);

        var key3 = "test3";
        var testObject3 = 6;
        displacementCache.AddOrUpdate(key3, testObject3);

        var key4 = "test4";
        var testObject4 = 66;
        displacementCache.AddOrUpdate(key4, testObject4);

        var objects = new int[]
        {
            testObject3, testObject4
        };
        
        var keys = new string[]
        {
            key3, key4
        };
        
        Assert.That(displacementCache.cache.Count, Is.EqualTo(2));
        for (var i = 0; i < displacementCache.cache.Count; i++)
        {
            Assert.That(displacementCache.cache[keys[i]].Item, Is.EqualTo(objects[i]));
        }
    }
    
    [Test]
    public void DisplacementCacheTest7()
    {
        var timeService = new TimeService(DateTime.Now);
        var displacementCache = new DisplacementCache<int>(2, new TimeSpan(0, 0, 10), timeService);

        var key1 = "test1";
        var testObject1 = 5;
        displacementCache.AddOrUpdate(key1, testObject1);

        var key2 = "test2";
        var testObject2 = 55;
        displacementCache.AddOrUpdate(key2, testObject2);
        
        displacementCache.AddOrUpdate(key1, testObject1);
        var key3 = "test3";
        var testObject3 = 6;
        displacementCache.AddOrUpdate(key3, testObject3);

        var objects = new int[]
        {
            testObject3, testObject1
        };
        
        var keys = new string[]
        {
            key3, key1
        };
        
        Assert.That(displacementCache.cache.Count, Is.EqualTo(2));
        for (var i = 0; i < displacementCache.cache.Count; i++)
        {
            Assert.That(displacementCache.cache[keys[i]].Item, Is.EqualTo(objects[i]));
        }
    }

    [Test]
    public void DisplacementCacheTest8()
    {
        var timeService = new TimeService(DateTime.Now);
        var displacementCache = new DisplacementCache<int>(1, new TimeSpan(0, 0, 10), timeService);

        var key1 = "test1";
        var testObject1 = 5;
        displacementCache.AddOrUpdate(key1, testObject1);
        
        var key2 = "test2";
        var testObject2 = 55;
        displacementCache.AddOrUpdate(key2, testObject2);
        
        var key3 = "test3";
        var testObject3 = 6;
        displacementCache.AddOrUpdate(key3, testObject3);
        
        Assert.That(displacementCache.cache.Count, Is.EqualTo(1));
        Assert.That(displacementCache.cache[key3].Item, Is.EqualTo(testObject3));
        
    }
    
    [Test]
    public void DisplacementCacheTest9()
    {
        var timeService = new TimeService(DateTime.Now);
        var displacementCache = new DisplacementCache<int>(1, new TimeSpan(0, 0, 10), timeService);
        var allItems = displacementCache.GetAllCacheItems();
        
        Assert.That(allItems.Count, Is.EqualTo(0));
        Assert.That(allItems, Is.Not.Null);
    }
}