using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BarcodeScannerTest
{
    public partial class Test : ContentPage
    {
        public Test()
        {
            InitializeComponent();
        }

        async void ButtonClick(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);
        }
    }
}
