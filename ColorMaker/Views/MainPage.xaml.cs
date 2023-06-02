using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Diagnostics;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	bool isRandom;
	string hexValue;

    public ToastDuration Cmmunity { get; private set; }

    public MainPage()
	{
		InitializeComponent();
	}

    private void sldRed_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		if (!isRandom)
		{
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var bleu = sldBleu.Value;

            Color color = Color.FromRgb(red, green, bleu);

            SetColo(color);
        }
    }

    private void SetColo(Color color)
    {
		Debug.WriteLine(color.ToString());
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
        hexValue = color.ToHex();

        lblHex.Text = hexValue;
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
		isRandom = true;
		var random = new Random();

		var color = Color.FromRgb(
			random.Next(0,256),
			random.Next(0,256),
			random.Next(0,256));

		SetColo(color);

		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBleu.Value = color.Blue;

		isRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Clipboard.SetTextAsync(hexValue);

		var toast = Toast.Make("Color copied", ToastDuration.Short, 12);
		await toast.Show();
    }
}

