using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TheGamingCompany.Core.Options;

namespace TheGamingCompany.Core.ConversationalLanguageInterpreter;

public class LanguageInterpreter : ILanguageInterpreter
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<LanguageInterpreter> _logger;
    private readonly LanguageInterpreterOptions _options;

    public LanguageInterpreter(
        IOptions<LanguageInterpreterOptions> options,
        HttpClient httpClient,
        ILogger<LanguageInterpreter> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _options = options.Value;
    }
    public async Task<LanguageInterpreterResult> InterpretAsync(string query)
    {
        _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _options.SubscriptionKey);
        var request = new LangauageIntepreterRequest(
            "Conversation",
            new AnalysisInput(
                new ConversationItem(
                    "1",
                    "1",
                    query))
            , new Parameter(_options.ProjectName, "first-deployment", "TextElement_V8"));
        
        var requestJson = JsonSerializer.Serialize(request);
        var response = await _httpClient.PostAsync(_options.BaseUrl, new StringContent(requestJson, Encoding.UTF8, "application/json"));
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<LanguageInterpreterResult>(data);
        var (topIntent, projectKind, intents, entities) = result.result.prediction;
        _logger.LogInformation(result.result.ToString());
        return result;
    }
}