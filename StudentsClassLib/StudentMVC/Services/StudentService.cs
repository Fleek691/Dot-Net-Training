using StudentMVC.Models;
using System.Text;
using System.Text.Json;

namespace StudentMVC.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "students";

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = new List<Student>();

            HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                students = JsonSerializer.Deserialize<List<Student>>(data,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return students ?? new List<Student>();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_baseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Student>(data,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<HttpResponseMessage> CreateStudentAsync(CreateStudentViewModel model)
        {
            var payload = new
            {
                FullName = model.FullName,
                Email = model.Email,
                Phone = model.Phone
            };

            string jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync(_baseUrl, content);
        }

        public async Task<HttpResponseMessage> UpdateStudentAsync(int id, EditStudentViewModel model)
        {
            var payload = new
            {
                StudentId = model.StudentId,
                FullName = model.FullName,
                Email = model.Email,
                Phone = model.Phone
            };

            string jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            return await _httpClient.PutAsync($"{_baseUrl}/{id}", content);
        }

        public async Task<HttpResponseMessage> DeleteStudentAsync(int id)
        {
            return await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }
    }
}
