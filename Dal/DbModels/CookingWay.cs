using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class CookingWay
{
    public int Id { get; set; }

    public string Kind { get; set; }

    public TimeSpan Duration { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
