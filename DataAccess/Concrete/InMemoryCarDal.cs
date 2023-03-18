using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId=1,BrandId=1,ColorId=1,DailyPrice=1200,ModelYear="2023",Description="Fiat Egea"},
                new Car {CarId=2,BrandId=2,ColorId=2,DailyPrice=1300,ModelYear="2023",Description="Renault Clio"},
                new Car {CarId=3,BrandId=3,ColorId=2,DailyPrice=1100,ModelYear="2022",Description="Citroen C Elysee"},
                new Car {CarId=4,BrandId=4,ColorId=1,DailyPrice=712,ModelYear="2022",Description="Dacia Logan"},
                new Car {CarId=5,BrandId=5,ColorId=1,DailyPrice=1280,ModelYear="2022",Description="Ford Tourneo Courier"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
        }


    }
}
