using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Repository
{ 
    public interface IGameContext
    {
        DbSet<GameItem> GameItems { get; set; }
        int SaveChanges();
        void Dispose();
    }
}