using Business.Concrete;
using DataAccess.Concrete;
using System;
using System.Net.Http.Headers;

namespace ConsoleUI
{
    internal class Program
    {

        static void Main(string[] args)

        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach ( var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " " + car.Description);
            }           
        }
    }
}
