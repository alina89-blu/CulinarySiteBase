using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CulinarySite
{

    public class Recipe: BaseEntity
    {       
        public string Name { get; set; }
        public int ServingsNumber { get; set; }
        public DateTime CookingTime { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public string Content { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<OrganicMatter> OrganicMatters { get; set; } = new List<OrganicMatter>();       
        public List<CookingStage> CookingStages { get; set; } = new List<CookingStage>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public int? BookId { get; set; }
        public Book Book { get; set; }
        public int? DishId { get; set; }
        public Dish Dish { get; set; }
    }

    public class CookingStage : BaseEntity
    {       
        public string Content { get; set; }

        public int? RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
    }
    public class Dish : BaseEntity
    {
        public DishCategory Category { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public Image Image { get; set; }
    }
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public double Quantity { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }

    public class Subscriber : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public int? SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }
    }

    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreationYear { get; set; }//

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public List<Image> Images { get; set; } = new List<Image>();
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
    }
    public class Address : BaseEntity
    {
        public string Name { get; set; }

        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }

        public List<Telephone> Telephones { get; set; } = new List<Telephone>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }

    public class Telephone : BaseEntity
    {
        public string Number { get; set; }

        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }

    public class OrganicMatter : BaseEntity
    {
        public OrganicMatterName Name { get; set; }
        public Unit Unit { get; set; }
        public double Quantity { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();     
    }
    public class CulinaryChannel : BaseEntity
    {
        public string Name { get; set; }

        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
    public class Episode : BaseEntity
    {
        public string Name { get; set; }

        public int? CulinaryChannelId { get; set; }
        public CulinaryChannel CulinaryChannel { get; set; }
        public Image Image { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
    public class Image : BaseEntity
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();        
        public int? DishId { get; set; }
        public Dish Dish { get; set; }
        public int? EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public int? CookingStageId { get; set; }
        public CookingStage CookingStage { get; set; }
    }
 
    public class Tag : BaseEntity
    {
        public string Text { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();       
        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
    public class BaseEntity
    {
        public int Id { get; set; }

    }
    public enum DishCategory
    {
        Soups,
        Snacks,
        SecondDishes,
        Salads,
        Pizza,
        Pies,
        CakesAndPastries,
        SaucesAndCondiments,
        Drinkables,
        Desserts,
        Pancakes
    }
    public enum DifficultyLevel
    {
        Easy,
        VeryEasy,
        Average,
        AboveAverage,
        Difficult
    }
    public enum Unit
    {
        Piece,
        Kilogram,
        Gram,
        Liter,
        Milliliter,
        Calorie
    }
    public enum OrganicMatterName
    {
        Calories,
        Carbohydrates,
        Sugar,
        Grease,
        Protein
    }

}
