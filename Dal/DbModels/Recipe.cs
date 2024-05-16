using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Recipe
{
    public int IdProduct { get; set; }

    public int IdDish { get; set; }

    public int CookingWayId { get; set; }

    public double ProductQuantity { get; set; }

    public virtual CookingWay CookingWay { get; set; }

    public virtual Dish IdDishNavigation { get; set; }

    public virtual Product IdProductNavigation { get; set; }
}
