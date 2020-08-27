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

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateBoard();
        }



        private void CreateBoard()
        {
            for (int i = 0; i < 64; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition { });
                mainGrid.RowDefinitions.Add(new RowDefinition { });
            }

            AddCell(0, 0);
            AddCell(1, 0);
            //mainGrid.Children.Add(txtBlock1);
        }


        private void  AddCell(int x, int y)
        {
            Ellipse circle = new Ellipse
            {
                //Width = 10,
                //Height = 10,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            var binding = new Binding(Ellipse.ActualHeightProperty.Name)
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.Self),
                Mode = BindingMode.OneWay
            };

            circle.VerticalAlignment = VerticalAlignment.Stretch;
            circle.HorizontalAlignment = HorizontalAlignment.Center;

            BindingOperations.SetBinding(circle, Ellipse.WidthProperty, binding);

            Grid.SetRow(circle, x);
            Grid.SetColumn(circle, y);

            mainGrid.Children.Add(circle);
        }




    }
}
