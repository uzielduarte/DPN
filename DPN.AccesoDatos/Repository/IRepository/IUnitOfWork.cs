﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPN.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IAppUserRepository AppUser { get; }
        Task Save();
    }
}
