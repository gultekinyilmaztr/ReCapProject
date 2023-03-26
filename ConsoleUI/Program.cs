using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Net.Http.Headers;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //NewMethod();
            //BrandTest();
            //RentalTest();
            //CustomerTest();
            //UserTest();

        }

        private static void UserTest()
        {
            IUserService userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { UserID = 1, FirstName = "Gültekin", LastName = "YILMAZ", Password = "gultekin", Email = "ogultekinyilmaztr@gmail.com" });
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine(item.UserID + " : " + item.FirstName + " " + item.LastName);
            }
        }

        private static void CustomerTest()
        {
            ICustomerService customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer { CustomerID = 1, UserID = 1, CompanyName = "Deepy" });

            foreach (var c in customerManager.GetAll().Data)
            {
                Console.WriteLine(c.CustomerID + " : " + c.CompanyName);
            }
        }

        private static void RentalTest()
        {
            IRentalService rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental { RentalID = 1, CustomerID = 1, CarId = 3, RentDate = DateTime.Now });
            Console.WriteLine(result.Message);

            foreach (var item in rentalManager.GetAll().Data)
            {
                Console.WriteLine(item.RentalID + " : " + item.CustomerID + " " + item.CarId + " " + item.RentDate);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void NewMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success==true) 
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.CarId + "/" + car.BrandName);
                }
            }
            else
            { 
                Console.WriteLine(result.Message); 
            }          
        }
    }
}
