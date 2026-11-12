
using MicroserviceCompositeSC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MicroserviceCompositeSC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompositeSCController : ControllerBase
{
    private readonly string _userServiceAddress =
        "https://localhost:7124/api/Users";

    private readonly string _workoutProgramServiceAddress =
        "http://localhost:5109/api/WorkoutProgram";

    [HttpGet]
    public string Start()
    {
        return "Composite is run!";
    }

    [HttpGet("users/program/{programId:int}")]
    public async Task<IActionResult> GetUsersByProgramAsync(int programId)
    {
        using var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback =
                (sender, cert, chain, errors) => true
        };

        using var client = new HttpClient(handler);

        var response = await client.GetAsync(_userServiceAddress);

        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode,
                "Не удалось получить пользователей");
        }

        var users = await response.Content
            .ReadFromJsonAsync<List<User>>();

        if (users is null)
        {
            return StatusCode(502,
                "Не удалось прочитать список пользователей");
        }

        var result = users
            .Where(user => user.WorkoutProgramId == programId)
            .ToList();

        return Ok(result);
    }

    [HttpGet("programs/status/{status}")]
    public async Task<IActionResult> GetProgramsByStatusAsync(string status)
    {
        using var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback =
                (sender, cert, chain, errors) => true
        };

        using var client = new HttpClient(handler);

        var response = await client.GetAsync(
            _workoutProgramServiceAddress);

        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode,
                "Не удалось получить программы тренировок");
        }

        var programs = await response.Content
            .ReadFromJsonAsync<List<WorkoutProgram>>();

        if (programs is null)
        {
            return StatusCode(502,
                "Не удалось прочитать список программ");
        }

        var result = programs
            .Where(program => string.Equals(
                program.Status,
                status,
                StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Ok(result);
    }

    [HttpGet("statistics/program/{programId:int}")]
    public async Task<IActionResult> GetProgramStatisticsAsync(int programId)
    {
        using var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback =
                (sender, cert, chain, errors) => true
        };

        using var client = new HttpClient(handler);

        var usersResponse = await client.GetAsync(_userServiceAddress);

        if (!usersResponse.IsSuccessStatusCode)
        {
            return StatusCode((int)usersResponse.StatusCode,
                "Не удалось получить пользователей");
        }

        var users = await usersResponse.Content
            .ReadFromJsonAsync<List<User>>();

        if (users is null)
        {
            return StatusCode(502,
                "Не удалось прочитать список пользователей");
        }

        var programResponse = await client.GetAsync(
            $"{_workoutProgramServiceAddress}/{programId}");

        if (!programResponse.IsSuccessStatusCode)
        {
            return StatusCode((int)programResponse.StatusCode,
                "Не удалось получить программу тренировок");
        }

        var program = await programResponse.Content
            .ReadFromJsonAsync<WorkoutProgram>();

        if (program is null)
        {
            return StatusCode(502,
                "Не удалось прочитать программу тренировок");
        }

        int usersCount = users.Count(
            user => user.WorkoutProgramId == programId);

        double percentage = users.Count == 0
            ? 0
            : (double)usersCount / users.Count * 100;

        return Ok(new
        {
            programId = program.Id,
            programName = program.Name,
            usersCount = usersCount,
            usersPercentage = Math.Round(percentage, 2)
        });
    }
}
