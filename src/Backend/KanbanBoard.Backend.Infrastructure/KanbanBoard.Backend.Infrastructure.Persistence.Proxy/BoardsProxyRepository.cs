using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Domain;
using KanbanBoard.Backend.Infrastructure.Persistence.EFCore;
using KanbanBoard.Backend.Infrastructure.Persistence.InMemory;
using Microsoft.FeatureManagement;

namespace KanbanBoard.Backend.Infrastructure.Persistence.Proxy;

public class BoardsProxyRepository(IVariantFeatureManager featureManager) : IBoardsRepository
{
    private IBoardsRepository? repository;

    private async Task<IBoardsRepository> Repository()
    {
        if (repository != null) return repository;
        
        var isEnabledEfCoreRepository = await featureManager.IsEnabledAsync("EFCoreRepository");
        if (isEnabledEfCoreRepository)
        {
            repository = new BoardsEfCoreRepository();
        }
        else
        {
            repository = new BoardsInMemoryRepository();
        }

        return repository;
    }

    public async Task<Board> Create(Board board)
    {
        return await (await Repository()).Create(board);
    }

    public async Task<IEnumerable<Board>> GetAll()
    {
        return await (await Repository()).GetAll();
    }

    public async Task<Board?> GetById(int id)
    {
        return await (await Repository()).GetById(id);
    }

    public async Task<Board> Update(Board board)
    {
        return await (await Repository()).Update(board);
    }

    public async Task<int> Delete(int id)
    {
        return await (await Repository()).Delete(id);
    }
}