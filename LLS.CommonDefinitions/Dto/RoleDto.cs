using System;
using System.Collections.Generic;
using System.Text;

namespace LLS.CommonDefinitions.Dto
{
    public class RoleDto
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> permissions { get; set; }
    }
}
