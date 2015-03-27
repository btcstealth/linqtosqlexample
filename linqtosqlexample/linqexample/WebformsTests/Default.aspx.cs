using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebformsTests
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Car> cars = new List<Car>();
            cars = getCars();
            Car car = cars.ElementAt(2);

            TextBox1.Text = car.Name;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public static List<Car> getCars()
        {
            using (testContext myDb = new testContext("C:\\Users\\bjarke\\Desktop\\database\\test.sdf"))
            {
                var cars =
                from c in myDb.Car
                select c;

                return cars.ToList<Car>();
            }
        }

        

    }
}