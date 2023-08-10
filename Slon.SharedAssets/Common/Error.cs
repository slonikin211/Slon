namespace Slon.SharedAssets.Common;

#pragma warning disable CA1716 // Identifiers should not match keywords

/// <summary>
/// Represents an error with a specific code and name.
/// </summary>
/// <remarks>
/// This record is used to encapsulate information about different errors that can occur in the application.
/// Each error has a unique code and a human-readable name associated with it.
/// </remarks>
public record Error(string Code, string Name)
{
    /// <summary>
    /// Represents an empty or no-error state.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty);

    /// <summary>
    /// Represents the error when a null value is provided.
    /// </summary>
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");
}

#pragma warning restore CA1716 // Identifiers should not match keywords
