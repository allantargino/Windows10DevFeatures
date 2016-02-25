using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using W10Features.Models;

namespace W10Features.Helpers
{
    public static class ToastNotificationHelper
    {
        //Ref: https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.notifications.toasttemplatetype

        public static XmlDocument getToastTemplate()
        {
            Toast t = new Toast();

            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText02;
            XmlDocument toastXML = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTexts = toastXML.GetElementsByTagName("text");
            toastTexts[0].AppendChild(toastXML.CreateTextNode(t.Title));
            toastTexts[1].AppendChild(toastXML.CreateTextNode(t.Content));

            //Square 150x150
            XmlNodeList toastImg = toastXML.GetElementsByTagName("image");
            XmlElement img = (XmlElement)toastImg[0];
            img.SetAttribute("src", t.Image);
            img.SetAttribute("alt", t.ImgAlt);

            return toastXML;
        }

        public static XmlDocument getXmlToast()
        {
            Toast t = new Toast();
            string title = t.Title;
            string content = t.Content;
            string image = t.Image;

            string toastXMLInner =
            $@"<toast>
                <visual>
                    <binding template='ToastGeneric'>
                        <text>{title}</text>
                        <text>{content}</text>
                        <image src='{image}' placement='appLogoOverride'/>
                        <image src='{image}' placement='inline'/>
                    </binding>
                </visual>
            </toast>";

            XmlDocument toastXML = new XmlDocument();
            toastXML.LoadXml(toastXMLInner);

            return toastXML;
        }

        public static XmlDocument getXmlToastWithAction()
        {
            Toast t = new Toast();
            string title = t.Title;
            string image = t.Image;

            string toastXMLInner =
            $@"<toast>
                <visual>
                    <binding template='ToastGeneric'>
                        <text>{title}</text>
                        <image src='{image}' placement='appLogoOverride'/>
                    </binding>
                </visual>
                <actions>
                    <input id='time' type='selection' defaultInput='2' >" +
                    t.getFormatedSelections() +
                   "</input >" +
                    t.getFormatedActions() + 
             $@"</actions>
            </toast>";

            XmlDocument toastXML = new XmlDocument();
            toastXML.LoadXml(toastXMLInner);

            return toastXML;
        }
    }
}
