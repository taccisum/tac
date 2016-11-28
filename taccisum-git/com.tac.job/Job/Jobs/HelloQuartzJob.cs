using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Jobs
{
    public class HelloQuartzJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Debug.WriteLine("quartz info: " +  DateTime.Now);
        }
    }
}
