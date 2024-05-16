using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Calorie { get; set; }

    public double Price { get; set; }

    public string MeasureUnit { get; set; }

    public int CountForCalorie { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
