using Shop.BLL.Intefaces;
using Shop.DAL.Repository;
using Shop.DAL.Models;
using Shop.BLL.DTO;

namespace Shop.BLL.Services
{
    public class AdminPanelService: IAdminPanelService
    {
        private UnitOfWork database;
        private readonly IFileService fileService;

        public AdminPanelService(UnitOfWork database, IFileService fileService)
        {
            this.database = database;
            this.fileService = fileService;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return database.Cars.GetAll();
        }

        public CarDTO GetCarViewModel(int id)
        {
            var car = database.Cars.Get(id);
            return new CarDTO
            {
                Id = car.Id,
                Name = car.Name,
                ShortDesc = car.ShortDesc,
                LongDesc = car.LongDesc,
                CurrentImage = car.Image,
                Price = car.Price,
                TopSellingCars = car.TopSellingCars,
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
                TopSellingCars = vm.TopSellingCars,
                Available = vm.Available,
                CategoryID = vm.CategoryID
            };

            if (vm.Image == null)
                car.Image = vm.CurrentImage;
            else
            {
                if (!string.IsNullOrEmpty(vm.CurrentImage))
                    fileService.RemoveImage(vm.CurrentImage);

                car.Image = await fileService.SaveImage(vm.Image);
            }

            if (car.Id > 0)
                database.Cars.Update(car);
            else
                database.Cars.Create(car);

            return await database.Cars.SaveChangesAsync();
        }

        public async Task RemoveCar(int id)
        {
            database.Cars.Delete(id);
            await database.Cars.SaveChangesAsync();
        }
    }

}
