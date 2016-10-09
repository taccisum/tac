using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Tool.Extend;

namespace Model.CommonModel
{
    public class DataTablesResult
    {
        public  int draw { get; set; }
        public  int recordsTotal { get; set; }
        public  int recordsFiltered { get; set; }
        public  object data { get; set; }


        public override string ToString()
        {
            return this.ToJson();
        }
    }
}
