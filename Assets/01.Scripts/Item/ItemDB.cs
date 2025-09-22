using System.Collections.Generic;

public class ItemDB 
{
    private readonly Dictionary<int, ItemDBs> _items;

    public ItemDB(Item so)
    {
        _items = new Dictionary<int, ItemDBs>();
        if (so != null && so.Itemsheet != null)
        {
            foreach (var item in so.Itemsheet)
            {
                if (item != null)
                {
                    _items[item.id] = item;
                }
            }
        }
    }

    public ItemDBs Get(int id)
    {
        _items.TryGetValue(id, out ItemDBs data);

        return data;
    }
}
