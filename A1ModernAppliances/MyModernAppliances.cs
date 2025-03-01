﻿using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.Write("Enter the item number of an appliance: ");

            // Create long variable to hold item number
            long itemNumber;

            // Get user input as string and assign to variable.
            // Convert user input from string to long and store as item number variable.
            itemNumber = Convert.ToInt64(Console.ReadLine());

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            Appliance foundAppliance = null;

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test appliance item number equals entered item number
                if (appliance.ItemNumber == itemNumber)
                {

                    // Assign appliance in list to foundAppliance variable
                    foundAppliance = appliance;

                    // Break out of loop (since we found what need to)
                    break;
                }

            }

            // Test appliance was not found (foundAppliance is null)
            if (foundAppliance == null)
            {
                // Write "No appliances found with that item number."\
                Console.WriteLine("No appliances found with that item number.");
                Console.WriteLine();
            }


            // Otherwise (appliance was found)
            else
            {
                // Test found appliance is available
                if (foundAppliance.IsAvailable)
                {
                    // Checkout found appliance
                    foundAppliance.Checkout();

                    // Write "Appliance has been checked out."
                    Console.WriteLine("Appliance has been checked out.");

                    Console.WriteLine();
                }
                // Otherwise (appliance isn't available)
                else
                {
                    // Write "The appliance is not available to be checked out."
                    Console.WriteLine("The appliance is not available to be checked out.");
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.Write("Enter brand to search for:");

            // Create string variable to hold entered brand
            string brand;
            // Get user input as string and assign to variable.
            brand = Console.ReadLine();

            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();
            // Iterate through loaded appliances
            foreach (Appliance appliance in Appliances)
                // Test current appliance brand matches what user entered
                if (appliance.Brand == brand)
                    // Add current appliance in list to found list
                    found.Add(appliance);


            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            int? numOfDoors = null;
            bool inputPossible = false;
            while (inputPossible is false)
            {
                Console.WriteLine("Possible Options:\n0 - Any\n2 - Double doors\n3 - Three doors\n4 - Four doors\nEnter number of doors: ");
                numOfDoors = int.Parse(Console.ReadLine());

                switch (numOfDoors){
                    case (0):
                        inputPossible = true;
                        break;
                    case (2):
                        inputPossible = true;
                        break;
                    case (3):
                        inputPossible = true;
                        break;
                    case (4):
                        inputPossible = true;
                        break;
                    default:
                        break;
                }
            }

            List<Appliance> foundRefrigerators = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if(appliance is Refrigerator)
                {
                    Refrigerator refrigerator = (Refrigerator)appliance;
                    if (numOfDoors == 0 || numOfDoors == refrigerator.Doors)
                    {
                        foundRefrigerators.Add(refrigerator);
                    }
                }
            }

            DisplayAppliancesFromList(foundRefrigerators, 0);

        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            string? voltInputed = null;
            int voltToFind = 0;
            bool inputValid = false;
            while (inputValid is false)
            {
                Console.WriteLine("Possible Options:\n0 - Any\n1 - 18 volt\n2 - 24 Volt\nEnter voltage: ");
                voltInputed = Console.ReadLine();

                switch (voltInputed)
                {
                    case ("0"):
                        voltToFind = 0;
                        inputValid = true;
                        break;

                    case ("1"):
                        voltToFind = 18;
                        inputValid = true;
                        break;

                    case ("2"):
                        voltToFind = 24;
                        inputValid = true;
                        break;

                    default:
                        Console.WriteLine("Input invalid");
                        break;
                }
            }
            List<Appliance> foundVacuums = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;
                    if (voltToFind == 0 || voltToFind == vacuum.BatteryVoltage)
                    {
                        foundVacuums.Add(vacuum);
                    }
                }
            }
            DisplayAppliancesFromList(foundVacuums, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()

        {

            string roomTypeDesired = "";

            char roomType = '0';

            bool inputValid = false;

            while (inputValid is false)

            {

                Console.WriteLine("Possible options:\n0 - Any\n1 - Kitchen\n2 - Work site\nEnter room type:");

                roomTypeDesired = Console.ReadLine();

                switch (roomTypeDesired)

                {

                    case "0":

                        roomType = 'A';

                        inputValid = true;

                        break;

                    case "1":

                        roomType = 'K';

                        inputValid = true;

                        break;

                    case "2":

                        roomType = 'W';

                        inputValid = true;

                        break;

                    default:

                        Console.WriteLine("Invalid input");

                        break;

                }

            }

            List<Appliance> foundMicrowaves = new List<Appliance>();

            foreach (Appliance appliance in Appliances)

            {

                if (appliance is Microwave)

                {

                    Microwave microwave = (Microwave)appliance;

                    if (roomType == 'A' || roomType == microwave.RoomType)

                    {

                        foundMicrowaves.Add(microwave);

                    }

                }

            }

            DisplayAppliancesFromList(foundMicrowaves, 0);

        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options:");

            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");

            // Write "Enter sound rating:"
            Console.WriteLine("Enter sound rating:");

            // Get user input as string and assign to variable
            string option = Console.ReadLine();

            // Create variable that holds sound rating
            string soundRating = "";

            // Test input is "0"
            // Assign "Any" to sound rating variable
            // Test input is "1"
            // Assign "Qt" to sound rating variable
            // Test input is "2"
            // Assign "Qr" to sound rating variable
            // Test input is "3"
            // Assign "Qu" to sound rating variable
            // Test input is "4"
            // Assign "M" to sound rating variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method
            switch (option)
            {
                case "0":
                    soundRating = "Any";
                    break;
                case "1":
                    soundRating = "Qt";
                    break;
                case "2":
                    soundRating = "Qr";
                    break;
                case "3":
                    soundRating = "Qu";
                    break;
                case "4":
                    soundRating = "M";
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    DisplayDishwashers();
                    break;
            }

            // Create variable that holds list of found appliances
            List<Appliance> found = new List<Appliance>();
            //foreach (Appliance appliance in Appliances)
            //{
            //    found.Add(appliance);
            //}

            // Loop through Appliances
            // Test if current appliance is dishwasher
            // Down cast current Appliance to Dishwasher
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;
                    if (soundRating == "Any" || soundRating == dishwasher.SoundRating)
                    {
                        found.Add(dishwasher);
                    }
                }
            }

          
            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Enter number of items: "
            Console.Write("Enter number of items: ");

            // Get user input as string and assign to variable
            string items = Console.ReadLine();

            // Convert user input from string to int
            int num = Convert.ToInt32(items);

            // Create variable to hold list of found appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through appliances
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                found.Add(appliance);
            }

            // Randomize list of found appliances
            // found.Sort(new RandomComparer());
            found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
            DisplayAppliancesFromList(found, num);
        }
    }
}
