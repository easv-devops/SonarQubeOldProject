using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTests.Enteties
{
    public class ApiResponse<T>
{
    public string MessageToClient { get; set; }
    public List<T> ResponseData { get; set; }
}

}