
namespace Backend.BackgroundServices;

public class EventSenderService : BackgroundService
{
    private readonly ILogger<EventSenderService> _logger;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public EventSenderService(ILogger<EventSenderService> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _configuration = configuration;
        _httpClient = httpClientFactory.CreateClient();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var eventHandlerUrl = _configuration["eventHandler:api_url"];

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var payload = new { key = "value" };
                _logger.LogInformation($"Sending request to {eventHandlerUrl}");
                var request = new HttpRequestMessage(HttpMethod.Post, eventHandlerUrl)
                {
                    Content = JsonContent.Create(payload)
                };
                var response = await _httpClient.SendAsync(request, stoppingToken);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending request: {ex.Message}");
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
