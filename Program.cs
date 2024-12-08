using Inventory.src.Entities;
using Inventory.src.Service;

Management management = Management.Instance;
Item item1 = new Item("0001", "Laptop", 10);
Item item2 = new Item("0002", "Mouse", 25);
Item item3 = new Item("0003", "Keyboard", 15);
Item item4 = new Item("0004", "Monitor", 8);
Item item5 = new Item("0005", "Headphones", 12);
Item item6 = new Item("0006", "Printer", 5);
Item item7 = new Item("0007", "Tablet", 20);
Item item8 = new Item("0008", "Smartphone", 18);
Item item9 = new Item("0009", "External HDD", 7);
Item item10 = new Item("0010", "USB Drive", 30);

management.MaxCapacity = 160;

management.AddItem(item1, 10);
management.AddItem(item2, 25);
management.AddItem(item3, 15);
management.AddItem(item4, 8);
management.AddItem(item5, 12);
management.AddItem(item6, 5);
management.AddItem(item7, 20);
management.AddItem(item8, 18);
management.AddItem(item9, 7);
management.AddItem(item10, 30);


management.ViewInventory();
management.PrintInventory(management);



