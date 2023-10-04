// Credit: https://ansohxxn.github.io/design%20pattern/chapter4/
using UnityEngine;

namespace FactoryPattern.Example.SimpleFactory
{
    public abstract class Beverage
    {
        public Beverage()
        {
            Debug.Log("Construct Beverage");
        }

        public abstract void Drink();
    }

    public class Coffee : Beverage
    {
        public Coffee()
        {
            Debug.Log("Construct Coffee");
        }

        public override void Drink()
        {
            Debug.Log("Drink Coffee");
        }
    }

    public class Tea : Beverage
    {
        public Tea()
        {
            Debug.Log("Construct Tea");
        }

        public override void Drink()
        {
            Debug.Log("Drink Tea");
        }
    }

    public class BeverageFactory
    {
        public static Beverage Create(string name)
        {
            switch (name)
            {
                default:
                    return null;

                case "Coffee":
                    return new Coffee();

                case "Tea":
                    return new Tea();
            }
        }
    }

    public class FactoryPatternExample1 : MonoBehaviour
    {
        private void Start()
        {
            Beverage b1 = BeverageFactory.Create("Coffee");
            Beverage b2 = BeverageFactory.Create("Tea");
            b1.Drink();
            b2.Drink();

            // Output:
            // Construct Beverage
            // Construct Coffee
            // Construct Beverage
            // Construct Tea
            // Drink Coffee
            // Drink Tea
        }
    }
}