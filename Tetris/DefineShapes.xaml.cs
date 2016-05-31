using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for DefineShapes.xaml
    /// </summary>
    public partial class DefineShapes : Window
    {
        static private List<PropertyInfo> kolorki = typeof(Brushes).GetProperties().ToList();


        public DefineShapes()
        {
            var what = this.DataContext;
            InitializeComponent();
            Color1.ItemsSource = kolorki;
        }
    }
}
