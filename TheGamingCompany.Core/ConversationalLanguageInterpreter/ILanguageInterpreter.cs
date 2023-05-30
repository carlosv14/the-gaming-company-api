namespace TheGamingCompany.Core.ConversationalLanguageInterpreter;

public record Entity(string category, string text, int offset, int length, decimal confidenceScore);
public record Intent(string category, decimal confidenceScore);
public record Prediction(string topIntent, string projectKind, Intent[] intents, Entity[] entities);

public record Result(string query, Prediction prediction);
public record LanguageInterpreterResult(string kind, Result result);

public record ConversationItem(string id, string participantId, string text);

public record Parameter(string projectName, string deploymentName, string stringIndexType);
public record AnalysisInput(ConversationItem conversationItem);
public record LangauageIntepreterRequest(string kind, AnalysisInput analysisInput, Parameter parameters);
public interface ILanguageInterpreter
{
    Task<LanguageInterpreterResult> InterpretAsync(string query);
}