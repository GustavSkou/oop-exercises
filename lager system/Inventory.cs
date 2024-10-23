class Inventory
{
    List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item itemToRemove)
    {
        for (int index = 0; index < items.Count; index++)
        {
            if (items[index].GetName() == itemToRemove.GetName())
            {
                items[index] = null;
            }
        }
    }

    public double GetInventoryValue()
    {
        double inventoryValue = 0;
        foreach (Item item in items)
        {
            inventoryValue = inventoryValue + item.GetPrice();
        }
        Console.WriteLine(inventoryValue);
        return inventoryValue;
    }

    public void PrintInventory()
    {
        foreach(Item item in items)
        {
            Console.WriteLine(item.GetName());
        }
    }
}