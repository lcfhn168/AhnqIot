﻿
using AhnqIot.DataProcess.Service.Core;
using XAgent;

namespace AhnqIot.AreaStationDataProcess
{
    /// <summary>服务容器</summary>
    public class AreaStationJobService : AgentServiceBase<AreaStationJobService>
    {
        /// <summary>显示名字</summary>
        public override string DisplayName => "区域气象站工作服务";

        /// <summary>容器线程数，根据插件数动态调整</summary>
        public override int ThreadCount => JobHelper.Works.Count;

        protected override void OnStart(string[] args)
        {
            WriteLine("{0}开始工作", DisplayName);
            base.OnStart(args);
        }

        /// <summary>启动</summary>
        public override void StartWork()
        {
            //Intervals = new int[ThreadCount + 1];
            base.StartWork();
        }

        public override void StartWork(int index)
        {
           // Intervals[index] = JobHelper.Works[index].JobInterval;
            JobHelper.Works[index].Start();
            base.StartWork(index);
        }

        /// <summary>执行工作</summary>
        /// <param name="index">线程序号</param>
        /// <returns></returns>
        public override bool Work(int index)
        {
            //WriteLine(Intervals[index].ToString() + " - " + JobHelper.Works[index].JobInterval.ToString());
            JobHelper.Works[index].Work();
            return false;
        }

        public override void StopWork(int index)
        {
            JobHelper.Works[index].Start();
            base.StopWork(index);
        }

        /// <summary>停止</summary>
        public override void StopWork()
        {
            WriteLine("{0}停止工作", DisplayName);
            base.StopWork();
        }
    }
}