using MachinePark.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace MachinePark.Shared.Services
{
    public class MachineService
    {
        private readonly HttpClient _httpClient;

        public List<Machine> Machines { get; private set; } = new();

        public MachineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoadMachinesAsync()
        {
            Machines = await _httpClient.GetFromJsonAsync<List<Machine>>("machines") ?? new List<Machine>();
        }

        public async Task<Machine?> GetMachineByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Machine>($"machines/{id}");
        }

        public async Task AddMachineAsync(Machine machine)
        {
            var response = await _httpClient.PostAsJsonAsync("machines", machine);
            if (response.IsSuccessStatusCode)
            {
                Machines.Add(machine);
            }
        }

        public async Task UpdateMachineAsync(Machine machine)
        {
            var response = await _httpClient.PutAsJsonAsync($"machines/{machine.Id}", machine);
            if (response.IsSuccessStatusCode)
            {
                //var index = Machines.FindIndex(m => m.Id == machine.Id);
                //if (index != -1)
                //{
                //    Machines[index] = machine;
                //}
            }
        }

        public async Task DeleteMachineAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"machines/{id}");
            Console.WriteLine($"Delete response: {response.StatusCode}");
            if (response.IsSuccessStatusCode)
            {
                Machines.RemoveAll(m => m.Id == id);
            }
        }
    }
}
