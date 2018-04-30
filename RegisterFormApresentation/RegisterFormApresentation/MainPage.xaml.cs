using System;
using Xamarin.Forms;

namespace RegisterFormApresentation
{
    public partial class MainPage : ContentPage
    {
        static Lazy<RegisterDatabase> _database
            = new Lazy<RegisterDatabase>(
                valueFactory:() => new RegisterDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("RegistationSQLite.db3")),
                isThreadSafe: true);

        static RegisterDatabase Database
            => _database.Value;

        RegistrationModel _formViewModel;

        public MainPage()
        {
            InitializeComponent();
            ResetBindingContext();
        }

        private void ResetBindingContext()
        {
            BindingContext = _formViewModel = new RegistrationModel();
        }

        void OnSave(object sender, EventArgs e)
        {
            var success = Validate();

            if (success)
            {
                Database.Add(_formViewModel);
                ResetBindingContext();
            }
        }

        bool Validate()
        {
            var success = true;
            Action<string> displayValidationAlert = (string field) =>
            {
                success = false;
                DisplayAlert(title: "Validação", message: $"{field} não informado", cancel: "Ok");
            };
                

            if (_formViewModel.Name == null) displayValidationAlert.Invoke("Nome");
            else if (_formViewModel.Surname == null) displayValidationAlert.Invoke("Sobrenome");
            else if (_formViewModel.Document == null)   displayValidationAlert.Invoke("CPF");
            else if (_formViewModel.Email == null) displayValidationAlert.Invoke("Email");
            else if (_formViewModel.Birthday == null) displayValidationAlert.Invoke("Data de nascimento");
            else if (_formViewModel.Address == null) displayValidationAlert.Invoke("Endreço");
            else if (_formViewModel.Password == null) displayValidationAlert.Invoke("Senha");
            else if (_formViewModel.ConfirmPassword == null) displayValidationAlert.Invoke("Confirmação de senha");

            return success;
        }
    }
}
