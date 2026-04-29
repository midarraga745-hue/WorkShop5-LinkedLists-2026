using DoubleList;

var list = new DoubleLinkedList<int>();
var option = string.Empty;

do
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n===== DOUBLY LINKED LIST =====");
    Console.ResetColor();
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show forward");
    Console.WriteLine("3. Show backward");
    Console.WriteLine("4. Sort descending");
    Console.WriteLine("5. Show mode(s)");
    Console.WriteLine("6. Show chart");
    Console.WriteLine("7. Exists");
    Console.WriteLine("8. Remove one occurrence");
    Console.WriteLine("9. Remove all occurrences");
    Console.WriteLine("0. Exit");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("\nSelect an option: ");
    Console.ResetColor();
    option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter a number: ");
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                list.InsertOrdered(value);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✔ {value} added successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Invalid value.");
                Console.ResetColor();
            }
            break;

        case "2":
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("List forward:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(list.ToString());
            Console.ResetColor();
            break;

        case "3":
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("List backward:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(list.ToStringReverse());
            Console.ResetColor();
            break;

        case "4":
            list.Sort();
            list.Reverse();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("List sorted descending:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(list.ToString());
            Console.ResetColor();
            break;

        case "5":
            var modes = list.GetModes();
            if (modes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ The list is empty.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Mode(s): {string.Join(", ", modes)}");
            }
            Console.ResetColor();
            break;

        case "6":
            var frequencies = list.GetFrequencies();
            if (frequencies.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ The list is empty.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nOccurrences chart:");
                Console.ResetColor();
                foreach (var item in frequencies.OrderBy(x => x.Key))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{item.Key}\t");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(new string('*', item.Value));
                    Console.ResetColor();
                }
            }
            break;

        case "7":
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter the number to search: ");
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out int searchValue))
            {
                if (list.Contains(searchValue))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✔ {searchValue} EXISTS in the list.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ {searchValue} does NOT exist in the list.");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Invalid value.");
                Console.ResetColor();
            }
            break;

        case "8":
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter the number to remove (one occurrence): ");
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out int removeValue))
            {
                if (list.Contains(removeValue))
                {
                    list.Remove(removeValue);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✔ One occurrence of {removeValue} removed.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ {removeValue} does not exist in the list.");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Invalid value.");
                Console.ResetColor();
            }
            break;

        case "9":
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter the number to remove (all occurrences): ");
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out int removeAllValue))
            {
                if (list.Contains(removeAllValue))
                {
                    list.RemoveAll(removeAllValue);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✔ All occurrences of {removeAllValue} removed.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ {removeAllValue} does not exist in the list.");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Invalid value.");
                Console.ResetColor();
            }
            break;

        case "0":
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Goodbye!");
            Console.ResetColor();
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Invalid option.");
            Console.ResetColor();
            break;
    }
} while (option != "0");