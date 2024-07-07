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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HomeWork_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            TodoList = new List<ToDo>();
            TodoList.Add(new ToDo("Родиться", new DateTime(2024, 01, 10), "Важно!", true));
            TodoList.Add(new ToDo("Посадить сына", new DateTime(2024, 01, 11), "Важно!!", false));
            TodoList.Add(new ToDo("Построить дерево", new DateTime(2024, 01, 13), "Важно!!!", false));
            TodoList.Add(new ToDo("Вырастить дом", new DateTime(2024, 01, 13), "Важно!!!!", false));
            TodoList.Add(new ToDo("Умереть", new DateTime(2024, 01, 15), "Важно!!!!!", false));

            DataToDoList.ItemsSource = TodoList;
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
            TodoList.Remove((ToDo)DataToDoList.SelectedItem);
            DataToDoList.ItemsSource = null;
            DataToDoList.ItemsSource = TodoList;
            OnPropertyChanged();
        }
        private void ButtonAddToDo(object sender, RoutedEventArgs e)
        {
            Second_Window second_Window = new Second_Window();
            second_Window.Show();
            second_Window.Owner = this;
            OnPropertyChanged();
        }
        private void CheckboxEnableToDo_Checked(object sender, RoutedEventArgs e)
        {
            if (DataToDoList.SelectedItem == null || AddToDo == null) return;
            TodoList[DataToDoList.SelectedIndex].Doing = true;
            OnPropertyChanged();
        }
        private void CheckboxEnableToDo_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataToDoList.SelectedItem == null || AddToDo == null) return;            
            TodoList[DataToDoList.SelectedIndex].Doing = false;
            OnPropertyChanged();
        }
    }
}

