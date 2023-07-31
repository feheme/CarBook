using CarBook.DataAccessLayer.Abstract;
using CarBook.DataAccessLayer.Concrete;
using CarBook.DataAccessLayer.Repositories;
using CarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DataAccessLayer.EntityFramework
{
    public class EfRentCarDal : GenericRepository<RentCar>, IRentCarDal
    {
        public EfRentCarDal(Context context) : base(context)
        {
        }

        public void RentCarStatusChangeApproved(int id)
        {
            using var context = new Context();
            var values = context.RentCars.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void RentCarStatusChangeCancel(int id)
        {
            using var context = new Context();
            var values = context.RentCars.Find(id);
            values.Status = "İptal Edildi";
            context.SaveChanges();
        }

        public void RentCarStatusChangeWait(int id)
        {
            using var context = new Context();
            var values = context.RentCars.Find(id);
            values.Status = "Müşteri Aranacak";
            context.SaveChanges();
        }
    }
}
