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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HomeWork_4
{
    /// <summary>
    /// Interaction logic for End_Window.xaml
    /// </summary>
    public partial class End_Window : Window, INotifyPropertyChanged
    {
        public List<ToDo> TodoList;
        public List<ToDo> todoList
        {
            get { return TodoList; } 
            set 
            { 
                todoList = value;
                OnPropertyChanged();
            }
        }
        public int CountDoing { get; set; }
        public End_Window()
        {            
            InitializeComponent();
            DataContext = this;
            TodoList = new List<ToDo>();
            TodoList = MainWindow.toDoList;

            DataToDoList.ItemsSource = MainWindow.toDoList;
            //EndToDo();
            OnPropertyChanged();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged()
        {
            CountDoing = TodoList.Where(e => e.Doing == true).ToList().Count;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TodoList"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CountDoing"));
        }
        private void ButtonDeleteToDo(object sender, RoutedEventArgs e)
        {
            MainWindow.toDoList.Remove((ToDo)DataToDoList.SelectedItem);
            DataToDoList.ItemsSource = null;
            DataToDoList.ItemsSource = MainWindow.toDoList;
            //EndToDo();
            OnPropertyChanged();
        }
        private void ButtonAddToDo(object sender, RoutedEventArgs e)
        {
            Second_Window second_Window = new Second_Window();
            second_Window.Show();
            second_Window.Owner = this;
            //EndToDo();
            OnPropertyChanged();
        }
        private void CheckboxEnableToDo_Checked(object sender, RoutedEventArgs e)
        {
            if (DataToDoList.SelectedItem == null || AddToDo == null) return;
            MainWindow.toDoList[DataToDoList.SelectedIndex].Doing = true;
            //EndToDo();
            OnPropertyChanged();
        }
        private void CheckboxEnableToDo_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataToDoList.SelectedItem == null || AddToDo == null) return;
            MainWindow.toDoList[DataToDoList.SelectedIndex].Doing = false;
            //EndToDo();
            OnPropertyChanged();
        }

        /*private void EndToDo()
        {   
            ProgressBarEnd.Value = 0;
            ProgressBarEnd.Minimum = 0;
            ProgressBarEnd.Maximum = MainWindow.toDoList.Count;            
            foreach (var item in MainWindow.toDoList)
                if (item.Doing)
                    ProgressBarEnd.Value++;
            TextBlockProgress.Text = ProgressBarEnd.Value.ToString() + '/' + MainWindow.toDoList.Count;
        }*/      
    }
}
