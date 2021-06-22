using BxlForm.DemoSecurity.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BxlForm.DemoSecurity.Models.Global.Mappers
{
    internal static class DataRecord
    {
        internal static User ToUser(this IDataRecord dataRecord)
        {
            return new User()
            {
                Id = (int)dataRecord["Id"],
                LastName = (string)dataRecord["LastName"],
                FirstName = (string)dataRecord["FirstName"],
                Email = (string)dataRecord["Email"],
                Passwd = null, //On ne renvoit jamais un mot de passe d'une base de données
                IsAdmin = (bool)dataRecord["IsAdmin"]
            };
        }
    }
}
