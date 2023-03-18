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
            CarManager carManager = new CarManager(new EfCarDal());
           
            foreach (var car in carManager.GetAllByColorId(2))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
