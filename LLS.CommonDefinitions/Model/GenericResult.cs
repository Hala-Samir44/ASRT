using LLS.CommonDefinitions.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLS.CommonDefinitions.Model
{
    public class GenericResult<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public ResultStatusEnum Status { get; set; }
    }
}
