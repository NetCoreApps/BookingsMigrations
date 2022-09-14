using Funq;
using ServiceStack;
using NUnit.Framework;
using MyApp.ServiceInterface;
using MyApp.ServiceModel;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace MyApp.Tests;

public class IntegrationTest
{
    const string BaseUri = "http://localhost:2000/";
    private readonly ServiceStackHost appHost;

    class AppHost : AppSelfHostBase
    {
        public AppHost() : base(nameof(IntegrationTest), typeof(MyServices).Assembly) { }

        public override void Configure(Container container)
        {
        }
    }

    public IntegrationTest()
    {
        appHost = new AppHost()
            .Init()
            .Start(BaseUri);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() => appHost.Dispose();

    public IServiceClient CreateClient() => new JsonServiceClient(BaseUri);

    [Test]
    public void Can_call_Hello_Service()
    {
        var client = CreateClient();

        var response = client.Get(new Hello { Name = "World" });

        Assert.That(response.Result, Is.EqualTo("Hello, World!"));
    }
}

public static class MigrationTaskExtensions
{
    public static IDbConnectionFactory ConfigureAndResolve<T>(this ConfigureDb configureDb)
    {
        return new OrmLiteConnectionFactory("../../../../MyApp/App_Data/app.db", SqliteDialect.Provider);
    }
}