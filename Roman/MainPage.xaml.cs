using Roman.custom;

namespace Roman;

public partial class MainPage : ContentPage
{
    Converter converter = new Converter();
    private int KeyValue;
    private int CurrentState = 0;
    
    public MainPage()
    {
        InitializeComponent();
    }

    private void Reset(object sender, EventArgs e)
    {
        txtRoman.Text = "";
        txtNumber.Text = "";
    }

    private void Convert(object sender, EventArgs e)
    {
        if (txtNumber.Text != "" && CurrentState == 1)
        {
            int.TryParse(txtNumber.Text, out KeyValue);
            if (KeyValue < 1)
            {
                DisplayAlert("Error", "Enter a Number > 0", "Ok");
            }
            else
            {
                txtRoman.Text = converter.NumberToRoman(KeyValue);
                txtNumber.Text = "";
                CurrentState = 2;
            }
        }
        else if (txtRoman.Text != "" && CurrentState == 2)
        {
            txtNumber.Text = converter.RomanToNumber(txtRoman.Text).ToString();
            txtRoman.Text = "";
            CurrentState = 1;
        }
    }

    private void TxtNumber_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        CurrentState = 1;
    }

    private void TxtRoman_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        CurrentState = 2;
    }
}