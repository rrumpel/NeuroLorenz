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

namespace NeuroLorenz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Lorenz lorenz = new Lorenz(0, 1, 0);
        List<Tuple3d> points = new List<Tuple3d>();

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 8000; i++)
            {
                points.Add(lorenz.GetCurrentLocation());
                lorenz.Iterate();
                //MainPolyline.Points.Add(new Point(currentPoint.x + 400, currentPoint.z + 400));
                //lorenz.iterate();
            }

        }

	}
}
