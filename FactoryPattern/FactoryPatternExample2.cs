// Credit: https://github.com/QianMo/Unity-Design-Pattern/blob/master/Assets/Creational%20Patterns/Factory%20Method%20Pattern/Example1/FactoryMethodPatternExample1.cs
using System.Collections.Generic;
using UnityEngine;

namespace FactoryPattern.Example.FactoryMethod
{
    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    public abstract class Ingredient { }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Oil         : Ingredient { }
    public class Garlic      : Ingredient { }
    public class Kimchi      : Ingredient { }
    public class SoySauce    : Ingredient { }
    public class Salt        : Ingredient { }
    public class Rice        : Ingredient { }
    public class Peperoncino : Ingredient { }
    public class Parsely     : Ingredient { }
    public class PastaNoodle : Ingredient { }

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    public abstract class Recipe
    {
        public List<Ingredient> Ingredients => ingredients;

        protected List<Ingredient> ingredients = new List<Ingredient>();

        // Constructor calls abstract Factory method
        public Recipe()
        {
            this.MakeIngredients();
        }

        // Factory Method
        public abstract void MakeIngredients();
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class KimchiFriedRice : Recipe
    {
        // Factory Method implementation
        public override void MakeIngredients()
        {
            ingredients.Add(new Oil());
            ingredients.Add(new Garlic());
            ingredients.Add(new Kimchi());
            ingredients.Add(new SoySauce());
            ingredients.Add(new Salt());
            ingredients.Add(new Rice());
        }
    }

    public class Spaghetti : Recipe
    {
        // Factory Method implementation
        public override void MakeIngredients()
        {
            ingredients.Add(new Oil());
            ingredients.Add(new Garlic());
            ingredients.Add(new Peperoncino());
            ingredients.Add(new PastaNoodle());
            ingredients.Add(new Parsely());
        }
    }

    public class FactoryPatternExample2 : MonoBehaviour
    {
        private void Start()
        {
            // Note: constructors call Factory Method
            Recipe[] recipes = new Recipe[2];

            recipes[0] = new KimchiFriedRice();
            recipes[1] = new Spaghetti();

            // Display recipe ingredients
            foreach (Recipe recipe in recipes)
            {
                Debug.Log("\n" + recipe.GetType().Name + "--");
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    Debug.Log(" " + ingredient.GetType().Name);
                }
            }
        }
    }
}