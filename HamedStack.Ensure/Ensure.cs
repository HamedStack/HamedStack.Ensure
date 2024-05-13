namespace HamedStack.Ensure;

/// <summary>
/// Provides a mechanism for ensuring certain conditions. This is a singleton-style class, with a static instance
/// available via the <see cref="That"/> property. The constructor is private to prevent external instantiation.
/// </summary>
public class Ensure : IEnsure
{
    /// <summary>
    /// Prevents a default instance of the <see cref="Ensure"/> class from being created.
    /// </summary>
    private Ensure()
    {
    }

    /// <summary>
    /// Gets a singleton instance of the <see cref="Ensure"/> class, used to access ensure methods.
    /// </summary>
    public static IEnsure That { get; } = new Ensure();
}

