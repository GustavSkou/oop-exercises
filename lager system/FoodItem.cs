class FoodItem : Item
{
    private DateTime expiresAt;

    public FoodItem(string name, double price, DateTime expiresAtValue) : base(name, price)
    {
        expiresAt = expiresAtValue;
    }

    public DateTime GetExpiresAt()
    {
        return expiresAt;
    }

    public override string ToString()
    {
        return "FoodItem name='" + GetName() + "'" + " price='" + GetPrice() + "'" + " expiresAt='" + GetExpiresAt() + "'";
    }
}