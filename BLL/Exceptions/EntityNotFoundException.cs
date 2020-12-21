using BLL.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Exceptions
{
    public class EntityNotFoundException : NotFoundException
    {
        public override string Message { get; }

        public EntityNotFoundException(string type, int id) : base()
        {
            Message = $"Couldn't find entity with type {type} and with id {id}";
        }
    }
}
