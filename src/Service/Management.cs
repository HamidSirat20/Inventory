using Inventory.src.Entities;

namespace Inventory.src.Service;

public class Management
{
    public Dictionary<string, Item> items { get; private set; } = new();
    private int _maxCapacity;
    private int _capacityLeft;
    public int MaxCapacity
    {
        set
        {
            _maxCapacity = value;
            _capacityLeft = value;
        }
        get { return _maxCapacity; }
    }
    public int CapacityLeft
    {
        get { return _capacityLeft; }
    }

    private static Management _instance = null;
    private Management() { }
    public static Management Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Management();
            }
            return _instance;
        }
    }

    public bool AddItem(Item item, int itemQuantity)
    {
        if (itemQuantity < _capacityLeft)
        {
            items.Add(item.Barcode, item);
            _capacityLeft -= itemQuantity;
            return true;
        }
        else
        {
            System.Console.WriteLine("Inventory capacity is full.");
            return false;
        }
    }

    public bool RemoveItem(string barcode)
    {
        var foundItem = items.FirstOrDefault(x => x.Value.Barcode == barcode);
        if (foundItem.Value != null)
        {
            items.Remove(foundItem.Key);
            _capacityLeft -= foundItem.Value.Quantity;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IncreaseQuantity(int quantity, string barcode)
    {
        var foundItem = items.FirstOrDefault(x => x.Value.Barcode == barcode);
        if (foundItem.Value != null)
        {
            foundItem.Value.IncreaseQuantity(quantity);
            _capacityLeft += quantity;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DecreaseQuantity(int quantity, string barcode)
    {
        var foundItem = items.FirstOrDefault(x => x.Value.Barcode == barcode);
        if (foundItem.Value != null)
        {
            foundItem.Value.DecreaseQuantity(quantity);
            _capacityLeft -= quantity;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ViewInventory()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item.Value.PrintItemInfo());
        }
    }

    public void PrintItem(string barcode)
    {
        var foundItem = items.FirstOrDefault(x => x.Value.Barcode == barcode);
        Console.WriteLine(foundItem.Value.PrintItemInfo());
    }

    public void PrintInventory(Management management)
    {

        string info = string.Format("Amount of unique items: {0}, Total number of items: {1}", management.items.Count, _maxCapacity - _capacityLeft);
        System.Console.WriteLine(info);
    }
}
