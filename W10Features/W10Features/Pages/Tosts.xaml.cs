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

        private void btnLocalToast01_Click(object sender, RoutedEventArgs e)
        {
            ToastNotification toast = new ToastNotification(ToastNotificationHelper.getToastTemplate());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private void btnLocalToast02_Click(object sender, RoutedEventArgs e)
        {
            ToastNotification toast = new ToastNotification(ToastNotificationHelper.getXmlToast());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private void btnLocalActionToast01_Click(object sender, RoutedEventArgs e)
        {
            ToastNotification toast = new ToastNotification(ToastNotificationHelper.getXmlToastWithAction());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
