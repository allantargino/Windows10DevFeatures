using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using W10FeaturesLib.Models;

namespace W10FeaturesLib.Helpers
{
    internal class ToastHelper
    {
        //Ref: https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.notifications.toasttemplatetype
        //Templates Ref: https://msdn.microsoft.com/en-us/library/windows/apps/hh761494.aspx
        internal static XmlDocument CreateToast(Toast toast, ToastTemplateType type)
        {
            XmlDocument toastXML = ToastNotificationManager.GetTemplateContent(type);

            XmlNodeList toastTexts = toastXML.GetElementsByTagName("text");
            if (type==ToastTemplateType.ToastText01 || type == ToastTemplateType.ToastImageAndText01)
            {
                toastTexts[0].AppendChild(toastXML.CreateTextNode(toast.HeadlineText));
            }else if(type == ToastTemplateType.ToastText02 || type == ToastTemplateType.ToastImageAndText02 ||
                     type == ToastTemplateType.ToastText03 || type == ToastTemplateType.ToastImageAndText03)
            {
                toastTexts[0].AppendChild(toastXML.CreateTextNode(toast.HeadlineText));
                toastTexts[1].AppendChild(toastXML.CreateTextNode(toast.BodyText1));
            }
            else
            {
                toastTexts[0].AppendChild(toastXML.CreateTextNode(toast.HeadlineText));
                toastTexts[1].AppendChild(toastXML.CreateTextNode(toast.BodyText1));
                toastTexts[2].AppendChild(toastXML.CreateTextNode(toast.BodyText2));
            }

            if (type.ToString().Contains("Image"))
            {
                XmlNodeList toastImg = toastXML.GetElementsByTagName("image");
                XmlElement img = (XmlElement)toastImg[0];
                img.SetAttribute("src", toast.Image);
                img.SetAttribute("alt", toast.ImgAlt);
            }

            return toastXML;
        }
    }
}
