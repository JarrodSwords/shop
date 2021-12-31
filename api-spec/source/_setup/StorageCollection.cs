using Xunit;

namespace Shop.Api.Spec
{
    /// <summary>
    ///     Defines the "storage" collection.
    /// </summary>
    [CollectionDefinition("storage")]
    public class StorageCollection : ICollectionFixture<StorageFixture>
    {
    }
}
