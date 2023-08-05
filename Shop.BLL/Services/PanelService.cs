using Shop.BLL.Intefaces;
using Shop.Data.FileManager;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class PanelService: IPanelService
    {
        private readonly ICarRepository carRep;
        private readonly IFileManager fileManager;

        public PanelService(ICarRepository carRep, IFileManager fileManager)
        {
            this.carRep = carRep;
            this.fileManager = fileManager;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return carRep.GetAllCars();
        }

        public CarDTO GetCarViewModel(int id)
        {
            var car = carRep.GetObjectCar(id);
            return new CarDTO
            {
                Id = car.Id,
                Name = car.Name,
                ShortDesc = car.ShortDesc,
                LongDesc = car.LongDesc,
                CurrentImage = car.Image,
                Price = car.Price,
                IsFavourite = car.IsFavourite,
                Available = car.Available,
                CategoryID = car.CategoryID
            };
        }

        public async Task<bool> SaveCar(CarDTO vm)
        {
            var car = new Car
            {
                Id = vm.Id,
                Name = vm.Name,
                ShortDesc = vm.ShortDesc,
                LongDesc = vm.LongDesc,
                Price = vm.Price,
                IsFavourite = vm.IsFavourite,
                Available = vm.Available,
                CategoryID = vm.CategoryID
            };

            if (vm.Image == null)
                car.Image = vm.CurrentImage;
            else
            {
                if (!string.IsNullOrEmpty(vm.CurrentImage))
                    fileManager.RemoveImage(vm.CurrentImage);

                car.Image = await fileManager.SaveImage(vm.Image);
            }

            if (car.Id > 0)
                carRep.UpdateCar(car);
            else
                carRep.AddCar(car);

            return await carRep.SaveChangesAsync();
        }

        public async Task RemoveCar(int id)
        {
            carRep.RemoveCar(id);
            await carRep.SaveChangesAsync();
        }
    }

}
