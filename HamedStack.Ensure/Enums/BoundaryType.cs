// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace HamedStack.Ensure.Enums;

/// <summary>
///     Specifies the boundary type for inclusive or exclusive comparisons.
/// </summary>
public enum BoundaryType
{
    /// <summary>
    ///     Indicates that the boundary should be inclusive, including the specified value.
    /// </summary>
    Inclusive,

    /// <summary>
    ///     Indicates that the boundary should be exclusive, excluding the specified value.
    /// </summary>
    Exclusive
}