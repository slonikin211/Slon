namespace SharedAssets.Domain.Interfaces;

/// <summary>
/// Represents a unit of work for managing changes to the data store.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Asynchronously saves the changes to the data store.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous save operation.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}