using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class RecipeCheck
{
    public int Id { get; set; }

    public string DishName { get; set; }

    public string ProdName { get; set; }

    public double? ProdQuan { get; set; }
}
