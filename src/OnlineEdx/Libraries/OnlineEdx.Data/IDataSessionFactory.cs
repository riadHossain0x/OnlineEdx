using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Data
{
    public interface IDataSessionFactory
    {
        ISession OpenSession();
    }
}
