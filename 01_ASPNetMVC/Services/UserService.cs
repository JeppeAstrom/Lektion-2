using _01_ASPNetMVC.ViewModels.Register;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateUserAccountAsync(AppUser user, string password)
        {
            // Create a new instance of RegisterViewModel to send to the API
            var registerViewModel = new RegisterViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = password,
                ConfirmPassword = password
            };

            // Convert the RegisterViewModel to JSON
            var json = JsonSerializer.Serialize(registerViewModel);

            // Create a new HTTP request message with the JSON payload
            var request = new HttpRequestMessage(HttpMethod.Post, "https://your-api-url/api/register")
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };

            // Send the HTTP request to the API
            var response = await _httpClient.SendAsync(request);

            // Check if the response was successful
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SignInAsync(AppUser user, string password)
        {
            // Create a new instance of LoginViewModel to send to the API
            var loginViewModel = new LoginViewModel
            {
                Email = user.Email,
                Password = password,
                
            };

            // Convert the LoginViewModel to JSON
            var json = JsonSerializer.Serialize(loginViewModel);

            // Create a new HTTP request message with the JSON payload
            var request = new HttpRequestMessage(HttpMethod.Post, "https://your-api-url/api/login")
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };

            // Send the HTTP request to the API
            var response = await _httpClient.SendAsync(request);

            // Check if the response was successful
            return response.IsSuccessStatusCode;
        }
    }
}
