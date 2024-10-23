class program
{
    static void Main()
    {
        Inventory inventory = new Inventory();

        Item apple = new FoodItem("Apple", 5, DateTime.Now.AddDays(5));
        Item dåse = new NonFoodItem("Dåse", 10, new string[] { "butter", "cream" });
        
        inventory.AddItem(apple);
        inventory.AddItem(dåse);

        inventory.PrintInventory();
        
    }
}