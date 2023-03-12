using RaspCalc.Interfaces;
using RaspCalc.Services;

namespace RaspCalc;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        DependencyService.RegisterSingleton<IScrollService>(new ScrollService(ScrollViewObject));
    }

}
