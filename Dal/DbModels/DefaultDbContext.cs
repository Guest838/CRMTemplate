using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.DbModels;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalorieCount> CalorieCounts { get; set; }

    public virtual DbSet<CaloriePrice> CaloriePrices { get; set; }

    public virtual DbSet<CookingWay> CookingWays { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<GeoMenu> GeoMenus { get; set; }

    public virtual DbSet<GroupDish> GroupDishes { get; set; }

    public virtual DbSet<ModDish> ModDishes { get; set; }

    public virtual DbSet<NumberRecipesByGroup> NumberRecipesByGroups { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeCheck> RecipeChecks { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6G3NM5G;Initial Catalog=CookBook;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalorieCount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CalorieCount");

            entity.Property(e => e.CountForCalorie).HasColumnName("Count_for_calorie");
            entity.Property(e => e.MeasureUnit)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Measure_unit");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<CaloriePrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CaloriePrice");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<CookingWay>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("Cooking_Way");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Kind)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("Country");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescriptionFamousDishes)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("Description_famous_dishes");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("Dish");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountryId).HasColumnName("Country_ID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.SeasonId).HasColumnName("Season_ID");

            entity.HasOne(d => d.Country).WithMany(p => p.Dishes)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_Country_Dish");

            entity.HasOne(d => d.Season).WithMany(p => p.Dishes)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_Season_Dish");

            entity.HasMany(d => d.IdFeedbacks).WithMany(p => p.IdDishes)
                .UsingEntity<Dictionary<string, object>>(
                    "FeedbackDish",
                    r => r.HasOne<Feedback>().WithMany()
                        .HasForeignKey("IdFeedback")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_id_Product_Feedback_Dish"),
                    l => l.HasOne<Dish>().WithMany()
                        .HasForeignKey("IdDish")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_id_Dish_Feedback_Dish"),
                    j =>
                    {
                        j.HasKey("IdDish", "IdFeedback").IsClustered(false);
                        j.ToTable("Feedback_Dish");
                        j.IndexerProperty<int>("IdDish").HasColumnName("ID_Dish");
                        j.IndexerProperty<int>("IdFeedback").HasColumnName("ID_Feedback");
                    });

            entity.HasMany(d => d.IdGroups).WithMany(p => p.IdDishes)
                .UsingEntity<Dictionary<string, object>>(
                    "DishWithGroup",
                    r => r.HasOne<GroupDish>().WithMany()
                        .HasForeignKey("IdGroup")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_id_Group_Dish_with_Group"),
                    l => l.HasOne<Dish>().WithMany()
                        .HasForeignKey("IdDish")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_id_Dish_Dish_with_Group"),
                    j =>
                    {
                        j.HasKey("IdDish", "IdGroup").IsClustered(false);
                        j.ToTable("Dish_with_Group");
                        j.IndexerProperty<int>("IdDish").HasColumnName("ID_Dish");
                        j.IndexerProperty<int>("IdGroup").HasColumnName("ID_Group");
                    });
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("Feedback");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);
        });

        modelBuilder.Entity<GeoMenu>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GeoMenu");

            entity.Property(e => e.CountryName).HasMaxLength(50);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<GroupDish>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("Group_Dish");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountryId).HasColumnName("Country_ID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.SeasonId).HasColumnName("Season_ID");

            entity.HasOne(d => d.Country).WithMany(p => p.GroupDishes)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_Country_Group_Dish");

            entity.HasOne(d => d.Season).WithMany(p => p.GroupDishes)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_Season_Group_Dish");
        });

        modelBuilder.Entity<ModDish>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("Mod_Dish");

            entity.HasIndex(e => e.PosInMenu, "IX").IsUnique();

            entity.HasIndex(e => new { e.PosInMenu, e.PosInCat }, "IX_PRODUCT_Calorie_Price");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.PosInCat)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Pos_in_Cat");
            entity.Property(e => e.PosInMenu)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Pos_in_Menu");
        });

        modelBuilder.Entity<NumberRecipesByGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NumberRecipesByGroup");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.КоличествоБлюд).HasColumnName("Количество блюд");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountForCalorie).HasColumnName("Count_for_calorie");
            entity.Property(e => e.MeasureUnit)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Measure_unit");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => new { e.IdDish, e.IdProduct, e.CookingWayId }).IsClustered(false);

            entity.ToTable("Recipe");

            entity.Property(e => e.IdDish).HasColumnName("ID_Dish");
            entity.Property(e => e.IdProduct).HasColumnName("ID_Product");
            entity.Property(e => e.CookingWayId).HasColumnName("Cooking_Way_id");
            entity.Property(e => e.ProductQuantity).HasColumnName("Product_quantity");

            entity.HasOne(d => d.CookingWay).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.CookingWayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_Way_Cooking_Recipe");

            entity.HasOne(d => d.IdDishNavigation).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.IdDish)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_Dish_Recipe");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_Product_Recipe");
        });

        modelBuilder.Entity<RecipeCheck>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("RecipeCheck");

            entity.Property(e => e.DishName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProdName).HasMaxLength(50);
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("Season");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MonthEnd).HasColumnName("Month_End");
            entity.Property(e => e.MonthStart).HasColumnName("Month_Start");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Login, "Unique_Users_Login").IsUnique();

            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
