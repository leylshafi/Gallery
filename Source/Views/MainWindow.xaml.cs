using Microsoft.Win32;
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
    //EditViews
    //DragDrop
    //Play stop

    public ObservableCollection<ImageCl> Images { get; set; } = new();


    double width;
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
        width = itms.Width;
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Gallery is created by Leyla Shafiyeva","Information",MessageBoxButton.OK,MessageBoxImage.Information);
    }

    private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if(sender is Label lb)
        {
            var source=lb.Tag;
            foreach (ImageCl image in Images)
            {
                if(source.ToString().Contains(image.ImageUrl))
                {
                    WatchImages watchImages = new WatchImages(image);
                    watchImages.ShowDialog();
                }
            }
        }
    }

    private void menuItem1_Click_1(object sender, RoutedEventArgs e)
    {
        ///Edit
        //if(sender is MenuItem mi)
        //{
        //    switch (mi.Header)
        //    {
        //        case "Large Icons":
        //            itms.Width = 300;
        //            break;
        //        case "Small Icons":
        //           MessageBox.Show(itms.Parent.ToString());

        //            for (int i = 0; i < Images.Count; i++)
        //            {
        //                itms.Items.Add(Images[i]);
        //            }


        //            //itms.HorizontalAlignment = HorizontalAlignment.Right;

        //            // itms.HorizontalAlignment = HorizontalAlignment.Left;
        //            break;
        //        case "List":
        //            break;

        //        default:
        //            break;
        //    }
        //}
        if (sender is MenuItem mi)
        {
            switch (mi.Header)
            {
                case "Large Icons":
                    itms.Width = 300;
                    break;
                case "Small Icons":
                    itms.Items.Clear();
                    itms.Width = width;
                    for (int i = 0; i < Images.Count; i++)
                    {
                        itms.Items.Add(Images[i]);
                    }
                    break;
                default:
                    break;
            }
        }

    }

    private void MenuItem_Click_1(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        if (openFileDialog1.ShowDialog() == true)
        {

            Images.Add(new ImageCl()
            {
                ImageUrl = openFileDialog1.FileName,
            });
            itms.Items.Add(new ImageCl()
            {
                ImageUrl = openFileDialog1.FileName,
            });
        }
    }

    private void DropFileSP_Drop(object sender, DragEventArgs e)
    {
        if(e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            ImageCl newimg = new()
            {
                ImageUrl = files[0],
                ImageName = "Name"
            };
            Images.Add(newimg);
            itms.Items.Add(newimg);
        }
    }
}
