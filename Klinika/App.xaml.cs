using Klinika.Controller;
using Klinika.Repository;
using Klinika.Service;
using System.Windows;

namespace Klinika
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public UserController UserController { get; set; }
        public ComponentController ComponentController { get; set; }

        public MedicineController MedicineController { get; set; }


        public App()
        {

            var userRepository = new UserRepository();
            var componentRepository = new ComponentRepository();
            var medicineRepository = new MedicineRepository();

            var userService = new UserService(userRepository);
            var componentService = new ComponentService(componentRepository);
            var medicineService = new MedicineService(medicineRepository,userService,componentService);

            UserController = new UserController(userService);
            ComponentController = new ComponentController(componentService);
            MedicineController = new MedicineController(medicineService);





        }





    }
}
