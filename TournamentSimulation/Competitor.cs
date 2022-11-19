using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentSimulation
{
    public class Competitor
    {
        private string name = "";

        public Competitor()
        {
            Console.WriteLine("Input competitors name");
            name = Console.ReadLine();
            while (name == "")
            {
                Console.WriteLine("Name can not be empty");
                name = Console.ReadLine();
            }
        }

        public void Print()
        {
            Console.Write(name);
        }


    }
}
