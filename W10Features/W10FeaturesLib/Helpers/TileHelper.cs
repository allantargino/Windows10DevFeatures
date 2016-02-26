using Windows.Data.Xml.Dom;
using System.Xml.Linq;
using W10FeaturesLib.Models;
using Windows.UI.Notifications;

namespace W10FeaturesLib.Helpers
{
    internal class TileHelper
    {
        //Ref: https://msdn.microsoft.com/en-us/library/windows/apps/Mt186446.aspx
        internal static XmlDocument CreateTiles(Tile tile)
        {
            XDocument xDoc = new XDocument(
               new XElement("tile", new XAttribute("version", 3),
                   new XElement("visual",
                       // Small Tile
                       new XElement("binding", new XAttribute("branding", tile.Branding), new XAttribute("displayName", tile.DisplayName), new XAttribute("template", "TileSmall"),
                           new XElement("group",
                               new XElement("subgroup",
                                   new XElement("text", tile.Caption, new XAttribute("hint-style", "caption")),
                                   new XElement("text", tile.Message1, new XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3))
                               )
                           )
                       ),

                       // Medium Tile
                       new XElement("binding", new XAttribute("branding", tile.Branding), new XAttribute("displayName", tile.DisplayName), new XAttribute("template", "TileMedium"),
                           new XElement("group",
                               new XElement("subgroup",
                                   new XElement("text", tile.Caption, new XAttribute("hint-style", "caption")),
                                   new XElement("text", tile.Message1, new XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3))
                           )
                           )
                       ),

                       // Wide Tile
                       new XElement("binding", new XAttribute("branding", tile.Branding), new XAttribute("displayName", tile.DisplayName), new XAttribute("template", "TileWide"),
                           new XElement("group",
                               new XElement("subgroup",
                                   new XElement("text", tile.Caption, new XAttribute("hint-style", "caption")),
                                   new XElement("text", tile.Message1, new XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3)),
                                   new XElement("text", tile.Message2, new XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3))
                                   ),
                               new XElement("subgroup", new XAttribute("hint-weight", 15),
                                   new XElement("image", new XAttribute("placement", "inline"), new XAttribute("src", "Assets/StoreLogo.png"))
                               )
                           )
                       ),

                       //Large Tile
                       new XElement("binding", new XAttribute("branding", tile.Branding), new XAttribute("displayName", tile.DisplayName), new XAttribute("template", "TileLarge"),
                           new XElement("group",
                               new XElement("subgroup",
                                   new XElement("text", tile.Caption, new XAttribute("hint-style", "caption")),
                                   new XElement("text", tile.Message1, new XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3)),
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

        internal static XmlDocument CreateBadgeNumber(int number)
        {
            var badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);
            var badgeElement = (XmlElement)badgeXml.SelectSingleNode("/badge");
            badgeElement.SetAttribute("value", number.ToString());
            return badgeXml;
        }

    }
}
