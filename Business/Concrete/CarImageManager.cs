using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Result;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
using System.Collections.Generic;
using System.Linq;
using System;
using FileHelper = Core.Utilities.Helpers.FileHelper;
using System.IO;

namespace Business.Concrete;

public class CarImageManager : ICarImageService
{
    ICarImageDal _carImageDal;

    public CarImageManager(ICarImageDal carImageDal)
    {
        _carImageDal = carImageDal;
    }

    [ValidationAspect(typeof(CarImageValidator))]
    public IResult Add(IFormFile file, CarImage carImage)
    {
        IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));

        if (result != null)
        {
            return new ErrorResult(Messages.CarImageLimitExceeded);
        }

        carImage.ImagePath = Core.Utilities.Helpers.FileHelper.Add(file).Message;
        carImage.Date = DateTime.Now;
        _carImageDal.Add(carImage);
        return new SuccessResult(Messages.CarImageAdded);
    }

    public IResult Delete(CarImage carImage)
    {
        File.Delete(carImage.ImagePath);
        _carImageDal.Delete(carImage);
        return new SuccessResult(Messages.CarImageDeleted);
    }

    [ValidationAspect(typeof(CarImageValidator))]
    public IResult Update(IFormFile file, CarImage carImage)
    {
        {
            carImage.ImagePath = FileHelper.Update(file, carImage.ImagePath).Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
    }

    public IDataResult<List<CarImage>> GetAll()
    {
        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
    }

    public IDataResult<CarImage> GetById(int carImageId)
    {
        return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == carImageId));
    }

    public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
    {
        var carImage = _carImageDal.GetAll().Where(c => c.CarId == carId).ToList();
        if (carImage.Count == 0)
        {
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage { CarId = carId, ImagePath = "wwwroot/Images/defaultcar.png", Date = DateTime.Now });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId).ToList());

    }

    private IResult CheckIfImageLimitExceeded(int carId)
    {
        var carImageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
        if (carImageCount >= 5)
        {
            return new ErrorResult(Messages.CarImageLimitExceeded);
        }

        return new SuccessResult();
    }

}