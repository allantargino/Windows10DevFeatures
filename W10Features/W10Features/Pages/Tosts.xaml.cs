using Windows.Data.Xml.Dom;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Notifications;
using W10FeaturesLib.Models;
using System;

namespace W10FeaturesLib.Pages
{
    public sealed partial class Tosts : Page
    {
        Toast toast;
        
        public Tosts()
        {
            this.InitializeComponent();

            var templates = Enum.GetValues(typeof(ToastTemplateType));
            foreach (ToastTemplateType template in templates)
            {
                cmbTemplates.Items.Add(template.ToString());
            }
            cmbTemplates.SelectedIndex = 0;

            toast = new Toast
            {
                HeadlineText = "Title goes here",
                BodyText1 = "Content1 goes here",
                BodyText2 = "Content2 goes here",
                Image = "ms-appx:///assets/cartoon-sun.gif",
                ImgAlt = "Image text alternative"
            };
        }

        private void btnLocalToast_Click(object sender, RoutedEventArgs e)
        {
            var template = (ToastTemplateType)Enum.Parse(typeof(ToastTemplateType), cmbTemplates.SelectedValue.ToString());
            toast.showToast(template);
        }
    }
}
