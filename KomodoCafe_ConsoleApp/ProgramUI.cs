using KomodoCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_ConsoleApp
{
    class ProgramUI
        
    {
        private MenuRepository _menuItemRepo = new MenuRepository();

        //method that starts the application
        public void Run()
        {
            SeedMenuList();
            ViewMenu();
        }
        //Menu
        private void ViewMenu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                
                //display options
                Console.WriteLine("Select an option by number:\n" +
                    "1. Create new menu option \n" +
                    "2. View all menu options \n" +
                    "3. View options by name \n" +              
                    "4. Delete an existing menu option\n" +
                    "5. Exit");

                //prompt the user 
                string input = Console.ReadLine();

                //evaluate users input and act accordingly
                switch (input)
                {
                    case "1":
                        //create new menu option
                        CreateNewOption();
                        break;
                    case "2":
                        //View all menu options
                        DisplayAllMenuItems();
                        break;
                    case "3":                    
                        //View options by name
                        ViewMenuOptionsByName();
                        break;
                    
                    case "4":
                        //delete an existing menu option
                        DeleteMenuOptions();
                        break;
                    case "5":
                        //exit
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;

                }
                Console.WriteLine("please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }

        }
        //Create new menu option
        private void CreateNewOption()
        {
            Console.Clear();
            Menu newMenu = new Menu();

            //Item Number
            Console.WriteLine("Enter the Item Number");
            string ItemasString = Console.ReadLine();
            newMenu.ItemNumber = int.Parse(ItemasString);

            //Name
            Console.WriteLine("Enter the name of the Menu Item");
            newMenu.Name = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the description of the menu item");
            newMenu.Description = Console.ReadLine();

            //Price
            Console.WriteLine("Enter the price of this item");
            string PriceAsString = Console.ReadLine();
            newMenu.Price = double.Parse(PriceAsString);

            _menuItemRepo.AddFoodToList(newMenu);

        }
        //View all menu options
        private void DisplayAllMenuItems()
        {
            List<Menu> listOfMenuItems = _menuItemRepo.GetMenuList();

            foreach(Menu meal in listOfMenuItems)
            {
                Console.WriteLine($"The menu item number is: {meal.ItemNumber} \n" +
                    $"Name: {meal.Name} \n" +
                    $"Description: {meal.Description}" );
            }

        }
        //View options by name
        private void ViewMenuOptionsByName()
        {
            Console.Clear();
            //prompt the user to give a menu item
            Console.WriteLine("Enter the name of the menu item:");

            //get the users input
            string name = Console.ReadLine();

            //find content by title
           Menu meal =  _menuItemRepo.GetMealByName(name);


            //display content if it isnt null
            if(meal != null)
            {
                Console.WriteLine($"The menu item number is: {meal.ItemNumber} \n" +
                    $"Name: {meal.Name} \n" +
                    $"Description: {meal.Description} \n" +
                    $"Price: ${meal.Price}");
            }
            else
            {
                Console.WriteLine("No item by that name could be found");
            }
        }
                
        //delete an existing menu option
        private void DeleteMenuOptions()
        {
            //prompt the user for the item
            DisplayAllMenuItems();
            Console.WriteLine("\nEnter the name of the item you would like to remove:");
            string input = Console.ReadLine();

            //call the delete method
            bool wasdeleted = _menuItemRepo.RemoveMealFromList(input);


            //confirm deleted
            if (wasdeleted)
            {
                Console.WriteLine("Item was successfully deleted");
            }

            //otherwise state it couldnt be deleted
            else
            {
                Console.WriteLine("item could not be deleted");
            }
        }
        private void SeedMenuList()
        {
            Menu Burger = new Menu(1, "Burger", "Simple burger, no cheese", 0.79);
            Menu ChickenSandwich = new Menu(2, "Chicken Sandwich", "Chicken Sandwich", 1.00);
            Menu ChickenNuggets = new Menu(3, "Chicken Nuggets", "Five chicken nuggets", 1.50);

            _menuItemRepo.AddFoodToList(Burger);
            _menuItemRepo.AddFoodToList(ChickenSandwich);
            _menuItemRepo.AddFoodToList(ChickenNuggets);
        }
    }
}
