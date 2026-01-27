using IEVRAutofamer.Systems;
using System.Diagnostics;
using System.Numerics;
using System.Windows;

namespace IEVRAutofamer
{
    internal class AppConfig
    {
        public static Processor CurrentProcessor;
        public static Processor LastProcessor;
        public static event Action<bool> OnAutofarmStateChangedEvent;
        public static event Action<bool> OnReactivateAutofarmEvent;
        public static bool IsAutofarmRunning;
        public static bool IsAutofarmAllowed = true;

        public static Vector2 windowLastSize{ get; private set; }
        public static Vector2 windowLastPosition{ get; private set; }

        public static WindowState windowState { get; private set; }
        public static bool isMaximized;

        public static Window MainWindow { get; private set; }

        public static void ResolveDependencies(Window mainWindow)
        {
            MainWindow = mainWindow;
        }

        public static void Maximize()
        {
            if (windowState == WindowState.Maximized || isMaximized || 
                MainWindow.WindowState == WindowState.Maximized)
            {
                MainWindow.Width = windowLastSize.X;
                MainWindow.Height = windowLastSize.Y;
                MainWindow.Left = windowLastPosition.X;
                MainWindow.Top = windowLastPosition.Y;
                windowState = WindowState.Normal;
                MainWindow.ResizeMode = ResizeMode.CanResize;
                isMaximized = false;
                Debug.WriteLine("guau");
            }
            else
            {
                windowLastSize = new Vector2((float)MainWindow.Width,
                    (float)MainWindow.Height);
                windowLastPosition = new Vector2((float)MainWindow.Left,
                    (float)MainWindow.Top);

                MainWindow.Width = SystemParameters.WorkArea.Width;
                MainWindow.Height = SystemParameters.WorkArea.Height;
                MainWindow.Top = 0;
                MainWindow.Left = 0;
                windowState = WindowState.Maximized;
                MainWindow.ResizeMode = ResizeMode.NoResize;
                isMaximized = true;
            }
        }

        public static void Minimize()
        {
            MainWindow.WindowState = WindowState.Minimized;
        }

        public static void OnAutofarmStateChanged()
        {
            OnAutofarmStateChangedEvent?.Invoke(IsAutofarmRunning);
        }
        public static void OnReactivateAutofarm(bool state)
        {
            IsAutofarmAllowed = state;
            OnReactivateAutofarmEvent?.Invoke(state);
        }
    }
}
