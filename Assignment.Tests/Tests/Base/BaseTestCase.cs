namespace Assignment.Tests.Tests.Base
{
    using Assignment.Tests.Fixture;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using Xunit;

    [Collection(nameof(IntegrationTestsCollection))]
    public abstract class BaseTestCase
    {
        #region Constructors

        protected BaseTestCase(Fixture fixture)
        {
            Fixture = fixture;
            ServiceProvider = fixture.ServiceProvider;
        }

        #endregion Constructors

        #region Properties

        protected Fixture Fixture { get; }

        protected IServiceProvider ServiceProvider { get; }

        #endregion Properties

        #region Protected Methods

        protected T GetService<T>() => ServiceProvider.GetService<T>();

        #endregion Protected Methods
    }
}