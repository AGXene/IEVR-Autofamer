using System.Diagnostics;

namespace IEVRAutofamer
{
    class ApplicationUtilities
    {
        public static async void WaitBeforeExecute(int miliseconds, Action onExecute)
        {
            await Task.Delay(miliseconds);
            onExecute?.Invoke();
        }

        public static DateTime GetAverageDuration(List<DateTime> startDates, List<DateTime> endDates) 
        {
            var times = startDates.Count;
            double totalSeconds = 0;
            for (int i = 0; i < startDates.Count; i++)
            {
                var difference = GetDateTimeDifference(startDates[i], endDates[i]);
                totalSeconds += new TimeSpan(difference.Hours,difference.Minutes,difference.Seconds).TotalSeconds;
            }
            var averageSeconds = totalSeconds / times;
            return new DateTime().AddSeconds(averageSeconds);
        }

        public static TimeSpan GetDateTimeDifference(DateTime startDate, DateTime finishDate)
        {
            TimeSpan span = finishDate - startDate;
            return span;
        }

        public static void OpenWebsite(string path)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }
    }
}
