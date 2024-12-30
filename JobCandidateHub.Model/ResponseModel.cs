using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHub.Model
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool SuccessStatus { get; set; }
        public string[] ErrorMessage { get; set; }
    }
}
