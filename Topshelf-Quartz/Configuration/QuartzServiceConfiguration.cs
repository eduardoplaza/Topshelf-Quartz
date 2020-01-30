using TopshelfQuartz.Scheduler;
using Quartz;
using Quartz.Impl;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace TopshelfQuartz.Configuration
{
    public class QuartzServiceConfiguration
    {
        private const string _group1 = "group1";
        private const string _trigger1 = "trigger1";
        private const string _trigger2 = "trigger2";
        private const string _job1 = "job1";
        private const string _job2 = "job2";
        private StdSchedulerFactory _factory;
        private IScheduler _scheduler;
        private readonly ImmutableList<TriggerKey> _keys;

        public QuartzServiceConfiguration()
        {
            _keys = ImmutableList<TriggerKey>.Empty;
        }
        ~QuartzServiceConfiguration()
        {
            if(_factory != null)
            {
                _factory = null;
            }

            if(_scheduler != null)
            {
                _scheduler.Clear();
                _scheduler.Shutdown();
            }
        }
        public void Start()
        {
            StartAsync().Wait();
        }

        private async Task StartAsync()
        {

            NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
            _factory = new StdSchedulerFactory(props);
            _scheduler = await _factory.GetScheduler();
            await _scheduler.Start();

            IJobDetail job1 = JobBuilder.Create<Job1>()
                .WithIdentity(_job1, _group1)
                .Build();

            IJobDetail job2 = JobBuilder.Create<Job2>()
                .WithIdentity(_job2, _group1)
                .Build();

            ITrigger trigger1 = TriggerBuilder.Create()
                .WithIdentity(_trigger1, _group1)
                .WithSimpleSchedule(x => x
                   .WithIntervalInSeconds(15)
                   .RepeatForever())
                .Build();

            ITrigger trigger2 = TriggerBuilder.Create()
                .WithIdentity(_trigger2, _group1)
                .WithSimpleSchedule(x => x
                   .WithIntervalInSeconds(15)
                   .WithRepeatCount(3))
                .Build();

            _keys.Add(trigger1.Key);
            _keys.Add(trigger2.Key);

            await _scheduler.ScheduleJob(job1, trigger1);
            await _scheduler.ScheduleJob(job2, trigger2);


        }
        public void Stop()
        {
            StopAsync().Wait();
        }

        public async Task StopAsync()
        {
            await _scheduler.UnscheduleJobs(_keys);
        }
    }
}
