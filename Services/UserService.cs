using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mod08.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using static Mod08.Model.User;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace Mod08.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        // Base URL for the API endpoints
        private const string BaseUrl = "http://localhost/PDC50/";

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        // GET USERS
        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<User>>($"{BaseUrl}get_user.php");
                return response ?? new List<User>();
            }
            catch (Exception ex)
            {
                // Log exception if necessary
                Console.WriteLine($"Error fetching users: {ex.Message}");
                return new List<User>();
            }
        }

        // ADD USER
        public async Task<string> AddUserAsync(User user)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}add_user.php", user);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log exception if necessary
                Console.WriteLine($"Error adding user: {ex.Message}");
                return "Error";
            }
        }

        // UPDATE USER
        public async Task<string> UpdateUserAsync(User user)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}update_user.php", user);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log exception if necessary
                Console.WriteLine($"Error updating user: {ex.Message}");
                return "Error";
            }
        }

        // DELETE USER
        public async Task<string> DeleteUserAsync(int userID)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}delete_user.php", new { ID = userID });
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log exception if necessary
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return "Error";
            }
        }

        // MARK ATTENDANCE
        // Services/UserService.cs


        public async Task<string> UpdateAttendanceAsync(int userID, string attendanceType)
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                    { "id", userID.ToString() },
                    { "status", attendanceType }
                };

                var content = new FormUrlEncodedContent(values);
                var response = await _httpClient.PostAsync($"{BaseUrl}mark_attendance.php", content);
                var result = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode ? "Success" : result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating attendance: {ex.Message}");
                return "Error";
            }
        }


        public async Task<List<Ledger>> GetLedgerEntriesAsync(int userId)
        {
            try
            {
                Console.WriteLine($"Sending request for UserID: {userId}"); // Debug log
                var response = await _httpClient.GetAsync($"{BaseUrl}get_ledger.php?UserID={userId}"); // Use 'UserID'
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<Ledger>>() ?? new List<Ledger>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching ledger entries: {ex.Message}");
                return new List<Ledger>();
            }
        }





        /// <summary>
        /// Represents a standard API response.
        /// </summary>
        //public class ApiResponse
        //{
        //    [JsonPropertyName("message")]
        //    public string Message { get; set; }

        //    // Indicates whether the API call was successful
        //    [JsonIgnore]
        //    public bool IsSuccess { get; set; }
        //}
    }
}
