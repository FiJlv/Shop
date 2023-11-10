using Shop.BLL.Intefaces;
using Shop.DAL.Repository;
using Shop.DAL.FileManager;
using Shop.DAL.Models;
using Shop.BLL.DTO;

namespace Shop.BLL.Services
{
    public class PanelService: IPanelService
    {
        UnitOfWork Database;
        private readonly IFileManager fileManager;

        public PanelService(UnitOfWork database, IFileManager fileManager)
        {
            Database = database;
            this.fileManager = fileManager;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return Database.Cars.GetAll();
        }

        public CarDTO GetCarViewModel(int id)
        {
            var car = Database.Cars.Get(id);
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
                Database.Cars.Update(car);
            else
                Database.Cars.Create(car);

            return await Database.Cars.SaveChangesAsync();
        }

        public async Task RemoveCar(int id)
        {
            Database.Cars.Delete(id);
            await Database.Cars.SaveChangesAsync();
        }
    }

}
