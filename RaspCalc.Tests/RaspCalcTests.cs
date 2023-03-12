using RaspCalc.Models;
using RaspCalc.ViewModels;
using System.ComponentModel;

namespace Tests;

public class RaspCalcTests
{

    private readonly MainPageViewModel viewModel = new();

    [Fact]
    public void StringToNumber()
    {
        viewModel.Text = "1.5";
        Assert.True(viewModel.CurrentNumber.Value == 1.5M);
    }

    [Fact]
    public void NumberToString()
    {
        const decimal testVar = 12.500010000M;
        viewModel.CurrentNumber = testVar;
        Assert.Equal("12.50001", viewModel.Text);
    }

    [Fact]
    public void MultiplicationAndTrailingZeros()
    {
        const decimal testVarA = 2.5M, testVarB = 2M;
        viewModel.CurrentNumber = testVarA;
        viewModel.RequestMemory.Execute(NumericAction.Multiplication);
        Assert.Equal(testVarA, viewModel.Memory);
        Assert.Equal(NumericAction.Multiplication, viewModel.CurrentAction);
        viewModel.CurrentNumber = testVarB;
        viewModel.RequestAction.Execute(NumericAction.Multiplication);
        Assert.Equal("5", viewModel.Text);
        Assert.Null(viewModel.Memory);
        Assert.Null(viewModel.CurrentAction);
    }

    [Fact]
    public void EventHandler()
    {
        var properties = new HashSet<string>();
        void func(object sender, PropertyChangedEventArgs parameters) => properties.Add(parameters.PropertyName);
        viewModel.PropertyChanged += func;
        viewModel.CurrentNumber = 5;
        Assert.Contains(nameof(viewModel.CurrentNumber), properties);
        Assert.Contains(nameof(viewModel.Text), properties);
        viewModel.PropertyChanged -= func;
    }

}
