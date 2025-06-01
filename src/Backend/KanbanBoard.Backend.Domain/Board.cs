namespace KanbanBoard.Backend.Domain;

public class Board
{
    public int Id { get; set; } 
    public string Name { get; set; }
    
    public Board(string name)
    {
        Name = name;
    }

}