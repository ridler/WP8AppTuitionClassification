﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace COTuitClass
{
    public partial class Adult : PhoneApplicationPage
    {
        public Adult()
        { InitializeComponent(); }

        public void goToEvidencePage(object sender, RoutedEventArgs e)
        { NavigationService.Navigate(new Uri("/EvidenceOfDomicilePivot.xaml", UriKind.Relative)); }
    }
}