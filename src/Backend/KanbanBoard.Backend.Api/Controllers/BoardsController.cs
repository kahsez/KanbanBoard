using KanbanBoard.Backend.Application.Dtos;
using KanbanBoard.Backend.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardsController(GetBoards getBoards, CreateBoard createBoard, DeleteBoard deleteBoard) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<BoardResponse>> Get()
    {
        return await getBoards.All();
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BoardResponse>> GetById(int id)
    {
        var board = await getBoards.By(id);
        
        if (board == null)
            return NotFound();
        
        return board;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<BoardResponse>> Create(CreateBoardRequest data)
    {
        var board = await createBoard.EmptyWith(data);
        return CreatedAtAction(nameof(GetById), new {id = board.Id}, board);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var deletedBoards = await deleteBoard.With(id);

        if (deletedBoards == 0)
            return NotFound();
        
        return new NoContentResult();
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(int id)
    {
        var board = await getBoards.By(id);
        
        if (board == null)
            return NotFound();
        
        return new OkResult();
    }
}