﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Deployment.Application;


namespace S7_DMCToolbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private S7_ViewModel VM;

        public MainWindow()
        {
            
            InitializeComponent();
            VM = TryFindResource("VM") as S7_ViewModel;
            VM.InitFromCommandLineArguments(App.StartupArgs);

            // Set title of window to current assembly version number
            Version myVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                // Override version if deployed via ClickOnce
                myVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }

            this.Title = this.Title + " v" + myVersion.Major + "." + myVersion.Minor + "." + myVersion.Build;
            Closing += VM.OnClosing;
        }
    }
}
