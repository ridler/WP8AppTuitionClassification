using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using COTuitClass.Resources;

namespace COTuitClass
{
    public partial class MainPage : PhoneApplicationPage
    {
        protected bool continuable;
        protected bool adult;
        protected bool deriv;
        protected bool spouse;
        protected bool over23;
        protected bool grad;

        protected DateTime birthdate;
        protected DateTime term;

        protected static DateTime FALL = new DateTime(2014, 8, 26);
        protected static DateTime SPRING = new DateTime(2014, 1, 1);
        protected static DateTime SUMMER = new DateTime(2014, 5, 15);
        
        protected short age;

        protected Uri derivPage;
        protected Uri emancPage;
        protected Uri adultPage;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            continuable = false;
            adult = false;
            
            deriv = false;
            spouse = false;
            over23 = false;
            grad = false;

            birthdate = new DateTime(1990, 1, 1);
            term = new DateTime();
            age = 0;

            adultPage = new Uri("/Adult.xaml", UriKind.Relative);
            emancPage = new Uri("/Emancipation.xaml", UriKind.Relative);
            derivPage = new Uri("/Derivative.xaml", UriKind.Relative);

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void dateSelectorHandler(object sender, DateTimeValueChangedEventArgs e)
        {
            this.birthdate = (DateTime)e.NewDateTime;
            return;
        }

        private void _2141TermHandler(object sender, RoutedEventArgs e)
        {
            this.term = SPRING;
            this.continuable = true;
        }

        private void _2147TermHandler(object sender, RoutedEventArgs e)
        {
            this.term = FALL;
            this.continuable = true;
        }

        private void _2144TermHandler(object sender, RoutedEventArgs e)
        {
            this.term = SUMMER;
            this.continuable = true;
        }

        private void gradChecked(object sender, RoutedEventArgs e)
        { this.grad = true; }
        private void gradUnchecked(object sender, RoutedEventArgs e)
        { this.grad = false; }

        private void marriedChecked(object sender, RoutedEventArgs e)
        { this.spouse = true; }
        private void marriedUnchecked(object sender, RoutedEventArgs e)
        { this.spouse = false; }

        private void parentChecked(object sender, RoutedEventArgs e)
        { this.deriv = true; }
        private void parentUnchecked(object sender, RoutedEventArgs e)
        { this.deriv = false; }

        private void ageCalculator()
        {
            this.over23 = false;
            // Handler for close birthdays
            if ((this.term.Year - this.birthdate.Year == 23) && (this.term.Month == this.birthdate.Month) && (this.term.Day > this.birthdate.Day))
            { this.age = 23; this.over23 = true; return; }
            else if ((this.term.Year - this.birthdate.Year == 23) && (this.term.Month == this.birthdate.Month) && (this.term.Day <= this.birthdate.Day))
            { this.age = 22; this.over23 = false; return; }
            // General:
            else
            {
                this.age = (short)(term.Year - birthdate.Year);
                if (age >= 23) { this.over23 = true; }
                else { this.over23 = false; }
            }
        }

        private void qualifyButtonClick(object sender, RoutedEventArgs e)
        {
            if (!this.continuable) { return; }
            ageCalculator();
            if (grad || spouse || over23) { this.adult = true; }
            else { this.adult = false; }
            if (this.adult) { NavigationService.Navigate(adultPage); }
            else if (this.deriv) { NavigationService.Navigate(derivPage); }
            else { NavigationService.Navigate(emancPage); }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}