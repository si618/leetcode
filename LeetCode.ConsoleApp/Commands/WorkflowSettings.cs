namespace LeetCode.ConsoleApp.Commands;

public sealed class WorkflowSettings : CommandSettings
{
    [CommandArgument(0, "[filter]")]
    public string Filter { get; init; } = "LeetCode.*";

    [CommandOption("--exporters")]
    public string Exporters { get; init; } = "json";

    [CommandOption("--memory")]
    public bool Memory { get; init; } = true;
}
