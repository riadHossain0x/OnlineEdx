using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using OnlineEdx.Data;
using NHibernate.Tool.hbm2ddl;

namespace OnlineEdx.Infrastructure.SessionFactories
{
    public class MsSQLSessionFactory : IDataSessionFactory
    {
        public ISessionFactory Session { get; }

        public MsSQLSessionFactory()
        {
            Session = Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Server=.\SQLEXPRESS;Database=EdxDBTest;Trusted_Connection=True;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MsSQLSessionFactory>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return Session.OpenSession();
        }
    }
}
