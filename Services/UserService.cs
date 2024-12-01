using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod08.Model;
using System.Net.Http.Json;


namespace Mod08.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        //for the api connection
        private const string BaseUrl = "http://localhost/PDC50/";

        public UserService()
        {
            _httpClient = new HttpClient();
        }


        //GET USER
        public async Task<List<User>> GetUsersAsync()
        {
            var response =
                await _httpClient.GetFromJsonAsync<List<User>>($"{BaseUrl}get_user.php");
            return response ?? new List<User>();
        }

        //ADD USER
        public async Task<string>AddUserAsync(User user)
        {
            var response = 
                await _httpClient.PostAsJsonAsync($"{BaseUrl}add_user.php", user);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        //UPDATE USER
        public async Task<string> UpdateUserAsync(User user)
        {
            var response =
                await _httpClient.PostAsJsonAsync($"{BaseUrl}update_user.php", user);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        //DELETE USER
        public async Task<string> DeleteUserAsync(int userID)
        {
            var response =
                await _httpClient.PostAsJsonAsync($"{BaseUrl}delete_user.php", new { ID = userID });
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
