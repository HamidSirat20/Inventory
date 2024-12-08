using System.Runtime.InteropServices;

namespace Inventory.src.Entities;

public class Item
{
    private string _barcode;
    private string _name;
    private int _quantity;

    public Item(string barcode, string name, int quantity)
    {
        _barcode = barcode;
        _name = name;
        _quantity = quantity;
    }
    public string Barcode
    {
        get
        {
            return _barcode;
        }
        set
        {
            _barcode = value;
        }
    }
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Quantity cannot be negative!");
            }
            _quantity = value;
        }
    }
    public int IncreaseQuantity(int quantity)
    {
        return _quantity += quantity;
    }
    public int DecreaseQuantity(int quantity)
    {
        return _quantity -= quantity;
    }

    public string PrintItemInfo()
    {
        string info = string.Format("Barcode: {0} , Name: {1}, Quantity: {2}", _barcode, _name, _quantity);
        return info;
    }

}
