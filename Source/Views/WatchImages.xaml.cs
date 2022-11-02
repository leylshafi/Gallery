using Source.Models;
using Source.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Source.Views
{
    public partial class WatchImages : Window
    {
        public ObservableCollection<ImageCl> Images { get; set; } = new();



        public ImageCl Selected
        {
            get { return (ImageCl)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Selected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(ImageCl), typeof(WatchImages));

        public WatchImages(ImageCl slc)
        {
            InitializeComponent();
            DataContext = this;
            for (int i = 0; i < FakeRepository.images.Count; i++)
            {
                Images.Add(FakeRepository.images[i]);
            }
            Selected = slc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            if (sender is Button btn)
            {

                switch (btn.Name)
                {
                    case "next":
                        for (int i = 0; i < Images.Count; i++)
                        {
                            if (Images[i].ImageUrl == Selected.ImageUrl)
                            {
                                index = i;
                                break;
                            }
                        }
                        index++;
                        break;
                    case "prev":
                        for (int i = 0; i < Images.Count; i++)
                        {
                            if (Images[i].ImageUrl == Selected.ImageUrl)
                            {
                                index = i;
                                break;
                            }
                        }
                        index--;
                        break;
                    default:
                        break;
                }
                try
                {
                    Selected = Images[index];
                }
                catch (Exception)
                {
                    MessageBox.Show("There is no more image", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ////???????????
            //if(sender is Button btn)
            //{
            //    btn.Name = "next";

            //    for (int i = 0; i < 3; i++)
            //    {
            //        Selected = Images[i];
            //    }
            //}
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

            if (sender is MenuItem mi)
            {
                if (mi.Header.ToString() == "Exit")
                    Application.Current.Shutdown();
                else MessageBox.Show("Will be update soon", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            // //Edit Views
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem mi)
            {
                if (mi.Header.ToString() == "Exit")
                    Application.Current.Shutdown();
                else MessageBox.Show("Will be update soon", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gallery is created by Leyla Shafiyeva", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }
    }
}
