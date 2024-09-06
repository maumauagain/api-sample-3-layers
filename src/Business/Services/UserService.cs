using Business.Interfaces;
using Business.Models;
using System.Linq.Expressions;

namespace Business.Services;

public interface IUserService
{
    Task Add(User user);
    Task Update (User user);
    Task Delete(Guid id);
    Task<User> GetById(Guid id);
    Task<IEnumerable<User>> GetAll();
    Task<IEnumerable<User>> Get(Expression<Func<User, bool>> predicate);
}
public class UserService : IUserService
{
    private readonly IRepository<User> _repository;
    public UserService(IRepository<User> repository)
    {
        _repository = repository;
    }
    public async Task Add(User user)
    {
        await _repository.AddAsync(user);
    }

    public async Task Delete(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<User>> Get(Expression<Func<User, bool>> predicate)
    {
        return await _repository.Buscar(predicate);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<User> GetById(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task Update(User user)
    {
        await _repository.UpdateAsync(user);
    }
}
