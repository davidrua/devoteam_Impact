namespace Assignment.Tests.Fixture
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class Fixture
    {
        #region Constructors

        public Fixture()
        {
            var services = new ServiceCollection();
            ServiceProvider = services.BuildServiceProvider();
        }

        #endregion Constructors

        #region Properties

        public IServiceProvider ServiceProvider { get; }

        #endregion Properties
    }
}