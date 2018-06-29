using System;
using System.Collections;
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
            QueryArrayList();
            QueryCollection();

            QueryAnimalData();


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

        static void QueryArrayList()
        {
            ArrayList famAnimal = new ArrayList()
            {
                new Animal {Name = "Heidi", Height = .8, Weigth = 18},
                new Animal {Name = "Shrek", Height = 4, Weigth = 130},
                new Animal {Name = "Congo", Height = 3.8, Weigth = 90}
            };

            var famAnimalEnum = famAnimal.OfType<Animal>();
            var smAnimals = from animal in famAnimalEnum
                where animal.Weigth <= 90
                orderby animal.Name
                select animal;

            foreach (var animal in smAnimals)
            {
                Console.WriteLine("{0} weighs {1} lbs", animal.Name, animal.Weigth);
            }
            Console.WriteLine();
        }

        static void QueryCollection()
        {
            var animalList = new List<Animal>()
            {
                new Animal {Name = "German Shepard", Height = 25, Weigth = 77},
                new Animal {Name = "Chihuahua", Height = 7, Weigth = 4.4},
                new Animal {Name = "Saint Bernard", Height = 30, Weigth = 200}
            };

            var bigDogs = from dog in animalList
                where (dog.Weigth > 70) && (dog.Height > 25)
                orderby dog.Name
                select dog;

            foreach (var dog in bigDogs)
            {
                Console.WriteLine("A {0} weighs {1}", dog.Name, dog.Weigth);
            }
            Console.WriteLine();
        }

        static void QueryAnimalData()
        {
            Animal[] animals = new[]
            {
                new Animal {Name = "German Shepard", Height = 25, Weigth = 77, AnimalID = 1},
                new Animal {Name = "Chihuahua", Height = 7, Weigth = 4.4, AnimalID = 2},
                new Animal {Name = "Saint Bernard", Height = 30, Weigth = 200, AnimalID = 3},
                new Animal {Name = "Pug", Height = 12, Weigth = 16, AnimalID = 1},
                new Animal {Name = "Beagle", Height = 15, Weigth = 23, AnimalID = 2}
            };

            Owner[] owners = new[]
            {
                new Owner{Name = "Doug Parks", OwnerID = 1},
                new Owner{Name = "Sally Smith", OwnerID = 2},
                new Owner{Name = "Paul Brooks", OwnerID = 3}
            };

            var nameHeight = from a in animals
                select new
                {
                    a.Name,
                    a.Height
                };

            Array arrNameHeight = nameHeight.ToArray();

            foreach (var i in arrNameHeight)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine();

            var innerJoin = from animal in animals
                join owner in owners
                    on animal.AnimalID equals owner.OwnerID
                select new
                {
                    OwnerName = owner.Name,
                    AnimalName = animal.Name
                };

            foreach (var i in innerJoin)
            {
                Console.WriteLine("{0} owns {1}", i.OwnerName, i.AnimalName);
            }
            Console.WriteLine();

            var groupJoin = from owner in owners
                orderby owner.OwnerID
                join animal in animals
                    on owner.OwnerID
                    equals animal.AnimalID
                    into ownerGroup
                select new
                {
                    Owner = owner.Name,
                    Animals = from owner2
                            in ownerGroup
                        orderby owner2.Name
                        select owner2
                };


            foreach (var ownerGroup in groupJoin)
            {
                Console.WriteLine(ownerGroup.Owner);
                foreach (var animal in ownerGroup.Animals)
                {
                    Console.WriteLine("* {0}", animal.Name);
                }
            }
        }
    }
}
