using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace MVVM
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    { //viewModel property
      // private MainViewModel vM;


        public MainViewModel TheMainViewModel { get; set; }
      
        //}

        //ctor
        public MainPage()
        {
          //  VM = new MainViewModel();
            this.InitializeComponent();
            this.TheMainViewModel = new MainViewModel();
            this.TheMainViewModel.fillItems();
            Binding myBinding = new Binding();
            myBinding.Source = TheMainViewModel;
            myBinding.Path = new PropertyPath("SomeString");
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(txtText, TextBox.TextProperty, myBinding);


          

            ToggleButton b = new ToggleButton();
           // b.Name = "thebutton";
            Stackpanel.Children.Add(b);
            b.Content = "Button";

            Binding myBinding1 = new Binding();
            myBinding1.Source = TheMainViewModel;
            myBinding1.Path = new PropertyPath("MyItemsbool[0]");
            myBinding1.Mode = BindingMode.TwoWay;
            myBinding1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(b, ToggleButton.IsCheckedProperty, myBinding1);
            //BindingOperations.SetBinding(txtText, TextBox.TextProperty, myBinding1);

        }


    }
}
