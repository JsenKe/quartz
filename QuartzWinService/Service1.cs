using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace QuartzWinService
{
    public partial class Service1 : ServiceBase
    {
        private IScheduler scheduler;
        public Service1()
        {
            InitializeComponent();
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            scheduler = schedulerFactory.GetScheduler();
        }
        protected override void OnStart(string[] args)
        {
            scheduler.Start();
            LogHelp.SysLog("Quartz服务成功启动----", "MyFirstQuartzService");
        }
        protected override void OnStop()
        {
            // 在此处添加代码以执行停止服务所需的关闭操作。
            scheduler.Shutdown();
            LogHelp.SysLog("Quartz服务成功终止", "MyFirstQuartzService");
        }
        protected override void OnPause()
        {
            scheduler.PauseAll();
        }
        protected override void OnContinue()
        {
            scheduler.ResumeAll();
        }
    }
}
