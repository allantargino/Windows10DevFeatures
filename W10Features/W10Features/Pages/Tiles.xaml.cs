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
using W10FeaturesLib.Models;
using W10FeaturesLib.Enums;

namespace W10FeaturesLib.Pages
{

    public sealed partial class Tiles : Page
    {
        Tile tile;

        public Tiles()
        {
            this.InitializeComponent();
            tile = new Tile
            {
                Caption = "My Tile",
                Message1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore.",
                Message2 = " At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident.",
                Branding = TileBranding.nameAndLogo,
                DisplayName = "AppName"
            };
        }

        private void btnUpdateBadge(object sender, RoutedEventArgs e)
        {
            int num;
            if (int.TryParse(tbxNum.Text, out num))
            {
                tile.UpdateCount(num);
            }
        }

        private void btnUpdatePrimaryTile(object sender, RoutedEventArgs e)
        {
            tile.UpdateTiles();
        }
    }
}
