using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapprojectContext>, ICarDal

    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapprojectContext context = new RecapprojectContext())
            {
                var result = from p in context.Cars //ürünlerle kategörileri join yap
                             join c in context.Brands
                             on p.BrandId equals c.BrandId // kategori id ye göre
                             select new CarDetailDto
                             {
                                 CarId = p.CarId,                               
                                 BrandName = c.BrandName,
                                 DailyPrice = p.DailyPrice
                             };
                return result.ToList();

            }
        }
    }
}
