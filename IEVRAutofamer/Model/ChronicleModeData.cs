using IEVRAutofamer.Systems;
using System.Numerics;
using WpfScreenHelper;

namespace IEVRAutofamer.Model
{
    public struct ChronicleModeData : IProcessData
    {
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public List<DateTime> LoopStartTimeList { get; set; }
        public List<DateTime> LoopCompletionTimeList { get; set; }
        public int CurrentMatch { get; set; }
        public int TotalMatches { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public TimeSpan AverageDuration { get; set; }
        public int MaximuTotalMatches { get; set; }
        public bool IsAudioActivated { get; set; }
        public AudioExecutionType AudioExecutionType { get; set; }
        public Screen CurrentScreen { get; set; }
    }
}
