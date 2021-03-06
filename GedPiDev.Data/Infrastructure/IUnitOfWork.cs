﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GedPiDev.Data.Repositories;

namespace GedPiDev.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBaseAsync<T> getRepository<T>() where T : class;
        void CommitAsync();
        void Commit();
    }

}
