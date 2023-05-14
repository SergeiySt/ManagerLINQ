using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Manager_Linq
{
    internal class Model
    {
        [System.Data.Linq.Mapping.Table(Name = "Users")]
        public class Users
        {
            [System.Data.Linq.Mapping.Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int id_users { get; set; }
            [System.Data.Linq.Mapping.Column]
            public string LSurname { get; set; }
            [System.Data.Linq.Mapping.Column]
            public string LName { get; set; }
            [System.Data.Linq.Mapping.Column]
            public string LPobatkovi { get; set; }
            [System.Data.Linq.Mapping.Column]
            public string LEmail { get; set; }
            [System.Data.Linq.Mapping.Column]
            public int LPhone { get; set; }
            [System.Data.Linq.Mapping.Column]
            public DateTime LDateBrith { get; set; }
        }
    }
}
