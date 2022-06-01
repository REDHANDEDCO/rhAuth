using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RHAuth.Models
{
    public class PropertyShortInfoDto
    {
        public long PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyImage { get; set; }
        public string Description { get; set; }
        public string SQFOOTAGE { get; set; }
        public int MinPSF { get; set; }
        public int MaxPSF { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
