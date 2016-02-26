using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using System.Xml.Linq;
using W10Features.Models;

namespace W10Features
{
    public static class LiveTileHelper
    {

        public static void UpdateCount(int count)
        {
            XmlDocument badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);
            XmlElement badgeElement = (XmlElement)badgeXml.SelectSingleNode("/badge");
            badgeElement.SetAttribute("value", count.ToString());
            BadgeNotification badge = new BadgeNotification(badgeXml);
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badge);
        }

        public static void UpdateTiles()
        {
            var xmlDoc = CreateTiles(new Tile());
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            var notification = new TileNotification(xmlDoc);
            updater.Update(notification);
        }


        //Ref: https://msdn.microsoft.com/en-us/library/windows/apps/Mt186446.aspx
        public static XmlDocument CreateTiles(Tile tile)
        {
            XDocument xDoc = new XDocument(
               new XElement("tile", new XAttribute("version", 3),
                   new XElement("visual",
                       // Small Tile
                       new XElement("binding", new XAttribute("branding", tile.Branding), new XAttribute("displayName", tile.AppName), new XAttribute("template", "TileSmall"),
                           new XElement("group",
                               new XElement("subgroup",
                                   new XElement("text", tile.Time, new XAttribute("hint-style", "caption")),
                                   new XElement("text", tile.Message, new XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3))
                               )
                           )
                       ),

                       // Medium Tile
                       new XElement("binding", new XAttribute("branding", tile.Branding), new XAttribute("displayName", tile.AppName), new XAttribute("template", "TileMedium"),
                           new XElement("group",
                               new XElement("subgroup",
                                   new XElement("text", tile.Time, new XAttribute("hint-style", "caption")),
                                   new XElement("text", tile.Message, new XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3))
                           )
                           )
                       ),

                       // Wide Tile
                       new XElement("binding", new XAttribute("branding", tile.Branding), new XAttribute("displayName", tile.AppName), new XAttribute("template", "TileWide"),
                           new XElement("group",
                               new XElement("subgroup",
                                   new XElement("text", tile.Time, new XAttribute("hint-style", "caption")),
                                   new XElement("text", tile.Message, new XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3)),
                                   new XElement("text", tile.Message2, new XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3))
                                   ),
                               new XElement("subgroup", new XAttribute("hint-weight", 15),
                                   new XElement("image", new XAttribute("placement", "inline"), new XAttribute("src", "Assets/StoreLogo.png"))
                               )
                           )
                       ),

                       //Large Tile
                       new XElement("binding", new XAttribute("branding", tile.Branding), new XAttribute("displayName", tile.AppName), new XAttribute("template", "TileLarge"),
                           new XElement("group",
                               new XElement("subgroup",
                                   new XElement("text", tile.Time, new XAttribute("hint-style", "caption")),
                                   new XElement("text", tile.Message, new XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3)),
                                   new XElement("text", tile.Message2, new XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3))
                                   ),
                               new XElement("subgroup", new XAttribute("hint-weight", 15),
                                   new XElement("image", new XAttribute("placement", "inline"), new XAttribute("src", "Assets/StoreLogo.png"))
                               )
                           )
                       )
                   )
               )
           );

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xDoc.ToString());
            return xmlDoc;
        }

    }
}
