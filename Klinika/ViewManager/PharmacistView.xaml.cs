using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Klinika.ViewManager
{
    /// <summary>
    /// Interaction logic for PharmacistView.xaml
    /// </summary>
    public partial class PharmacistView : Page
    {
        public PharmacistView()
        {
            InitializeComponent();
            SetContent(new UserPage());
        }

        public void SetContent(Page page)
        {
            Sadrzaj.Content = page;
        }
    }
}
