using System;
using System.Collections.Generic;
using W10FeaturesLib.Helpers;
using W10FeaturesLib.Interfaces;
using Windows.UI.Notifications;

namespace W10FeaturesLib.Models
{
    public class Toast : IToast
    {
        private ToastNotifier _toastNotifier;

        public string HeadlineText { get; set; }
        public string BodyText1 { get; set; }
        public string BodyText2 { get; set; }
        public string Image { get; set; }
        public string ImgAlt { get; set; }


        public Toast()
        {
            _toastNotifier = ToastNotificationManager.CreateToastNotifier();
        }

        public Toast(string headlineText, string bodyText1, string bodyText2, string image, string imgAlt) : this()
        {
            HeadlineText = headlineText;
            BodyText1 = bodyText1;
            BodyText2 = bodyText2;
            Image = image;
            ImgAlt = imgAlt;
        }

        public void showToast(ToastTemplateType type)
        {
            var xmlDoc = ToastHelper.CreateToast(this, type);
            var notification = new ToastNotification(xmlDoc);
            _toastNotifier.Show(notification);
        }
    }
}
