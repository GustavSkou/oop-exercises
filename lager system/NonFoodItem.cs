class NonFoodItem : Item
{
    public string[] materials;

    public NonFoodItem(string name, double price, string[] materialsValue) : base(name, price)
    {
        materials = materialsValue;
    }

    public string[] GetMaterials()
    {
        return materials;
    }

    public override string ToString()
    {
        string m = "[";
        for (int i = 0; i < materials.Length; i++)
        {
            m += (i == 0 ? "" : ",") + materials[i];
        }
        m += "]";
        return "NonFoodItem name='" + GetName() + "' price='" + GetPrice() + "' materials='" + m + "'";
    }
}