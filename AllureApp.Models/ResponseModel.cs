using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Models
{
    public class ResponseModel<T>
    {
        public bool? Success { get; set; }
        public string? Status { get; set; }
        public T? Result { get; set; } // works fine
    }
}
