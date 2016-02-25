using Windows.Data.Xml.Dom;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Notifications;
using W10Features.Helpers;

namespace W10Features.Pages
{
    public sealed partial class Tosts : Page
    {
        public Tosts()
        {
            this.InitializeComponent();
        }

        private void btnLocalToastTemplate_Click(object sender, RoutedEventArgs e)
        {
            ToastNotification toast = new ToastNotification(ToastNotificationHelper.GetToastTemplate());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private void btnLocalToastXml_Click(object sender, RoutedEventArgs e)
        {
            ToastNotification toast = new ToastNotification(ToastNotificationHelper.GetXmlToast());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private void btnLocalActionToast_Click(object sender, RoutedEventArgs e)
        {
            ToastNotification toast = new ToastNotification(ToastNotificationHelper.GetXmlToastWithAction());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
