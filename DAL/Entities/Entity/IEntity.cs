﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities.Entity
{
    public interface IEntity<Tkey>
    {
        Tkey Id { get; set; }
    }
}
