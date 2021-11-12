using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CulinarySite
{
    class Program
    {
        static void Main(string[] args)
        {
           using (ApplicationContext db=new ApplicationContext())
            {
                Ingredient carrot = new Ingredient { Name = "carrot" };
                Ingredient apple = new Ingredient { Name = "apple" };
                Ingredient potatoe = new Ingredient { Name = "potatoe" };

                db.Ingredients.AddRange(carrot, apple, potatoe);
                db.SaveChanges();

                Recipe recipe1 = new Recipe { Name = "Гороховый суп Альтамура", Ingredients = new List<Ingredient> { carrot, apple } };
                Recipe recipe2 = new Recipe { Name = "Томатный суп с хлебом", Ingredients = new List<Ingredient> { carrot } };
                recipe2.Ingredients.Add(potatoe);
                db.Recipes.AddRange(recipe1, recipe2);
                db.SaveChanges();

                Dish dish1 = new Dish { Category = DishCategory.Drinkables };
                Dish dish2 = new Dish { Category = DishCategory.CakesAndPastries };
                dish1.Recipes.Add(recipe1);
                dish2.Recipes.Add(recipe2);
                db.Dishes.AddRange(dish1, dish2);
                db.SaveChanges();


                var dishes = db.Dishes.Include(x => x.Recipes).ThenInclude(x => x.Ingredients).ToList();
                foreach (var dishe in dishes)
                {
                    Console.WriteLine($"Id {dishe.Id}- {dishe.Category}:");
                    foreach (Recipe recipe in dishe.Recipes)
                    {
                        Console.WriteLine($"Id {recipe.Id}{recipe.Name}");
                        foreach (Ingredient ingredient in recipe.Ingredients)
                        {
                            Console.WriteLine($"Id {ingredient.Id}{ingredient.Name}");
                        }
                        Console.WriteLine("-------------");
                    }



                }

            }
          
        }
    }
}
