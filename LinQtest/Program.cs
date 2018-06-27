using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQtest
{
    class Animal
    {
        public string Name { get; set; }
        public double Weigth { get; set; }
        public double Height { get; set; }
        public int AnimalID { get; set; }

        public Animal(string name = "No name", double weight = 0, double height = 0)
        {
            Name = name;
            Weigth = weight;
            Height = height;
        }

        public override string ToString()
        {
            return string.Format("{0} weighs {1} and is {2} meters tall.", Name, Weigth, Height);
        }
    }

    class Owner
    {
        public string Name { get; set; }
        public int OwnerID { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime data = DateTime.Now;
            Console.WriteLine(data.ToString());

            QueryStringArray();
            QueryIntArray();
            Console.ReadLine();
        }

        static void QueryStringArray()
        {
            string[] dogs = {"K 9", "Brian", "Scooby", "Walker", "Old Yeller",
                "Rin Tin Tin", "Benji", "Charlie B. Barkin", "Lassie", "Snoopy"};

            var dogSpaces = from dog in dogs
                            where dog.Contains(" ")
                            orderby dog descending
                            select dog;

            var xd = from dog in dogs
                    where dog.Contains("")
                    orderby dog
                    select dog;

            foreach (var i in dogSpaces)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            foreach (var i in xd)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

        }

        static int[] QueryIntArray()
        {
            int[] nums = { 5, 10, 15, 20,
                            25, 30, 35 };

            var gt20 = from num in nums
                        where num > 20
                        orderby num
                        select num;

            foreach (var i in gt20)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            Console.WriteLine($"Get Type: {gt20.GetType()}");
            var listGt20 = gt20.ToList<int>();
            var arrayGt20 = gt20.ToArray();

            nums[0] = 40;

            foreach (var i in gt20)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            return arrayGt20;
        }
    }
}
