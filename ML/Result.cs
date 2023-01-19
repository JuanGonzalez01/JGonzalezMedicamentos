using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        public bool Status { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
        public Object Object { get; set; }
        public List<Object> Objects { get; set; }
    }
}
