namespace Aveva.Platform.EntityMgmt.Tests.Benchmarks.Serialization.CustomSerializers;

/// <summary>
/// Singleton manager for RecyclableMemoryStream instances.
/// </summary>
public static class RecyclableMemoryStreamManager
{
    /// <summary>
    /// Shared instance of the recyclable memory stream manager.
    /// Configured for optimal performance with typical JSON payloads.
    /// </summary>
    public static readonly Microsoft.IO.RecyclableMemoryStreamManager Instance = new();
}
