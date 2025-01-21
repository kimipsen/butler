using Projects;

var builder = DistributedApplication.CreateBuilder(args);

// https://learn.microsoft.com/en-us/dotnet/aspire/authentication/keycloak-integration?tabs=dotnet-cli
//var username = builder.AddParameter("username");
//var password = builder.AddParameter("password", secret: true);
var keycloak = builder.AddKeycloak(Names.ServiceKeycloak, 8080);

// https://learn.microsoft.com/en-us/dotnet/aspire/database/postgresql-integration?tabs=dotnet-cli
var postgres = builder.AddPostgres(Names.ServicePostgres)
    .WithPgAdmin();
var postgresdatabase = postgres.AddDatabase(Names.ServicePostgresDatabase);

// WebAPI
var api = builder.AddProject<Projects.butler_api>(Names.ServiceNameApi)
    .WithReference(postgresdatabase);

// https://learn.microsoft.com/en-us/dotnet/aspire/get-started/build-aspire-apps-with-nodejs
//var nodejs = builder.AddNodeApp();

builder.Build().Run();
