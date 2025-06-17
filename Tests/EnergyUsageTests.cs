public class EnergyUsageTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public EnergyUsageTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAll_ShouldReturn200()
    {
        var response = await _client.GetAsync("/api/EnergyUsage?page=1&pageSize=5");
        response.EnsureSuccessStatusCode();
    }
}
