using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using System.Xml.Linq;
using W10Features.Models;

namespace W10Features
{
    public static class LiveTileHelper
    {
        static public void updateCount(int count)
        {
            XmlDocument badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);
            XmlElement badgeElement = (XmlElement)badgeXml.SelectSingleNode("/badge");
            badgeElement.SetAttribute("value", count.ToString());
            BadgeNotification badge = new BadgeNotification(badgeXml);
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badge);
        }



    }
}
