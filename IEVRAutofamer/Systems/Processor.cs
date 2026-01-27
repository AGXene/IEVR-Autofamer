using System.Diagnostics;
using System.Numerics;

namespace IEVRAutofamer.Systems
{
    public abstract class Processor
    {
        public IProcessData ProcessData;

        public event Action OnStarted;
        public event Action OnFinished;
        public event Action OnMatchFinished;

        private bool _onExecution;
        public bool OnExecution
        {
            get {  return _onExecution; }
            private set
            {
                _onExecution = value;
                AppConfig.IsAutofarmRunning = value;
                if (value)
                {
                    AppConfig.CurrentProcessor = this;
                    AppConfig.LastProcessor = this;
                    AppConfig.OnAutofarmStateChanged();
                }
                else
                {
                    AppConfig.CurrentProcessor = null;
                    AppConfig.OnAutofarmStateChanged();
                }
            }
        }

        public Processor()
        {
            ProcessData = SetProcessData();
        }

        protected abstract Task OnProcessExecuted();
        protected abstract IProcessData SetProcessData();

        public async void StartProcess()
        {
            if (!OnExecution && AppConfig.IsAutofarmAllowed)
            {
                AppConfig.OnReactivateAutofarm(false);
                Debug.WriteLine("executing..." );
                AppConfig.Minimize();
                await Task.Delay(3000);

                ResetProcessData();
                AppConfig.OnReactivateAutofarm(true);
                OnExecution = true;
                OnStarted?.Invoke();
                ConfigureAudioType();

                Debug.WriteLine(">>>>>> START <<<<<< // Max: " + ProcessData.MaximuTotalMatches);

                while (OnExecution && ProcessData.MaximuTotalMatches > ProcessData.TotalMatches)
                {
                    Debug.WriteLine("--------------> Next Match <-------------- // Current: " + ProcessData.CurrentMatch);
                    ProcessData.LoopStartTimeList.Add(DateTime.Now);
                    await OnProcessExecuted();
                    OnMatchCompleted();
                    OnMatchFinished?.Invoke();
                }

                OnExecutionFinished();
                OnFinished?.Invoke();

                if (OnExecution) OnExecution = false;

                AppConfig.OnReactivateAutofarm(true);
                Debug.WriteLine(">>>>>> END <<<<<<");
            }
        }

        public void EndProcess()
        {
            if (OnExecution && AppConfig.IsAutofarmAllowed)
            {
                AppConfig.OnReactivateAutofarm(false);
                OnExecution = false;
            }
        }

        protected virtual void ResetProcessData()
        {
            ProcessData.CurrentMatch = 0;
            ProcessData.TotalMatches = 0;
            ProcessData.StartDate = DateTime.Now;
            ProcessData.FinishDate = default;
            ProcessData.LoopStartTimeList = new List<DateTime>();
            ProcessData.LoopCompletionTimeList = new List<DateTime>();
            ProcessData.TotalDuration = default;
            ProcessData.AverageDuration = default;
        }

        private void ConfigureAudioType()
        {
            
            if (ProcessData.IsAudioActivated)
            {
                if (ProcessData.AudioExecutionType == AudioExecutionType.EveryMatch)
                {
                    OnMatchFinished -= PlaySound;
                    OnMatchFinished += PlaySound;
                }
                else
                {
                    OnFinished -= PlaySound;
                    OnFinished += PlaySound;
                }
            }
        }

        private void PlaySound()
        {
            AudioSystem.PlayFinishedSound();
        }

        private void OnMatchCompleted()
        {
            ProcessData.CurrentMatch += 1;
            ProcessData.TotalMatches += 1;

            var completionTime = DateTime.Now;
            ProcessData.LoopCompletionTimeList.Add(completionTime);

            ProcessData.TotalDuration = ApplicationUtilities.GetDateTimeDifference(
                ProcessData.StartDate, completionTime);
            var average = ApplicationUtilities.GetAverageDuration(
                ProcessData.LoopStartTimeList,ProcessData.LoopCompletionTimeList);
            ProcessData.AverageDuration = new TimeSpan(average.Hour,average.Minute,average.Second);
        }

        private void OnExecutionFinished()
        {
            ProcessData.FinishDate = DateTime.Now;

            ProcessData.TotalDuration = ApplicationUtilities.GetDateTimeDifference(
                ProcessData.StartDate, ProcessData.FinishDate);

        }
    }
}
