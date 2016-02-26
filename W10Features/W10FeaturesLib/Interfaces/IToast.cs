using Windows.UI.Notifications;

namespace W10FeaturesLib.Interfaces
{
    interface IToast
    {
        void showToast(ToastTemplateType type);
    }
}
