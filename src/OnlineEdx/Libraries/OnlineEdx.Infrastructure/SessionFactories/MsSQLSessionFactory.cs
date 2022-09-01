using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using OnlineEdx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.SessionFactories
{
    public class MsSQLSessionFactory : IDataSessionFactory
    {
        public ISessionFactory Session { get; }

        public MsSQLSessionFactory()
        {
            Session = Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Server=.\SQLEXPRESS;Database=cqrsDB;Trusted_Connection=True;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MsSQLSessionFactory>())
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return Session.OpenSession();
        }
    }
}
