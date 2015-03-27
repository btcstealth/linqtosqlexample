using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace linqexample
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string fileName = "test.sdf";
            string totalPath = @"" + directoryPath + "\\" + fileName;
            //insertCar();
            List<Car> cars = new List<Car>();

            try
            {
                Car car = getCar(2);
                Console.WriteLine(car.Name);

                //cars = getCars();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            /*
            foreach (Car c in cars)
            {
                Console.WriteLine(c.Id);
                Console.WriteLine(c.Name);
            }
             * */

            Console.ReadLine();
        }

        public static void insertCar()
        {
            using (DatabaseContext2 myDb = new DatabaseContext2("C:\\Users\\bjarke\\Desktop\\database\\test.sdf"))
            {
                Car car = new Car
                {
                    Name = "the super car"
                };

                try
                {
                    // Add the new object to the Orders collection.
                    myDb.Car.InsertOnSubmit(car);

                    // Submit the change to the database. 
                    myDb.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static List<Car> getCars()
        {
            using (DatabaseContext2 myDb = new DatabaseContext2("C:\\Users\\bjarke\\Desktop\\database\\test.sdf"))
            {
                var cars =
                from c in myDb.Car
                select c;

                return cars.ToList<Car>();
            }
        }

        public static Car getCar(int id)
        {
            using (DatabaseContext2 myDb = new DatabaseContext2("C:\\Users\\bjarke\\Desktop\\database\\test.sdf"))
            {
                var car = 
                (from c in myDb.Car
                where c.Id == id
                 select c);

                List<Car> list = car.ToList<Car>();
                Car carObj = list.First();

                return carObj;
            }
        }

    }
}
