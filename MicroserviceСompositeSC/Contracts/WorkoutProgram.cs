using System;
using System.Text.Json.Serialization;

namespace MicroserviceCompositeSC.Models;

public class WorkoutProgram
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("goal")]
    public string Goal { get; set; } = string.Empty;

    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime EndDate { get; set; }

    [JsonPropertyName("workoutsPerWeek")]
    public int WorkoutsPerWeek { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
}