namespace RaspCalc.Models;

internal class Calculator
{

    private string text = string.Empty;
    public string Text
    {
        get => text;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                text = string.Empty;
            else text = value;
        }
    }
    public decimal? CurrentNumber => string.IsNullOrWhiteSpace(Text) ? default : decimal.Parse(Text);

    public decimal? Memory { get; set; } = default;

    public NumericAction? CurrentAction { get; set; } = default;

}
