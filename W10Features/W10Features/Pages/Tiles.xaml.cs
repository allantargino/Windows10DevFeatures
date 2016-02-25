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
using W10Features.Models;
using W10Features.Helpers;
using Windows.UI.Notifications;

namespace W10Features.Pages
{

    public sealed partial class Tiles : Page
    {
        public Tiles()
        {
            this.InitializeComponent();
        }

        private void btnUpdateBadge(object sender, RoutedEventArgs e)
        {
            int num;
            if (int.TryParse(tbxNum.Text, out num))
            {
                LiveTileHelper.UpdateCount(num);
            }
        }

        private void btnUpdatePrimaryTile(object sender, RoutedEventArgs e)
        {
            LiveTileHelper.UpdateTiles();
        }
    }
}
