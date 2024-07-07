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
using HomeWork_4.src;

namespace HomeWork_4
{
    /// <summary>
    /// Interaction logic for Second_Window.xaml
    /// </summary>
    public partial class Second_Window : Window
    {
        MainWindow main;
        public Second_Window()
        {
            InitializeComponent();
            titleToDo.Text = "Названия нет";
            descriptionToDo.Text = "Описания нет";            
            dateToDo.SelectedDate = DateTime.Today.AddDays(1);
            MainWindow main = this.Owner as MainWindow;
            this.main = main;
        }

        private void ButtonSaveToDo(object sender, RoutedEventArgs e)
        {
            (this.Owner as MainWindow).TodoList.Add(new src.ToDo(titleToDo.Text, dateToDo.SelectedDate.Value,descriptionToDo.Text,false));
            titleToDo.Text = "";
            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = DateTime.Today.AddDays(1);            

            (this.Owner as MainWindow).DataToDoList.Items.Refresh();
            (this.Owner as MainWindow).OnPropertyChanged();
            this.Close();
        }
    }
}
