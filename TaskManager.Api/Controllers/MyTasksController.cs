using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MyTasksController : ControllerBase
{
    private readonly IMyTaskRepository _myTaskRepository;

    public MyTasksController(IMyTaskRepository myTaskRepository)
    {
        _myTaskRepository = myTaskRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Register(MyTask myTask)
    {
        await _myTaskRepository.Register(myTask);
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> Find()
    {
        var tasks = await _myTaskRepository.Find();
        return Ok(tasks);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string name)
    {
        await _myTaskRepository.Delete(name);
        return Ok();
    }
}