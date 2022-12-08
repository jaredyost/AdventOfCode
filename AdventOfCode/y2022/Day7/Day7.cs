using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2022
{
    public class Day7
    {
        public void Run()
        {
            Console.WriteLine("-- 2022: Day 7 --");

            /* Get the input and form the tree */
            IEnumerable<string> fileLines = File.ReadLines(Path.Combine("y2022", "Day7", "input.txt"));

            Item fileSystem = null;
            foreach(string line in fileLines)
            {
                string[] lineSplit = line.Split();
                if(lineSplit[0] == "$")
                {
                    /* This is a command */
                    switch(lineSplit[1])
                    {
                        case "cd":
                            if(fileSystem == null)
                            {
                                /* Initialize the file system */
                                fileSystem = new Item(lineSplit[2]);
                            }
                            else if(lineSplit[2] == "..")
                            {
                                /* Go up a directory */
                                fileSystem = fileSystem.Parent;
                            }
                            else if(fileSystem.Children != null)
                            {
                                /* Change to a child directory */
                                for(int i = 0; i < fileSystem.Children.Count(); i++)
                                {
                                    if(fileSystem.Children.ElementAt(i).Name == lineSplit[2])
                                    {
                                        fileSystem = fileSystem.Children.ElementAt(i);
                                        break;
                                    }
                                }
                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    switch(lineSplit[0])
                    {
                        case "dir":
                            /* Add a directory */
                            fileSystem.AddChild(new Item(lineSplit[1]));
                            break;

                        default:
                            /* Add a file */
                            int size = int.Parse(lineSplit[0]);
                            fileSystem.AddChild(new Item(lineSplit[1], size));
                            break;
                    }
                }
            }

            /* Move back to the root of the tree */
            while(fileSystem.Parent != null)
            {
                fileSystem = fileSystem.Parent;
            }

            /* Iterate over the directories */
            int spaceNeeded = 30000000 - (70000000 - fileSystem.Size);
            int smallestDirectorySize = IterateDirectories(spaceNeeded, fileSystem);

            /* Report the solution */
            Console.WriteLine($"Solution: { smallestDirectorySize }");
        }

        private class Item
        {
            public string Name { get; set; } = "";
            public int Size { get; set; } = 0;
            public Item Parent { get; private set; } = null;
            public List<Item> Children { get; private set; } = null;

            public Item(string Name)
            {
                this.Name = Name;
                Children = new List<Item>();
            }

            public Item(string Name, int Size)
            {
                this.Name = Name;
                this.Size = Size;
            }

            public void AddChild(Item Child)
            {
                Child.Parent = this;
                Children.Add(Child);

                Item tempParent = this;
                do
                {
                    tempParent.Size += Child.Size;
                    tempParent = tempParent.Parent;
                } while(tempParent != null);
            }
        }

        private int IterateDirectories(int SpaceNeeded, Item StartingItem)
        {
            int smallest = StartingItem.Size;
            if(StartingItem.Children != null)
            {
                foreach(Item Child in StartingItem.Children.Where(x => x.Children != null))
                {
                    int possibleSmallest = Math.Min(smallest, IterateDirectories(SpaceNeeded, Child));
                    if(possibleSmallest >= SpaceNeeded)
                    {
                        smallest = possibleSmallest;
                    }
                }
            }

            return smallest;
        }
    }
}
