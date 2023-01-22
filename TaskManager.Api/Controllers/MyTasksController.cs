using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MyTasksController : ControllerBase
{
    private readonly IMyTaskRepository _myTaskRepository;
    private readonly IAuthenticationRepository _authenticationRepository;

    public MyTasksController(IMyTaskRepository myTaskRepository, IAuthenticationRepository authenticationRepository)
    {
        _myTaskRepository = myTaskRepository;
        _authenticationRepository = authenticationRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Register(MyTask myTask, [FromHeader(Name = "Authorization")] string authorization)
    {
        try
        {
            _authenticationRepository.Authenticate(authorization);
            await _myTaskRepository.Register(myTask);
            return Ok();
        }
        catch (Exception e)
        {
            return e.Message == "Invalid credentials" ? Problem(statusCode: 401) : Problem();
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Find([FromHeader(Name = "Authorization")] string authorization, [FromQuery] DateTime date = default)
    {
        try
        {
            _authenticationRepository.Authenticate(authorization);
            var tasks = date == default ? await _myTaskRepository.Find() : await _myTaskRepository.FindByDate(date);
            return Ok(tasks);
        }
        catch (Exception e)
        {
            return e.Message == "Invalid credentials" ? Problem(statusCode: 401) : Problem();
        }
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(string name, [FromHeader(Name = "Authorization")] string authorization)
    {
        try
        {
            _authenticationRepository.Authenticate(authorization);
            await _myTaskRepository.Delete(name);
            return Ok();
        }
        catch (Exception e)
        {
            return e.Message == "Invalid credentials" ? Problem(statusCode: 401) : Problem();
        }
    }
}