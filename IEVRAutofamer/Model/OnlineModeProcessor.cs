using IEVRAutofamer.Systems;
using System.Diagnostics;

namespace IEVRAutofamer.Model
{
    internal class OnlineModeProcessor : Processor
    {
        protected override IProcessData SetProcessData()
        {
            var data = new OnlineModeData();
            return data;
        }

        protected override async Task OnProcessExecuted()
        {
            await StartMatchTask();
            await AutoclickUntilFinish();
            if (AppConfig.IsAutofarmRunning)
            {
                await Task.Delay(7500); //Wait and reset the cycle.
            }
            else
            {
                await Task.Delay(1000); //Wait and reset the cycle.
            }
        }

        private async Task StartMatchTask()
        {
            if (AppConfig.IsAutofarmRunning)
            {
                Debug.WriteLine("1.=== Start Match Task ===");

                InputSystem.EKey();
                await Task.Delay(AppConfig.IsLowPerformanceActivated ? 17000 : 11000);
                var lowPerformanceClick = AppConfig.IsLowPerformanceActivated ? 35 : 28;
                await InputSystem.AutoClick(lowPerformanceClick, 1000, () => InputSystem.EnterKey());

                if (AppConfig.IsAutofarmRunning)
                {
                    await Task.Delay(AppConfig.IsLowPerformanceActivated ? 3000 : 1500);
                    InputSystem.CommanderKey();
                    await Task.Delay(1000);
                    await InputSystem.AutoClick(5, 1000, () => InputSystem.MouseClick());
                }
            }
        }

        private async Task AutoclickUntilFinish()
        {
            if (AppConfig.IsAutofarmRunning)
            {
                Debug.WriteLine("2.=== Autoclick Until Finish Task ===");

                //---- FIRST HALF ----

                int firstHalfSeconds = 0;

                //DEPRECATED: await Task.Delay(TimeSpan.FromSeconds(135)); //135 s -> 2 min 15 seconds

                while (firstHalfSeconds < 150 && OnExecution) //150 s -> 2 min 30 seconds
                {
                    await Task.Delay(1000);
                    firstHalfSeconds += 1;
                }

                //---- SECOND HALF ----

                //DEPRECATED: await InputSystem.AutoClick(100, 1000, () => InputSystem.EnterKey()); //100 s -> 1 min 40 seconds

                bool finished = false;
                while (!finished && AppConfig.IsAutofarmRunning) //Check until game finished.
                {
                    InputSystem.EnterKey();
                    await Task.Delay(500);
                    InputSystem.EnterKey();

                    int timesScreenBlack = 0;
                    bool isScreenBlack = true;
                    int minimumChecks = AppConfig.IsLowPerformanceActivated ? 9 : 6;

                    do
                    {
                        await Task.Delay(100);
                        isScreenBlack = ScreenObserver.DetectIfBlackScreen(ProcessData.CurrentScreen, 5);
                        if (isScreenBlack)
                        {
                            timesScreenBlack += 1;
                            Debug.WriteLine("Screen Black /// Times -> " + timesScreenBlack);
                        }
                    }
                    while (isScreenBlack && timesScreenBlack < minimumChecks);

                    if (timesScreenBlack >= minimumChecks)
                    {
                        finished = true; //Match finished.
                    }
                }
            }
        }
    }
}
