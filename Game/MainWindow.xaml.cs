using GameOfLifeBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        const int GridFactorSize = 64;

        public MainWindow()
        {
            InitializeComponent();
            CreateBoard();

            App.Current.Dispatcher.Invoke(() =>
            {
                //for (int i = 0; i < 10; i++)
                {
                    PaintBoard(CraeteRandomBoard());
                    mainGrid.Children.Clear();
                }
            });
        }



        private void CreateBoard()
        {
            for (int i = 0; i < GridFactorSize; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition { });
                mainGrid.RowDefinitions.Add(new RowDefinition { });
            }




            //AddCell(0, 0);
            //AddCell(1, 0);
            //mainGrid.Children.Add(txtBlock1);
        }

        private void PaintBoard(Cell[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].Alive)
                    {
                        AddCell(i, j);
                    }
                    //else
                    //{
                    //    ClearCell(i, j);
                    //}
                }
            }


        }


        #region FOR_TESTS
        Cell[,] CraeteRandomBoard()
        {
            Cell[,] rto = new Cell[GridFactorSize, GridFactorSize];
            var r = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < rto.GetLength(0); i++)
            {
                for (int j = 0; j < rto.GetLength(1); j++)
                {
                    rto[i, j] = new Cell { Alive = r.Next(2) == 1 };
                }
            }

            return rto;
        }
        #endregion FOR_TESTS









        private void ClearCell(int x, int y)
        {
            if (mainGrid.Children.Count != 0)
            {
                int index = (x == y && x == 0) ? 0 : (x * GridFactorSize + y) - 1;
                var reo = mainGrid.Children[index];
                if (reo != null)
                {
                    mainGrid.Children.Remove(reo);
                }
            }
        }

        private void AddCell(int x, int y)
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
