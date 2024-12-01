﻿using Mod08.Services;
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

namespace Mod08.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly UserService _userService;

        // Observable collection to store the list of users
        public ObservableCollection<User> Users { get; set; }

        // Observable collection for courses
        public ObservableCollection<string> Courses { get; set; }

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

        // Commands for add, update, and delete
        public ICommand LoadUserCommand { get; }
        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand LoadUsersByCourseCommand { get; }

        public UserViewModel()
        {
            _userService = new UserService();
            Courses = new ObservableCollection<string> { "BSIT", "BSCS", "BMMA" }; // Predefined list of courses
            Users = new ObservableCollection<User>();

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
            Users.Clear();
            foreach (var user in users)
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
                !string.IsNullOrWhiteSpace(ContactNoInput)&&
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
            if (SelectedUser == null) //{
                SelectedUser.Firstname = FirstNameInput;
                SelectedUser.Lastname = LastNameInput;
                SelectedUser.Email = EmailInput;
                SelectedUser.ContactNo = ContactNoInput;
                SelectedUser.Course = SelectedCourse;

                var result = await _userService.UpdateUserAsync(SelectedUser);
                //if (result.Equals("Success", StringComparison.OrdinalIgnoreCase))
               // {
                    await LoadUsers();
                 //   ClearInput();
                 //   Console.WriteLine("Student updated successfully.");
             ///  }
              //  else
              //  {
//Console.WriteLine($"Failed to update student: {result}");
             //   }
            //}
            //else
            //{
            //    Console.WriteLine("No student selected for update.");
            //}
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
            CourseInput = null;
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

        // INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
