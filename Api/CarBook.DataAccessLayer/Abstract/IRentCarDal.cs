using CarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DataAccessLayer.Abstract
{
    public interface IRentCarDal : IGenericDal<RentCar>
    {
        void RentCarStatusChangeApproved(int id);
        void RentCarStatusChangeCancel(int id);
        void RentCarStatusChangeWait(int id);
    }
}
 