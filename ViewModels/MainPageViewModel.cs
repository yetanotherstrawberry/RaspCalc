using RaspCalc.Helpers;
using RaspCalc.Interfaces;
using RaspCalc.Models;
using RaspCalc.Resources;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RaspCalc.ViewModels;

internal class MainPageViewModel : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private readonly Calculator Calc = new();
    private IScrollService mainScroller = null;

    private IScrollService MainScroller => mainScroller ??= DependencyService.Get<IScrollService>();
    public string Separator { get; private set; } = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
    public ICommand KeyboardButton { get; private set; }
    public ICommand TextErase { get; private set; }
    public ICommand TextClear { get; private set; }
    public ICommand AddRestrictedChar { get; private set; }
    public ICommand RequestMemory { get; private set; }
    public ICommand RequestAction { get; private set; }
    public ICommand ScrollToEnd { get; private set; }

    public string Text
    {
        get => Calc.Text;
        set
        {
            Calc.Text = value;
            OnPropertyChanged();
        }
    }

    public decimal? Memory
    {
        get => Calc.Memory;
        set
        {
            Calc.Memory = value;
            OnPropertyChanged();
        }
    }

    public decimal? CurrentNumber
    {
        get => Calc.CurrentNumber;
        set
        {
            Text = value?.ToString("G0");
            OnPropertyChanged();
        }
    }

    public NumericAction? CurrentAction
    {
        get => Calc.CurrentAction;
        private set
        {
            Calc.CurrentAction = value;
            OnPropertyChanged();
        }
    }

    private void Calculate(NumericAction? action)
    {
        try
        {
            if (action == null || CurrentNumber == null) return;

            CurrentNumber = action switch
            {
                NumericAction.Sum => Memory + CurrentNumber,
                NumericAction.Subtract => Memory - CurrentNumber,
                NumericAction.Multiplication => Memory * CurrentNumber,
                NumericAction.Division => Memory / CurrentNumber,
                NumericAction.Square => (decimal)Math.Pow((double)CurrentNumber, 2),
                NumericAction.SquareRoot => (decimal)Math.Sqrt((double)CurrentNumber),
                _ => throw new ArgumentException(message: AppRes.ERR_BAD_ACTION, paramName: nameof(action)),
            };

            Memory = null;
            CurrentAction = null;
        }
        catch (Exception ex)
        {
            Error.ShowError(ex);
        }
    }

    private void AddText(string text)
    {
        Text += text;
        MainScroller.ScrollEnd();
    }

    private void RemoveLastChar()
    {
        if (string.IsNullOrEmpty(Text)) return;
        var ret = Text.ToString();
        if (ret.Length > 0) Text = ret[..^1];
    }

    private void EraseText() => Text = string.Empty;

    private void AddCustomText(string text)
    {
        if (string.IsNullOrEmpty(Text))
            AddText("0");
        if (!Text.Contains(text))
            AddText(text);
    }

    private void AssignMemory(NumericAction action)
    {
        if (CurrentAction == null)
        {
            Memory = CurrentNumber;
            Text = string.Empty;
        }
        CurrentAction = action;
    }

    public MainPageViewModel()
    {
        KeyboardButton = new Command<string>(AddText);
        TextErase = new Command(RemoveLastChar);
        TextClear = new Command(EraseText);
        AddRestrictedChar = new Command<string>(AddCustomText);
        RequestMemory = new Command<NumericAction>(AssignMemory);
        RequestAction = new Command<NumericAction?>(Calculate);
    }

}
