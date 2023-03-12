using Autofac;
using Microsoft.Extensions.Configuration;
using RealState.Core.Context;
using RealState.Core.Entity;
using RealState.Core.Repositories;
using RealState.Core.Services;
using RealState.Core.UnitOfWorks;
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

            builder.RegisterType<CustomerUnitOfWork>().As<ICustomerUnitOfWork>()
                 .WithParameter("connectionString", _connectionString)
                 .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                 .InstancePerLifetimeScope();

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerService>().As<ICustomerService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
