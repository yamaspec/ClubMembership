using EmployeeComponent;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EmployeeUWPApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<EmployeeViewModel> _employeesOC = null;
        public XamlUICommand ChangeFirstNameCommand = null;

        public MainPage()
        {
            this.InitializeComponent();
            Employees employees = new Employees();
            _employeesOC = employees.GetEmployees();

            // ListView from xaml file
            EmployeesList.ItemsSource = _employeesOC;
            ChangeFirstNameCommand = new XamlUICommand();
            // Subcribe to a method to update the First Name of the selected item in the employee list.
            ChangeFirstNameCommand.ExecuteRequested += ChangeFirstNameCommand_ExecuteRequested;

            btnThankYou.Click += BtnThankYou_ClickAsync;
        }

        private async void ChangeFirstNameCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            ListView lv = (ListView)args.Parameter;
            if (lv.SelectedIndex != -1)
            {
                await SpeakAsync($"Changing First name, from {_employeesOC[lv.SelectedIndex].FirstName}, to, {txtFirstName.Text}");
                _employeesOC[lv.SelectedIndex].FirstName = txtFirstName.Text;  // TextBox from the xaml file.
            }
        }

        private async Task SpeakAsync(string text)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(text);
            mediaElement.SetSource(stream, stream.ContentType);

        }

        public async void BtnThankYou_ClickAsync(object sender, RoutedEventArgs e)
        {
            await SpeakAsync("Thank you, and take care.");
        }
    }
}
