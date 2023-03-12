using Autofac;
using Microsoft.Extensions.Configuration;
using RealState.Core.Context;
using System;


namespace RealState.Core
{
    public class CoreModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;

        public CoreModule(IConfiguration configuration, string connectionStringName, string migrationAssemblyName)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(connectionStringName);
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RealStateContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<RealStateContext>().As<IRealStateContext>()
                     .WithParameter("connectionString", _connectionString)
                     .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                     .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
