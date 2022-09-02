﻿using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Repositories
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
    }
}
