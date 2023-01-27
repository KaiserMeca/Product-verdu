using CommunityToolkit.Mvvm.ComponentModel;

namespace Mvvm_Product.View_Models
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;
        [ObservableProperty]
        string title;
    }
}
