using ToastyLifts.ViewModels;

namespace ToastyLifts.Views;

public partial class MainPage : ContentPage
{
    private int count = 0;

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterBtn.Text = $"Clicked {count} {(count is 1 ? "time" : "times")}";
        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
