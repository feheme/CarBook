using CarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.BusinessLayer.Abstract
{
    public interface IRentCarService : IGenericService<RentCar>
    {
        void TRentCarStatusChangeApproved(int id);
        void TRentCarStatusChangeCancel(int id);
        void TRentCarStatusChangeWait(int id);
    }
}
