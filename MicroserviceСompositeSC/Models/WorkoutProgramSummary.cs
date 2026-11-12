using System.Text.Json.Serialization;

namespace MicroserviceCompositeSC.Models;

public class WorkoutProgramSummary
{
    [JsonPropertyName("programName")]
    public string ProgramName { get; set; } = string.Empty;

    [JsonPropertyName("goal")]
    public string Goal { get; set; } = string.Empty;

    [JsonPropertyName("workoutsPerWeek")]
    public int WorkoutsPerWeek { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
}