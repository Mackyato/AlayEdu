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
    
        // Observable collection to store the list of users
        public ObservableCollection<User> Users { get; set; }
        private List<User> _allUsers; //FILTER

        // Observable collection for courses
        public ObservableCollection<string> Courses { get; set; }

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
        private string _courseInput;
        public string CourseInput
        {
            get => _courseInput;
            set
            {
                if (_courseInput != value)
                {
                    _courseInput = value;
                    OnPropertyChanged();
                }
            }
        }

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

        // Commands for add, update, and delete
        public ICommand LoadUserCommand { get; }
        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand LoadUsersByCourseCommand { get; }

        public UserViewModel()
        {
            _userService = new UserService();
            Users = new ObservableCollection<User>();
            _allUsers = new List<User>(); //FILTER
            Courses = new ObservableCollection<string> { "BSIT", "BSCS", "BMMA" }; // Predefined list of courses

            // Initialize Commands
            AddUserCommand = new Command(async () => await AddUser());
            UpdateUserCommand = new Command(async () => await UpdateUser());
            DeleteUserCommand = new Command(async () => await DeleteUser());
            LoadUserCommand = new Command(async () => await LoadUsers());
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
            if (!string.IsNullOrWhiteSpace(FirstNameInput) &&
                !string.IsNullOrWhiteSpace(LastNameInput) &&
                !string.IsNullOrWhiteSpace(EmailInput) &&
                !string.IsNullOrWhiteSpace(LastNameInput) &&
                !string.IsNullOrWhiteSpace(ContactNoInput) &&
                !string.IsNullOrWhiteSpace(CourseInput))
            {
                var newUser = new User
                {
                    Firstname = FirstNameInput,
                    Lastname = LastNameInput,
                    Email = EmailInput,
                    ContactNo = ContactNoInput,
                    Course = SelectedCourse // Add selected course to the new user
                };
                var result = await _userService.AddUserAsync(newUser);

                if (result.Equals("Success", StringComparison.OrdinalIgnoreCase))
                {
                    await LoadUsers();
                    ClearInput();
                }
            }
            else
            {
                Console.WriteLine("Input validation failed: All fields must be filled.");
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
                await LoadUsers();
                ClearInput();
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to update student: {result}");
            }
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
            CourseInput = string.Empty;
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
                CourseInput = SelectedCourse;
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

        // INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
