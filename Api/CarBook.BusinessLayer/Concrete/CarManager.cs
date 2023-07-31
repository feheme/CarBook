using CarBook.BusinessLayer.Abstract;
using CarBook.DataAccessLayer.Abstract;
using CarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.BusinessLayer.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void TDelete(Car t)
        {
            _carDal.Delete(t);
        }

        public Car TGetByID(int id)
        {
            return _carDal.GetByID(id);
        }

        public List<Car> TGetList()
        {
            return _carDal.GetList();
        }

        public void TInsert(Car t)
        {
            _carDal.Insert(t);
        }

        public void TUpdate(Car t)
        {
            _carDal.Update(t);
        }
    }
}
