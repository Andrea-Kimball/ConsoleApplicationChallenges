using KomodoBadge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_ConsoleApp
{
    public class ProgramUI
    {

        private BadgeRepository _badgeRepository = new BadgeRepository();
        public void Run()
        {
            SeedContent();
            ViewMenu();
        }
        //Menu
        private void ViewMenu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {

                //display options
                Console.WriteLine("Hello Security Admin. What would you like to do?:\n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. Delete a badge" +
                    "4. List all badges \n" +
                    "5. Exit");
                //prompt the user 
                string input = Console.ReadLine();

                //evaluate users input and act accordingly
                switch (input)
                {
                    case "1":
                        //create new badge
                        CreateNewBadge();
                        break;
                    case "2":
                        //Edit a badge
                        EditBadge();
                        break;
                    case "3":
                        //Delete a badge
                        DeleteDoors();
                        break;
                    case "4":
                        //List all badges
                        ShowAllBadges();
                        break;
                    case "5":
                        //exit
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            }

        }
        //create a new badge

        public void CreateNewBadge()
        {
            Console.Clear();
            Badges newBadge = new Badges();

            //Badge Number
            Console.WriteLine("Enter the badge number:");
            string ItemasString = Console.ReadLine();
            newBadge.BadgeID = int.Parse(ItemasString);

            Console.WriteLine("List a door that it needs access to:");
            var ItemAsString = Console.ReadLine();

            bool CanRun = true;
            do
            {
                Console.WriteLine("Do you want to add access to another door? (y/n)");
                string Userinput = Console.ReadLine();
                switch (Userinput)
                {
                    case "n":
                        CanRun = false;
                        break;
                }
            } while (CanRun == true);


            _badgeRepository.AddBadge(newBadge);
            Console.WriteLine("press any key to continue");
            Console.ReadKey();

        }

        //show a list with all badge numbers and door access
        private void ShowAllBadges()

        {
            var listOfBadges = _badgeRepository.GetBadgeList();

            foreach (var badge in listOfBadges)
            {
                Console.WriteLine($"The Badge ID is : {badge.Key} \n" +
                    $"This badge currently has access to these doors: {badge.Value}");
            }

        }

        //update doors on an existing badge
        private void EditBadge()            
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            
            Console.WriteLine($"The Badge ID is : {badge.Key} \n" +
                    $"This badge currently has access to these doors: {badge.Value}");
            bool CanRun = true;
            do
            {
                Console.WriteLine("Do you want to add access to another door? (y/n)");
                string Userinput = Console.ReadLine();
                switch (Userinput)
                {
                    case "n":
                        CanRun = false;
                        break;
                }
            } while (CanRun == true);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }
        // delete all doors from an existing badge
        private void DeleteDoors()
        {
            //prompt the user for the item
           Console.WriteLine("\nEnter the ID number of the badge you would like to remove:");
           string ItemasString = Console.ReadLine();
            var badgeToRemove  = double.Parse(ItemasString);

            //call the delete method
            bool wasdeleted = _badgeRepository.RemoveBadge(badgeToRemove);


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
        

        private void SeedContent()
        {
            List<string> door12345 = new List<string>() { "A7" };
            List<string> door22345 = new List<string>() { "A1", "A4", "B1", "B2" };
            List<string> door32345 = new List<string>() { "A4", "A5" };

            Badges badge1 = new Badges(12345, door12345);
            Badges badge2 = new Badges(22345, door22345);
            Badges badge3 = new Badges(32345, door32345);


            _badgeRepository.AddBadge(badge1);
            _badgeRepository.AddBadge(badge2);
            _badgeRepository.AddBadge(badge3);
        }
    }
}

