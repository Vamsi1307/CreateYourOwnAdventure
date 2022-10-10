namespace CreateYourOwnAdventure.Core.Interfaces;

public interface IRepository<T>
{
	public Task<int> Create(T toCreate);
	public Task<T?> Get(int id);
	public Task<List<T>> Get();
}