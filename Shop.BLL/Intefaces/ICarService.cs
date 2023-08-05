using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Intefaces
{
    public interface ICarService
    {
        CarsListDTO GetCarsListViewModel(string category);
    }
}
