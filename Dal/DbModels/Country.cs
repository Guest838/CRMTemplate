using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string DescriptionFamousDishes { get; set; }

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    public virtual ICollection<GroupDish> GroupDishes { get; set; } = new List<GroupDish>();
}
