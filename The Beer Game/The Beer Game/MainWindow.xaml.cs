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

namespace The_Beer_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Add new Participants
            Participant Fabrik = new Participant(10, 20, 1);
            Participant Regionallager = new Participant(10, 20, 1);
            Participant Großlager = new Participant(10, 20, 1);
            Participant Einzelhandel = new Participant(10, 20, 1);
            
            TB.Text = Fabrik.exec_storage_costs();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
