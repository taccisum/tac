using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoC.Manager;
using log4net;

namespace Service.Base
{
    public abstract class BaseService
    {
        private IIoC _ioc;
        private ILog _log;
        protected ILog Log
        {
            get { return _log ?? (_log = LogManager.GetLogger("Service." + this.GetType().Name)); }
        }

        protected IIoC IoC { get { return _ioc ?? (_ioc = IoCManager.GetInstance().Create()); } }

        private Stopwatch _watch;

        protected Stopwatch Watch
        {
            get { return _watch ?? (_watch = new Stopwatch()); }
        }

        protected BaseService()
        {

        }
    }
}
