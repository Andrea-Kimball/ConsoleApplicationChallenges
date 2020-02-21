using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuRepository
    {
        private List<Menu> _listOfFoodOptions = new List<Menu>();
        //Create
        public void AddFoodToList(Menu meal)
        {
            _listOfFoodOptions.Add(meal);
        }
        //Read
        public List<Menu> GetMenuList()
        {
            return _listOfFoodOptions;
        }
        //Update
        public bool UpdateExistingMenu(string originalMeal, Menu newMeal)
        {
            //find the menu item
            Menu oldMeal = GetMealByName(originalMeal);

            //update the menu item
            if (oldMeal != null)
            {
                oldMeal.ItemNumber = newMeal.ItemNumber;
                oldMeal.Name = newMeal.Name;
                oldMeal.Description = newMeal.Description;
                oldMeal.Price = newMeal.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveMealFromList(string name)
        {
            Menu meal = GetMealByName(name);
            if (meal == null)
            {
                return false;
            }
            int initialCount = _listOfFoodOptions.Count;
            _listOfFoodOptions.Remove(meal);

            if (initialCount > _listOfFoodOptions.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper Method
        public Menu GetMealByName(string name)
        {
            foreach (Menu meal in _listOfFoodOptions) 
            {
                if (meal.Name.ToLower() == name.ToLower())
                {
                    return meal;
                }
            }
            return null;
        }
    }
}
