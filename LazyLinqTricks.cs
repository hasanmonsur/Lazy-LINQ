using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezyLinQ
{
    public class LazyLinqTricks
    {
        public static void RunExamples()
        {
            // Sample data for demonstrations
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25, City = "New York" },
            new Person { Name = "Bob", Age = 30, City = "Boston" },
            new Person { Name = "Charlie", Age = 25, City = "New York" },
            new Person { Name = null, Age = 35, City = "Chicago" }
        };

            // Trick 1: SkipWhile and TakeWhile for Dynamic Ranges
            Console.WriteLine("Trick 1: SkipWhile and TakeWhile");
            var range = numbers.SkipWhile(n => n <= 3).TakeWhile(n => n < 8);
            Console.WriteLine(string.Join(", ", range)); // Output: 4, 5, 6, 7

            // Trick 2: DefaultIfEmpty for Handling Empty Collections
            Console.WriteLine("\nTrick 2: DefaultIfEmpty");
            var emptyList = new List<int>();
            var result = emptyList.DefaultIfEmpty(0).Sum();
            Console.WriteLine(result); // Output: 0

            // Trick 3: Select with Index for Position-Based Logic
            Console.WriteLine("\nTrick 3: Select with Index");
            var indexed = numbers.Select((n, index) => $"Item {index}: {n}");
            Console.WriteLine(string.Join(", ", indexed)); // Output: Item 0: 1, Item 1: 2, ...

            // Trick 4: Aggregate for Custom Reductions
            Console.WriteLine("\nTrick 4: Aggregate");
            var product = numbers.Aggregate((acc, n) => acc * n);
            Console.WriteLine(product); // Output: 3628800 (factorial of 10)

            // Trick 5: GroupBy with Multiple Keys
            Console.WriteLine("\nTrick 5: GroupBy with Multiple Keys");
            var grouped = people.GroupBy(p => new { p.Age, p.City });
            foreach (var group in grouped)
            {
                Console.WriteLine($"Age: {group.Key.Age}, City: {group.Key.City}");
                foreach (var p in group) Console.WriteLine($" - {p.Name}");
            }

            // Trick 6: Zip for Pairing Collections
            Console.WriteLine("\nTrick 6: Zip");
            var names = new List<string> { "Alice", "Bob", "Charlie" };
            var ages = new List<int> { 25, 30, 35 };
            var paired = names.Zip(ages, (name, age) => $"{name} is {age}");
            Console.WriteLine(string.Join(", ", paired)); // Output: Alice is 25, Bob is 30, Charlie is 35

            // Trick 7: OfType for Safe Type Filtering
            Console.WriteLine("\nTrick 7: OfType");
            var mixedList = new List<object> { 1, "two", 3, "four", 5 };
            var integers = mixedList.OfType<int>();
            Console.WriteLine(string.Join(", ", integers)); // Output: 1, 3, 5

            // Trick 8: Concat with Empty Fallback
            Console.WriteLine("\nTrick 8: Concat with Empty Fallback");
            List<int> nullableList = null;
            var safeList = (nullableList ?? Enumerable.Empty<int>()).Concat(numbers);
            Console.WriteLine(string.Join(", ", safeList)); // Output: 1, 2, 3, ..., 10

            // Trick 9: DistinctBy for Custom Uniqueness
            Console.WriteLine("\nTrick 9: DistinctBy");
            var uniqueByAge = people.DistinctBy(p => p.Age);
            foreach (var p in uniqueByAge) Console.WriteLine($"{p.Name}, {p.Age}");

            // Trick 10: SequenceEqual for Collection Comparison
            Console.WriteLine("\nTrick 10: SequenceEqual");
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 1, 2, 3 };
            Console.WriteLine(list1.SequenceEqual(list2)); // Output: True
        }
    }
}
