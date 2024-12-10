using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mod08.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _loginMessage;
        public string LoginMessage
        {
            get => _loginMessage;
            set
            {
                if (_loginMessage != value)
                {
                    _loginMessage = value;
                    OnPropertyChanged();
                }
            }
        }



        private int _presentCount;
        public int PresentCount
        {
            get => _presentCount;
            set
            {
                if (_presentCount != value)
                {
                    _presentCount = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _absentCount;
        public int AbsentCount
        {
            get => _absentCount;
            set
            {
                if (_absentCount != value)
                {
                    _absentCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand AttendanceCommand { get; }
        public ICommand GradeCommand { get;  }
        public ICommand PaymentCommand { get; }
        public ICommand ManageStudentsCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand LogoutCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await ExecuteLogin());
            AttendanceCommand = new Command(async () => await Attendance());
            GradeCommand = new Command(async () => await Grades());
            PaymentCommand = new Command(async () => await Payment());
            ManageStudentsCommand = new Command(async () => await ManageStudents());
            BackCommand = new Command(async () => await Back());
            LogoutCommand = new Command(async () => await Logout());
        }

        private async Task ExecuteLogin()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                LoginMessage = "Please enter both username and password.";
                return;
            }

            // Simulate login logic (replace this with API logic)
            if (Username == "admin" && Password == "admin") // Replace with actual validation
            {
                LoginMessage = "Login successful!";
                await Shell.Current.GoToAsync("//NavigationPage", true); // Navigate on success
            }
            else
            {
                LoginMessage = "Invalid username or password.";
            }
            ClearInput();
        }

        private void ClearInput()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        // ATTENDACE PAGE 
        private async Task Attendance()
        {
                await Shell.Current.GoToAsync("//AttendancePage"); // Navigate on success
        }

        // USER PAGE
        private async Task ManageStudents()
        {
            await Shell.Current.GoToAsync("//UserPage"); // Navigate on success
        }

        // PAYMENT PAGE
        private async Task Payment()
        {
            await Shell.Current.GoToAsync("//PaymentPage"); // Navigate on success
        }

        // GRADE PAGE
        private async Task Grades()
        {
            await Shell.Current.GoToAsync("//GradePage"); // Navigate on success
        }


        // BACK METHOD 
        private async Task Back()
        {
            // Fallback if there's no valid page in the stack
            await Shell.Current.GoToAsync("//NavigationPage");
        }

        private async Task Logout()
        {
            // Display a confirmation dialog to the user
            bool confirmLogout = await App.Current.MainPage.DisplayAlert(
                "Logout Confirmation",
                "Are you sure you want to log out?",
                "Yes",
                "No");

            // If the user confirms, proceed with the logout
            if (confirmLogout)
            {
                // Clear user-related data
                Username = string.Empty;
                Password = string.Empty;
                LoginMessage = string.Empty;

                // Navigate to the LoginPage and reset the navigation stack
                await Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                // Optionally, do nothing or log a message
                Console.WriteLine("Logout canceled by the user.");
            }
        }


        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
