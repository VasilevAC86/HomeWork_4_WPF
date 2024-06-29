using HomeWork_4.src;
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
using System.Windows.Shapes;

namespace HomeWork_4
{
    /// <summary>
    /// Interaction logic for End_Window.xaml
    /// </summary>
    public partial class End_Window : Window
    {
        public End_Window()
        {            
            InitializeComponent();            
            DataToDoList.ItemsSource = MainWindow.toDoList;            
        }
        private void ButtonDeleteToDo(object sender, RoutedEventArgs e)
        {
            MainWindow.toDoList.Remove((ToDo)DataToDoList.SelectedItem);
            DataToDoList.ItemsSource = null;
            DataToDoList.ItemsSource = MainWindow.toDoList;
        }
        private void ButtonAddToDo(object sender, RoutedEventArgs e)
        {
            Second_Window second_Window = new Second_Window();
            second_Window.Show();
            second_Window.Owner = this;
        }
        private void CheckboxEnableToDo_Checked(object sender, RoutedEventArgs e)
        {
            if (DataToDoList.SelectedItem == null || AddToDo == null) return;
            MainWindow.toDoList[DataToDoList.SelectedIndex].Doing = true;
        }
        private void CheckboxEnableToDo_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataToDoList.SelectedItem == null || AddToDo == null) return;
            MainWindow.toDoList[DataToDoList.SelectedIndex].Doing = false;
        }
    }
}
