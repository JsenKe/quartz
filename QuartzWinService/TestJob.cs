using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuartzWinService.Job
{
    class TestJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            ///具体任务逻辑
            LogHelp.SysLog("哈哈哈哈哈哈", "MyFirstQuartzService");
        }
    }
}
