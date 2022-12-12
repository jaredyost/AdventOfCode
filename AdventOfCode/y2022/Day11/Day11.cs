using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.y2022
{
    public class Day11
    {
        public void Run()
        {
            Console.WriteLine("-- 2022: Day 11 --");

            /* Get the input */
            List<string> fileLines = File.ReadLines(Path.Combine("y2022", "Day11", "input.txt")).ToList();

            int lcm = 1;
            List<Monkey> monkeys = new List<Monkey>();
            for(int i = 0; i < fileLines.Count(); i += 7)
            {
                List<int> originalItems = fileLines[i + 1].Split(':')[1].Split(',').Select(int.Parse).ToList();
                List<Item> newItems = new List<Item>();
                foreach(ulong item in originalItems)
                {
                    newItems.Add(new Item(item));
                }

                int divisor = int.Parse(fileLines[i + 3].Split("by")[1]);
                lcm *= divisor;

                monkeys.Add(
                    new Monkey(
                        newItems,
                        fileLines[i + 2].Split('=')[1].Trim(),
                        divisor,
                        int.Parse(fileLines[i + 4].Split("monkey")[1]),
                        int.Parse(fileLines[i + 5].Split("monkey")[1])
                    ));
            }

            /* Let the monkeys play... */
            for(int i = 0; i < 10000; i++)
            {
                for(int j = 0; j < monkeys.Count(); j++)
                {
                    monkeys[j].InspectItems(ref monkeys, lcm);
                }
            }

            /* Report the solution */
            List<Monkey> topMonkeys = monkeys.OrderByDescending(x => x.InspectionCount).Take(2).ToList();
            Console.WriteLine($"Solution: { topMonkeys[0].InspectionCount * topMonkeys[1].InspectionCount }");
        }

        private class Item
        {
            public ulong WorryLevel { get; private set; } = 0;

            public Item(Item Item)
            {
                WorryLevel = Item.WorryLevel;
            }

            public Item(ulong WorryLevel)
            {
                this.WorryLevel = WorryLevel;
            }

            public void UpdateWorryLevel(string Formula, int LCM)
            {
                string[] splitFormula = Formula.Split();

                ulong newValue = WorryLevel;
                ulong var1 = splitFormula[0] == "old" ? WorryLevel : ulong.Parse(splitFormula[0]);
                ulong var2 = splitFormula[2] == "old" ? WorryLevel : ulong.Parse(splitFormula[2]);
                switch(splitFormula[1][0])
                {
                    case '+':
                        newValue = (var1 + var2) % (ulong)LCM;
                        break;

                    case '*':
                        newValue = (var1 * var2) % (ulong)LCM;
                        break;

                    default:
                        break;
                }

                WorryLevel = newValue;
            }
        }

        private class Monkey
        {
            public ulong InspectionCount { get; private set; } = 0;
            private readonly List<Item> Items = new List<Item>();
            private readonly string Operation = "old";
            private readonly int Diviser = 1;
            private readonly int TrueMonkey = -1;
            private readonly int FalseMonkey = -1;

            public Monkey(List<Item> Items, string Operation, int Diviser, int TrueMonkey, int FalseMonkey)
            {
                this.Items = Items;
                this.Operation = Operation;
                this.Diviser = Diviser;
                this.TrueMonkey = TrueMonkey;
                this.FalseMonkey = FalseMonkey;
            }

            public void InspectItems(ref List<Monkey> Monkeys, int LCM)
            {
                for(int i = 0; i < Items.Count(); i++)
                {
                    Items[i].UpdateWorryLevel(Operation, LCM);
                    Monkeys[(Items[i].WorryLevel % (ulong)Diviser) == 0 ? TrueMonkey : FalseMonkey].Items.Add(new Item(Items[i]));
                    Items.RemoveAt(i);
                    i--;
                    InspectionCount++;
                }
            }
        }
    }
}
