using System.Collections.Generic;
[System.Serializable]
public class Order
{
    public List<Ingredient> ingredients;
    public string OrderDetails { get; set; }
    public bool fulfilled = false;

    public Order(List<Ingredient> ingredients)
    {
        this.ingredients = ingredients;
    }
}