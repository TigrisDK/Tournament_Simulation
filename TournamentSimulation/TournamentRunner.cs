using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentSimulation;

namespace TournamentSimulation
{
    public class TournamentRunner
    {
        Random rng = new Random();

        List<Competitor> competitors = new List<Competitor>();
        int limit;

        public TournamentRunner()
        {
            while (true)
            {
                Console.WriteLine("Indtast 'Q' for at lave en ny deltager");
                Console.WriteLine("Indtast 'P' for at se alle deltagere");
                Console.WriteLine("Input 'A' To see number of tournaments in first round");
                Console.WriteLine("To start Tournament input 'S'");
                string comm = Console.ReadLine();
                CommandHandler(comm);
            }
        }

        private void CreateRound()
        {
            for (int round = 1; round < limit; round++)
            {
                Console.WriteLine("Round #{0}", round);
                Branch(1, 1, limit - round + 1);
                Console.WriteLine();
            }

        }

        private void Branch(int seed, int level, int limit)
        {
            var levelSum = (int)Math.Pow(2, level) + 1;

            if (limit == level + 1)
            {
                Console.WriteLine("Seed {0} vs. seed {1}", seed, levelSum - seed);
                /*
                Console.WriteLine("Seed {0} vs. seed {1}", competitors[seed], competitors[levelSum - seed]);
                */
                /*
                Console.Write("Competitor: ");
                competitors[seed-1].Print();
                Console.Write("vs.");
                competitors[levelSum - seed-1].Print();
                
                Console.WriteLine();
                */
                
                
                return;
            }
            else if (seed % 2 == 1)
            {
                Console.WriteLine("else 1");
                Branch(seed, level + 1, limit);
                Branch(levelSum - seed, level + 1, limit);
            }
            else
            {
                Console.WriteLine("Else 2");
                Branch(levelSum - seed, level + 1, limit);
                Branch(seed, level + 1, limit);
            }
        }

        private void AddCompetitor()
        {
            var newCompetitor = new Competitor();
            competitors.Add(newCompetitor);
        }

        private void PrintCompetitors()
        {
            foreach (var comp in competitors)
            {
                comp.Print();
            }
        }

        private void CommandHandler(string command)
        {
            switch(command)
            {
                case "Q":
                    AddCompetitor();
                    break;
                case "P":
                    PrintCompetitors();
                    break;
                case "A":
                    TournamentCount();
                    break;
                case "S":
                    
                    int num = 8;
                    limit = (int)(Math.Log(num, 2) + 1);
                    
                    /*
                    Shuffle(competitors);
                    limit = (int)(Math.Log(competitors.Count(), 2) + 1);
                    Console.WriteLine("Limit = {0}", limit);
                    */
                    CreateRound();
                    break;
                
                default:
                    Console.WriteLine("Command not known");
                    break;
            }
        }

        private void TournamentCount()
        {
            int number = competitors.Count();
            if (number % 2 != 0)
            {
                Console.WriteLine("There is an uneven number of competitors");
            } else
            {
                Console.WriteLine("There is {0} matches in first round", number/2);
            }
        }

        private void Shuffle(List<Competitor> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Competitor value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
