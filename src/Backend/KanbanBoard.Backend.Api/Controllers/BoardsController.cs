using KanbanBoard.Backend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.Backend.Api.Controllers;

[ApiController]
[Route("user/[controller]")]
public class BoardsController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Board> Get()
    {
        return new List<Board>();
    }
}