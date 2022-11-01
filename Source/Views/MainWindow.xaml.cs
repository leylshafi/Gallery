using Source.Models;
using Source.Repository;
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
using System.Windows.Shapes;

namespace Source.Views;

public partial class MainWindow : Window
{
    //Edit Views
    //Edit About

    public ObservableCollection<ImageCl> Images { get; set; } = new();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        for (int i = 0; i < FakeRepository.images.Count; i++)
        {
            Images.Add(FakeRepository.images[i]);
        }
        for (int i = 0; i < Images.Count; i++)
        {
            itms.Items.Add(Images[i]);
        }
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Test");
    }

    private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
       MessageBox.Show("ImageName");
    }

    private void MenuItem_Click_1(object sender, RoutedEventArgs e)
    {
        if(sender is  MenuItem mi)
        {
            if(mi.Header.ToString()=="Exit")
                Application.Current.Shutdown();
            else MessageBox.Show("Will be update soon", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
    }

    private void menuItem1_Click_1(object sender, RoutedEventArgs e)
    {

    }
}
