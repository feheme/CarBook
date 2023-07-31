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
    public class RentCarManager : IRentCarService
    {
        private readonly IRentCarDal _rentCarDal;
        public RentCarManager(IRentCarDal rentCarDal)
        {
            _rentCarDal = rentCarDal;
        }
        public void TDelete(RentCar t)
        {
            _rentCarDal.Delete(t);
        }
        public RentCar TGetByID(int id)
        {
            return _rentCarDal.GetByID(id);
        }
        public List<RentCar> TGetList()
        {
            return _rentCarDal.GetList();
        }
        public void TInsert(RentCar t)
        {
            _rentCarDal.Insert(t);
        }
        public void TRentCarStatusChangeApproved(int id)
        {
            _rentCarDal.RentCarStatusChangeApproved(id);
        }
        public void TRentCarStatusChangeCancel(int id)
        {
            _rentCarDal.RentCarStatusChangeCancel(id);

        }
        public void TRentCarStatusChangeWait(int id)
        {
            _rentCarDal.RentCarStatusChangeWait(id);
        }
        public void TUpdate(RentCar t)
        {
            _rentCarDal.Update(t);
        }
    }
}
