using System;
using System.Collections.Generic;

namespace CrudDapper.Models
{
    public partial class Members
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
