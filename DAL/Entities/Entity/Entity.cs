using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities.Entity
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
