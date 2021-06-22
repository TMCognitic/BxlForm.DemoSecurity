using BxlForm.DemoSecurity.Models.Client.Data;
using G = BxlForm.DemoSecurity.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.DemoSecurity.Models.Client.Mappers
{
    internal static class Mappers
    {
        internal static G.User ToGlobal(this User entity)
        {
            return new G.User()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                Passwd = entity.Passwd,
                IsAdmin = entity.IsAdmin
            };
        }

        internal static User ToClient(this G.User entity)
        {
            return new User(entity.Id, entity.LastName, entity.FirstName, entity.Email, entity.IsAdmin);
        }
    }
}
