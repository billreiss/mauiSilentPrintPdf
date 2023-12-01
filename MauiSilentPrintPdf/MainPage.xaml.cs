using Spire.Pdf;
using Spire.Pdf.Print;

namespace MauiSilentPrintPdf
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPrintClicked(object sender, EventArgs e)
        {
            try
            {
                PdfDocument pdf = new PdfDocument();
                var fileName = "sample-pdf-file.pdf";
                var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
                pdf.LoadFromStream(stream);
                // in the settings object you can set the printer name and a lot
                // of other options. No printer name prints to default.
                PdfPrintSettings settings = new PdfPrintSettings();
                settings.Color = false;
                pdf.Print(settings);
                StatusText.Text = "Print success!";
            } 
            catch (Exception ex)
            {
                StatusText.Text = ex.Message;
            }
        }
    }

}
