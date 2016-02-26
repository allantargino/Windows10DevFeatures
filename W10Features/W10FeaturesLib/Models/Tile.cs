using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using W10FeaturesLib.Helpers;
using W10FeaturesLib.Enums;
using W10FeaturesLib.Interfaces;

namespace W10FeaturesLib.Models
{
    public class Tile : ITile
    {
        private TileUpdater _tileUpdater;
        private BadgeUpdater _badgeUpdater;

        public string Caption { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public TileBranding Branding { get; set; }
        public string DisplayName { get; set; }

        public Tile()
        {
            _tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
            _badgeUpdater = BadgeUpdateManager.CreateBadgeUpdaterForApplication();
        }

        public Tile(string caption, string message1, string message2, TileBranding branding, string displayName):this()
        {
            Caption = caption;
            Message1 = message1;
            Message2 = message2;
            Branding = branding;
            DisplayName = displayName;
        }

        public void UpdateTiles()
        {
            var xmlDoc = TileHelper.CreateTiles(this);
            var notification = new TileNotification(xmlDoc);
            _tileUpdater.Update(notification);
        }

        public void UpdateCount(int count)
        {
            var badgeXml = TileHelper.CreateBadgeNumber(count);
            var badge = new BadgeNotification(badgeXml);
            _badgeUpdater.Update(badge);
        }

    }
}
