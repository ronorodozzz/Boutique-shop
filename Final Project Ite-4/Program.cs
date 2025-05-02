using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            void DrawBorder()
            {
                int width = Console.WindowWidth;
                int height = Console.WindowHeight;

                // Top border
                for (int i = 0; i < width; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("═");
                }

                // Bottom border
                for (int i = 0; i < width; i++)
                {
                    Console.SetCursorPosition(i, height - 1);
                    Console.Write("═");
                }

                // Left and right borders
                for (int i = 1; i < height - 1; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("║");
                    Console.SetCursorPosition(width - 1, i);
                    Console.Write("║");
                }

            }
            DrawBorder();
            string bannerText = @"
                                         ____   __   _  _   __    ___   ___  __            
                                        (    \ /  \ ( \/ ) / _\  / __) / __)/  \          
                                         ) D ((  O )/ \/ \/    \( (_ \( (__(  O )        
                                        (____/ \__/ \_)(_/\_/\_/ \___/ \___)\__/         
                    ";
            string bannerText2 = @"     
                             ____   __  ____  __  __   _  _  ____    ____  _  _   __  ____ 
                             (  _ \ /  \(_  _)(  )/  \ / )( \(  __)  / ___)/ )( \ /  \(  _ \
                               ) _ ((  O ) )(   )((  O )) \/ ( ) _)   \___ \) __ ((  O )) __/
                              (____/ \__/ (__) (__)\__\)\____/(____)  (____/\_)(_/ \__/(__)  
";
            string bannerText3 = @"
  __  ____  ____  _  _  ____ 
 (  )(_  _)(  __)( \/ )/ ___)
  )(   )(   ) _) / \/ \\___ \
 (__) (__) (____)\_)(_/(____/
";
            string bannerText4 = @"
 ____  ____  ___  ____  __  ____  ____ 
(  _ \(  __)/ __)(  __)(  )(  _ \(_  _)
 )   / ) _)( (__  ) _)  )(  ) __/  )(  
(__\_)(____)\___)(____)(__)(__)   (__) 
";

            Console.SetCursorPosition(70, 8);
            Console.Write(bannerText);
            Console.SetCursorPosition(50,13);
            Console.Write(bannerText2);
            Console.SetCursorPosition(46, 19);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            Console.SetCursorPosition(40, 10);
            Console.WriteLine("Welcome to Domagco & Elago Botique Store!");
            //array 
            string[,] categories = {
                {"Men's Clothes", "Shirt", "Jeans", "Jackets", "T- shirts" },
                {"Women's Clothes", "Blouse", "Skirts", "Dress", "tops" },
                {"Accesories", "Belt", "Hat", "Watch", "Sunglasses" }
            };
            double[,] prices = {
                { 1300, 2500, 3800, 1200 },
                { 1600, 1800, 5000, 1500 },
                { 580, 800, 1400, 2500 }
             };

            //pambilang ng quantity
            int[] mensClothesQuantity = new int[4];
            string[] mensClothesSize = new string[4];
            int[] womensClothesQuantity = new int[4];
            string[] womensClothesSize = new string[4];
            int[] accessoriesQuantity = new int[4];

            double TotalCost = 0;
            string Receipt = "";
            int categoryChoice = -1;

            //first page
            
            while (true)
            {
                //pili
                while (categoryChoice < 0 || categoryChoice > 2)
                {
                    Console.SetCursorPosition(40, 3);
                    Console.Write(bannerText);
                    Console.SetCursorPosition(40, 20);
                    Console.Write(bannerText2);
                    Console.SetCursorPosition(40, 10);
                    Console.WriteLine("\n\n\t\t\t\t\tPlease choose a category: ");
                    for (int i = 0; i < 3; i++)
                    {
                       
                        Console.WriteLine($"\t\t\t\t\t{i + 1}. {categories[i, 0]}");
                    }
                    DrawBorder();
                    Console.SetCursorPosition(40, 17);
                    Console.Write("Enter the number of chosen category: ");
                    categoryChoice = Convert.ToInt32(Console.ReadLine()) - 1;
                    

                    if (categoryChoice < 0 || categoryChoice > 2)
                    {
                        Console.WriteLine("Invalid choice. Please choose a valid category.");
                    }
                }

                //second page item matrix
                Console.Clear();
                Console.Write("\r\n  __  ____  ____  _  _  ____ \r\n (  )(_  _)(  __)( \\/ )/ ___)\r\n  )(   )(   ) _) / \\/ \\\\___ \\\r\n (__) (__) (____)\\_)(_/(____/\r\n");
                Console.SetCursorPosition(40, 5);
                Console.WriteLine($"{categories[categoryChoice, 0]}:");
                Console.SetCursorPosition(40, 6);
                Console.WriteLine("--------------------------------------------------------");
                Console.SetCursorPosition(40, 7);
                Console.WriteLine("║ Item           ║ Price       ║");
                Console.SetCursorPosition(40, 8);
                Console.WriteLine("--------------------------------------------------------");

                //loop ng matrix
                for (int i = 1; i < 5; i++)
                {
                    Console.WriteLine($"║\t\t\t\t\t {categories[categoryChoice, i],-15} ║ P{prices[categoryChoice, i - 1],-10} ║");
                }
                Console.WriteLine("\t\t\t\t\t--------------------------------------------------------");

                //switch sa qty size
                DrawBorder();
                int[] SelectedQuantity = null;
                string[] SelectedSize = null;

                switch (categoryChoice)
                {
                    case 0:
                        SelectedQuantity = mensClothesQuantity;
                        SelectedSize = mensClothesSize;
                        break;
                    case 1:
                        SelectedQuantity = womensClothesQuantity;
                        SelectedSize = womensClothesSize;
                        break;
                    case 2:
                        SelectedQuantity = accessoriesQuantity;
                        SelectedSize = null;
                        break;
                    default:
                        Console.WriteLine("Wrong input try again");
                        break;
                }
                //input ng quantity and size kada category
                if (categoryChoice >= 0)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(38, 8 + i);
                        Console.Write($"-> {categories[categoryChoice, i]}");
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.SetCursorPosition(40, 15 + i);
                        Console.Write($"Quantity: ");
                        SelectedQuantity[i - 1] = Convert.ToInt32(Console.ReadLine());
                        
                        


                        if (SelectedSize != null)
                        {
                            Console.SetCursorPosition(70, 15 + i);
                            Console.Write($"Size (S, M, L): ");
                            SelectedSize[i - 1] = Console.ReadLine().ToUpper();
                        }

                        double itemCost = prices[categoryChoice, i - 1] * SelectedQuantity[i - 1];
                        string sizeInfo = SelectedSize != null ? $" (Size: {SelectedSize[i - 1]})" : "";
                        Receipt += $"{categories[categoryChoice, i],-20}\t  {(SelectedSize != null ? $"({SelectedSize[i - 1]}) x{SelectedQuantity[i - 1],3}"  : ""),4}  {itemCost,20:n2}\n";
                        TotalCost += itemCost;
                    }
                }

                // i aask kung gusto pa umulit or proceed na sa checkout
                Console.Write("\n\t\t\t\t\tWould you like to continue shopping? (Y/N): ");
                string continueShopping = Console.ReadLine();
                if (continueShopping.ToUpper() != "Y")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                }

                
                categoryChoice = -1;
            }

            //Chekcout / receipt
            Console.WriteLine(bannerText4);
            Console.WriteLine("\t\t\t\t\t----------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t\tItem \t\t\t Quantity & Size\t\t\tPrice(P)");
            Console.WriteLine("\t\t\t\t\t----------------------------------------------------------------------------");
            foreach (var line in Receipt.Split('\n'))
            {
                // Adjust spacing based on the length of the item description
                Console.WriteLine("\t\t\t\t\t" + line);
            }
            Console.WriteLine("\t\t\t\t\t----------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t\tTotal:\t\t\t\t\tP{0:n2}", TotalCost);
            Console.WriteLine("\n\t\t\t\t\tThank you for shopping at Domagco & Elago Botique Store!");
        }
    }
}