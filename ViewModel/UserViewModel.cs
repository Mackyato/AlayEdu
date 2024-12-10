using Mod08.Services;
using Mod08.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Text.Json;

namespace Mod08.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly UserService _userService;
        // Services
        public ObservableCollection<User> Users { get; set; }         // Collections
        private List<User> _allUsers; // For filtering or other operations
        public ObservableCollection<string> Courses { get; set; } //For courses
        public ObservableCollection<Ledger> LedgerEntries { get; set; } //Ledger 
        // Input fields for user data
        private string _firstNameInput;
        public string FirstNameInput
        {
            get => _firstNameInput;
            set
            {
                if (_firstNameInput != value)
                {
                    _firstNameInput = value;
                    OnPropertyChanged();
                }
            }
        }

        // LASTNAME 
        private string _lastNameInput;
        public string LastNameInput
        {
            get => _lastNameInput;
            set
            {
                if (_lastNameInput != value)
                {
                    _lastNameInput = value;
                    OnPropertyChanged();
                }
            }
        }

        //EMAIL
        private string _emailInput;
        public string EmailInput
        {
            get => _emailInput;
            set
            {
                if (_emailInput != value)
                {
                    _emailInput = value;
                    OnPropertyChanged();
                }
            }
        }

        //CONTACT NO
        private string _contactNoInput;
        public string ContactNoInput
        {
            get => _contactNoInput;
            set
            {
                if (_contactNoInput != value)
                {
                    _contactNoInput = value;
                    OnPropertyChanged();
                }
            }
        }

        //COURSE
        //private string _courseInput;
        //public string CourseInput
        //{
        //    get => _courseInput;
        //    set
        //    {
        //        if (_courseInput != value)
        //        {
        //            _courseInput = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        // SELECTING USER
        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged();
                    UpdateEntryField();
                }
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    SearchUsers();
                }
            }
        }

        // SELECTING COURSE
        private string _selectedCourse;
        public string SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                if (_selectedCourse != value)
                {
                    _selectedCourse = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _filterCourse;

        public string FilterCourse
        {
            get => _filterCourse;
            set
            {
                if (_filterCourse != value)
                {
                    _filterCourse = value;
                    OnPropertyChanged();
                    FilterUsersByCourse(); //FILTER

                }
            }
        }

        // Loading Indicator
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (SetProperty(ref _isBusy, value))
                {
                    ((Command)LoadLedgerCommand).ChangeCanExecute();
                }
            }
        }



        private string _firstname;
        public string Firstname
        {
            get => _firstname;
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullName)); // Notify that FullName has changed
                }
            }
        }

        private string _lastname;
        public string Lastname
        {
            get => _lastname;
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullName)); // Notify that FullName has changed
                }
            }
        }
        public string FullName => $"{Firstname} {Lastname}";


        private string _selectedSchoolYear;
        public string SelectedSchoolYear
        {
            get => _selectedSchoolYear;
            set { SetProperty(ref _selectedSchoolYear, value); }
        }




        private DateTime _selectedSchoolYearDate = DateTime.Now; // Default to current date
        public DateTime SelectedSchoolYearDate
        {
            get => _selectedSchoolYearDate;
            set
            {
                if (SetProperty(ref _selectedSchoolYearDate, value))
                {
                    // Convert the chosen date to a string representing a school year if desired.
                    // For example, if you pick 2024, you might convert to "2024-25".
                    // This is just an example logic:
                    int year = value.Year;
                    SelectedSchoolYear = $"{year}-{(year + 1).ToString().Substring(2)}"; // e.g. 2024-25
                }
            }
        }


        // Commands for add, update, and delete
        public ICommand LoadUserCommand { get; }
        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand LoadUsersByCourseCommand { get; }

        public ICommand BackCommand { get; }
        public ICommand MarkAttendanceCommand { get; }

        public ICommand LoadLedgerCommand { get; }

        public UserViewModel()
        {
            _userService = new UserService();
            Users = new ObservableCollection<User>();
            _allUsers = new List<User>(); // For filtering
            Courses = new ObservableCollection<string> { "All", "BSIT", "BSCS", "BMMA" }; // Added "All" for filter
            LedgerEntries = new ObservableCollection<Ledger>();//Ledger

            // Initialize Commands
            AddUserCommand = new Command(async () => await AddUser());
            UpdateUserCommand = new Command(async () => await UpdateUser());
            DeleteUserCommand = new Command(async () => await DeleteUser());
            LoadUserCommand = new Command(async () => await LoadUsers());

            BackCommand = new Command(async () => await Back());

            MarkAttendanceCommand = new Command<Tuple<int, string>>(async (parameter) => await MarkAttendanceAsync(parameter));

            //LoadLedgerCommand = new Command(async (param) => await LoadLedger((int)param));
            LoadLedgerCommand = new Command<int>(async (userId) => await LoadLedger(userId));
        }

        // FOR LOADING THE STUDENTS
        private async Task LoadUsers()
        {
            var users = await _userService.GetUsersAsync();
            _allUsers.Clear();
            _allUsers.AddRange(users);


            // Initially populate the Users collection with all users
            Users.Clear();
            foreach (var user in _allUsers)
            {
                Users.Add(user);
            }
        }

        // ADDING STUDENT
        private async Task AddUser()
        {
            // Validate input, no need for selected user
            if (string.IsNullOrWhiteSpace(FirstNameInput) ||
                string.IsNullOrWhiteSpace(LastNameInput) ||
                string.IsNullOrWhiteSpace(EmailInput) ||
                string.IsNullOrWhiteSpace(ContactNoInput) ||
                string.IsNullOrWhiteSpace(SelectedCourse))  // Check for course input
            {
                Console.WriteLine("Input validation failed: All fields must be filled.");
                return; // Exit early if validation fails
            }

            try
            {
                // Create a new user object
                var newUser = new User
                {
                    Firstname = FirstNameInput,
                    Lastname = LastNameInput,
                    Email = EmailInput,
                    ContactNo = ContactNoInput,
                    Course = SelectedCourse
                };

                // Call the service to add the user (e.g., API or DB)
                var result = await _userService.AddUserAsync(newUser);

                if (result.Equals("Success", StringComparison.OrdinalIgnoreCase))
                {
                    // Reload users from the service (e.g., refresh UI)
                    await LoadUsers();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
            }
        }


        // Method to update an existing user
        private async Task UpdateUser()
        {
            if (SelectedUser == null)
            {
                Console.WriteLine("No student selected for update.");
                return;  // Exit if no user is selected
            }

            // Now it is safe to update the properties
            SelectedUser.Firstname = FirstNameInput;
            SelectedUser.Lastname = LastNameInput;
            SelectedUser.Email = EmailInput;
            SelectedUser.ContactNo = ContactNoInput;
            SelectedUser.Course = SelectedCourse;

            var result = await _userService.UpdateUserAsync(SelectedUser);

            if (result.Equals("Success", StringComparison.OrdinalIgnoreCase))
            {
                //LoadUsers();
                ClearInput();
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to update student: {result}");
            }
            LoadUsers();
            ClearInput();
        }

        // Method to delete a user
        private async Task DeleteUser()
        {
            if (SelectedUser != null)
            {
                var result = await _userService.DeleteUserAsync(SelectedUser.ID);
                await LoadUsers();
            }
        }

        // Method to clear input fields
        private void ClearInput()
        {
            FirstNameInput = string.Empty;
            LastNameInput = string.Empty;
            EmailInput = string.Empty;
            ContactNoInput = string.Empty;
            SelectedCourse = null;
        }

        // Method to update entry fields when a user is selected
        private void UpdateEntryField()
        {
            if (SelectedUser != null)
            {
                FirstNameInput = SelectedUser.Firstname;
                LastNameInput = SelectedUser.Lastname;
                EmailInput = SelectedUser.Email;
                ContactNoInput = SelectedUser.ContactNo;
                SelectedCourse = SelectedUser.Course;
            }
        }

        private void FilterUsersByCourse()
        {
            Users.Clear();
            var filteredUsers = string.IsNullOrEmpty(FilterCourse) || FilterCourse == "All"
                ? _allUsers
                : _allUsers.Where(u => u.Course == FilterCourse).ToList();

            foreach (var filter in filteredUsers)
            {
                Users.Add(filter);
            }
        }

        // Method to perform the search functionality
        private void SearchUsers()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Users.Clear();
                foreach (var search in _allUsers)
                {
                    Users.Add(search);
                }
            }
            else
            {
                var searchResult = _allUsers.Where(u =>
                    u.Firstname.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase) || // Search by First Name
                    u.Lastname.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase) ||   // Search by Last Name
                    (u.Firstname + " " + u.Lastname).StartsWith(SearchText, StringComparison.OrdinalIgnoreCase) // Full Name match
                ).ToList();

                Users.Clear();
                foreach (var search in searchResult)
                {
                    Users.Add(search);
                }
            }
        }


        private async Task LoadLedger(int userId)
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                // Fetch the user details from the existing Users collection
                SelectedUser = Users.FirstOrDefault(user => user.ID == userId);

                if (SelectedUser != null)
                {
                    // Fetch ledger data
                    var ledgerData = await _userService.GetLedgerEntriesAsync(userId);

                    // Clear and populate the ObservableCollection for ledger entries
                    LedgerEntries.Clear();
                    foreach (var ledger in ledgerData)
                    {
                        LedgerEntries.Add(ledger);
                    }
                }
                else
                {
                    Console.WriteLine("User not found for the provided userId.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading ledger: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task MarkAttendanceAsync(Tuple<int, string> parameter)
        {
            if (parameter == null || parameter.Item2 == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid attendance data.", "OK");
                return;
            }

            int userId = parameter.Item1;
            string attendanceType = parameter.Item2;

            try
            {
                var result = await _userService.UpdateAttendanceAsync(userId, attendanceType);

                if (result == "Success")
                {
                    // Find the user in the ObservableCollection
                    var user = Users.FirstOrDefault(u => u.ID == userId);
                    if (user != null)
                    {
                        if (attendanceType.Equals("Present", StringComparison.OrdinalIgnoreCase))
                        {
                            user.PresentCount++;
                        }
                        else if (attendanceType.Equals("Absent", StringComparison.OrdinalIgnoreCase))
                        {
                            user.AbsentCount++;
                        }
                    }

                    await Application.Current.MainPage.DisplayAlert("Success", "Attendance updated successfully.", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Failed to update attendance: {result}", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MarkAttendanceAsync: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
        private async Task Back()
        {
            // Navigate back or to a specific page
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
                // Navigate to the LoginPage and reset the navigation stack
                await Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                // Optionally, do nothing or log a message
                Console.WriteLine("Logout canceled by the user.");
            }
        }

        // INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}