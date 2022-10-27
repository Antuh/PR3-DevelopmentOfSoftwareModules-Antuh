using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAuthorizations
{
    class Helper
    {
        private static Module.Entities s_entities;
        public static Module.Entities GetContext()
        {
            if (s_entities == null)
            {
                s_entities = new Module.Entities();
            }
            return s_entities;
        }

        public void CreateEmployees(Module.Staff staff, Module.Authorizations authorizations)
        {
            s_entities.Staff.Add(staff);
            s_entities.Authorizations.Add(authorizations);
            s_entities.SaveChanges();
        }

        public int GetLastIDStaff()
        {
            int id = s_entities.Staff.OrderByDescending(staff => staff.ID_Staff).First().ID_Staff;

            return id + 1;
        }

        public int GetLastIDAuth()
        {
            int id = s_entities.Authorizations.OrderByDescending(authorizations => authorizations.ID_Authorization).First().ID_Authorization;
            return id + 1;
        }
    }
}
