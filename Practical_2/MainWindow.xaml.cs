using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Practical_2
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private ObservableCollection<Model> toDoList = new ObservableCollection<Model>();
        private Convertor converter;
        private readonly string Path = "D:\\Desktop\\Notes.json";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            date_pick.Text = DateTime.Now.ToString();

            converter = new Convertor(Path);

            toDoList = converter.Deser();

            dgToDo.ItemsSource = toDoList;

            dgToDo.IsReadOnly = true;


        }
        private void create_but_Click(object sender, RoutedEventArgs e)
        {

            toDoList.Add(new Model() { Name = name_box.Text, Description = des_box.Text, CreationDate = (DateTime)date_pick.SelectedDate });


            Convertor.Ser(toDoList);

        }

        private void del_but_Click(object sender, RoutedEventArgs e)
        {

            toDoList.RemoveAt(dgToDo.SelectedIndex);

            Convertor.Ser(toDoList);

        }

        private void save_but_Click(object sender, RoutedEventArgs e)
        {
            var item = toDoList[dgToDo.SelectedIndex];

            item.Name = name_box.Text;
            item.Description = des_box.Text;

            toDoList[dgToDo.SelectedIndex] = item;

            Convertor.Ser(toDoList);

        }
    }
}

