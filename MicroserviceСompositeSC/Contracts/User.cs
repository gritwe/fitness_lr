using System;
using System.Text.Json.Serialization;

namespace MicroserviceCompositeSC.Models;

public class User
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("workoutProgramId")]
    public int WorkoutProgramId { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; } = string.Empty;

    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; } = string.Empty;

    [JsonPropertyName("login")]
    public string Login { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
} 