using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class GroupDish
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int CountryId { get; set; }

    public int SeasonId { get; set; }

    public virtual Country Country { get; set; }

    public virtual Season Season { get; set; }

    public virtual ICollection<Dish> IdDishes { get; set; } = new List<Dish>();
}
