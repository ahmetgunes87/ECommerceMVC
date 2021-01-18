using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Framework.CrossCuttingConcerns.Logging;
using Framework.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace Framework.Aspects.Postsharp.PerformanceAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class PerformanceCounterAspect:OnMethodBoundaryAspect
    {
        private readonly Type _loggerType;
        private LoggerService _loggerService;
        private int _interval;
        [NonSerialized]
        private Stopwatch _stopwatch;

        public PerformanceCounterAspect(Type loggerType, int interval = 5)
        {
            _loggerType = loggerType;
            _interval = interval;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong logger type");
            }
            _stopwatch = Activator.CreateInstance<Stopwatch>();
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds>_interval)
            {
                if (!_loggerService.IsWarnEnabled)
                {
                    return;
                }

                try
                {
                    var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                    {
                        Name = t.Name,
                        Type = t.ParameterType.Name,
                        Value = "Performance-->" +_stopwatch.Elapsed.TotalSeconds + " sn"
                    }).ToList();

                    var logDetail = new LogDetail
                    {
                        FullName = args.Method.DeclaringType?.Name,
                        MethodName = args.Method.Name,
                        Parameters = logParameters
                    };

                    _loggerService.Warn(logDetail);
                }
                catch (Exception)
                {

                }
                //Debug.WriteLine("Performance: {0}.{1}->>{2}", args.Method.DeclaringType.FullName, args.Method.Name, _stopwatch.Elapsed.TotalSeconds);
            }
            _stopwatch.Reset();
            base.OnExit(args);
        }
    }
}
