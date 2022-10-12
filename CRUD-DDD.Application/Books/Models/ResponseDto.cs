using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DDD.Application.Books.Models
{
    public class ResponseDto<T>
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public T Data { get; set; }
    }
}
