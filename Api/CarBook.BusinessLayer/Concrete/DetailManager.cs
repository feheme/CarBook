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
    public class DetailManager : IDetailService
    {
        private readonly IDetailDal _detailDal;

        public DetailManager(IDetailDal detailDal)
        {
            _detailDal = detailDal;
        }       


        public void TDelete(Detail t)
        {
            _detailDal.Delete(t);
        }

        public Detail TGetByID(int id)
        {
            return _detailDal.GetByID(id);
        }

        public List<Detail> TGetList()
        {
            return _detailDal.GetList();
        }

        public void TInsert(Detail t)
        {
            _detailDal.Insert(t);
        }

        public void TUpdate(Detail t)
        {
            _detailDal.Update(t);
        }
    }
}
