using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VH3Q8P_HFT_2021221.Models.Models
{
    public class ApiResult
    {
        public bool IsSucces { get; set; }
        public ApiResult(bool isSucces)
        {
            IsSucces = isSucces;
        }

    }
}
