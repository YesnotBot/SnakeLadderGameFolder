using System;
using System.Collections.Generic;

namespace SnakeLadderGame1
{
    class Program
    {
        public static Dictionary<int, int> snl = new Dictionary<int, int>
        {
            {5,25},
            {20,50},
            {3,71},
            {51,6},
            {8,90},
            {56,4},
        };

        public static Random rand = new Random();
        private const bool sixeshappened = true;

        static int Start(int square)
        {
            while (true)
            {
                int roll = rand.Next(1, 6);
                Console.Write("You are currently at {0}, You rolled a [0]",square,roll);
                if (square + roll > 100)
                {
                    Console.WriteLine("sorry you cannot move");
                }
                else
                {
                    square = square + roll;
                    Console.WriteLine(" now you are at square {0}", square);
                    if (square == 100) return 100;
                    int next = square;
                    if (snl.ContainsKey(square))
                    {
                        next = snl[square];
                    }
                    if (square < next)
                    {
                        Console.WriteLine("now you climbed ladder.leveled up to {0}", next);
                        if (next == 100) return 100;
                        square = next;

                    }
                    else if(square > next)
                    {
                        Console.WriteLine("sorry you walked on snake,now you are at  {0}", next);

                    }
                    if (roll < 6 || !sixeshappened) return square;
                    Console.WriteLine("you got 6 ");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Game");
            int square = 1;
            while (true)
            {
                Console.WriteLine("roll a dice? y or n or a(admin) ");
                string rolldice = Console.ReadLine();
                if (rolldice == "y")
                {


                    int x = Start(square);
                    if (x == 100)
                    {
                        Console.WriteLine("you reached");
                        return;
                    }
                    square = x;
                    Console.WriteLine();
                }
                else if(rolldice == "a")
                {
                    while (true)
                    {
                        Console.WriteLine("add 1 , update 2, or delete 3 ? ");
                        string inputadmin = Console.ReadLine();
                        int ip;
                        ip = Convert.ToInt32(inputadmin);

                        switch (ip)
                        {
                            case 1:
                                Console.WriteLine("ADD now input source and dest");
                                int Temp1 = Convert.ToInt32(Console.ReadLine());
                                int Temp2 = Convert.ToInt32(Console.ReadLine());
                                snl.Add(Temp1,Temp2);
                                Console.WriteLine("ADDED");
                                break;
                            case 2:
                                Console.WriteLine("Update input source and dest");
                                int Temp3 = Convert.ToInt32(Console.ReadLine());
                                int Temp4 = Convert.ToInt32(Console.ReadLine());
                                snl[Temp3] = Temp4;
                                Console.WriteLine("UPDATED");
                                break;
                            case 3:
                                Console.WriteLine("Delete input source");
                                int Temp5 = Convert.ToInt32(Console.ReadLine());
                                if (snl.ContainsKey(Temp5))
                                    snl.Remove(Temp5);
                                Console.WriteLine("DELETED");
                                break;
                            default:
                                Console.WriteLine("You are Exited from admin");
                                return;
                                break;
                        }
                    }
                }
                else 
                {
                    Console.WriteLine("you are out of game");
                    return;
                }
            }

        }
    }
}
