using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Dish
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int CountryId { get; set; }

    public int SeasonId { get; set; }

    public virtual Country Country { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual Season Season { get; set; }

    public virtual ICollection<Feedback> IdFeedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<GroupDish> IdGroups { get; set; } = new List<GroupDish>();
}
