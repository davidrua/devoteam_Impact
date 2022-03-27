namespace Assignment.Tests.Fixture
{
    using Xunit;

    [CollectionDefinition(nameof(IntegrationTestsCollection))]
    public class IntegrationTestsCollection : ICollectionFixture<Fixture>
    {
    }
}