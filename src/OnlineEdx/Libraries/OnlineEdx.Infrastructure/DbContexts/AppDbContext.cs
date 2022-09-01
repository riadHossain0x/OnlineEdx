﻿using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System.Configuration;
using OnlineEdx.Membership.Services;
using Microsoft.AspNetCore.Identity;

namespace OnlineEdx.Infrastructure.DbContexts
{
    public class AppDbContext
    {
        private readonly ISessionFactory sessionFactory;
        public AppDbContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AppDbContext>())
                .BuildSessionFactory();
        }

        public ISession MakeSession()
        {
            return sessionFactory.OpenSession();
        }

        public IUserStore<User> Users
        {
            get { return new IdentityStore(MakeSession()); }
        }
    }
}
