namespace RaspCalc;

public partial class App : Application
{

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        
        window.MinimumWidth = window.Width = 252;
        window.MinimumHeight = window.Height = 452;

        return window;
    }

}
