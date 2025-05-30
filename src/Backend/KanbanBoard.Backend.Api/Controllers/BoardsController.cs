using KanbanBoard.Backend.Application.Dtos;
using KanbanBoard.Backend.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardsController(GetBoards getBoards, CreateBoard createBoard) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<BoardResponse>> Get()
    {
        return await getBoards.Empty();
    }

    [HttpPost]
    public async Task<ActionResult<BoardResponse>> Create(CreateBoardRequest data)
    {
        var board = await createBoard.EmptyWith(data);
        return Created("", board);
    }
}