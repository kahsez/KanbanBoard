namespace KanbanBoard.Backend.Domain;

public class Board
{
    public string Name { get; set; }
    
    public Board(string name)
    {
        Name = name;
    }

}