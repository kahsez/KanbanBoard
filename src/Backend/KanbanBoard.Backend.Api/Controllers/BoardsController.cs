using KanbanBoard.Backend.Application.UseCases;
using KanbanBoard.Backend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardsController(GetBoards getBoards) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Board>> Get()
    {
        return await getBoards.Empty();
    }

    [HttpPost]
    public ActionResult<Board> Create([FromBody] string name)
    {
        return Created("", new Board(name));
    }
}