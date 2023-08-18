namespace Slon.SharedAssets.Domain.Interfaces;

/// <summary>
/// Represents an entity that contains audit information such as creation and modification timestamps.
/// </summary>
public interface IAuditable
{
    /// <summary>
    /// Gets or sets the UTC timestamp indicating when the entity was created.
    /// </summary>
    DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp indicating when the entity was last modified.
    /// </summary>
    DateTime? ModifiedOnUtc { get; set; }
}
