using System.Runtime.InteropServices;

namespace IEVRAutofamer.Systems
{
    internal class InputSystem
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int key);

        //https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes

        private const uint k_clickDown = 0x02;
        private const uint k_clickUp = 0x04;

        private const byte k_commanderKey = 0x55; //U key
        private const byte k_arrowKeyLeft = 0x25;
        private const byte k_arrowKeyDown = 0x28;
        private const byte k_enterKey = 0x0D; //Enter
        private const byte k_keyDown = 0x0001;
        private const byte k_keyUp = 0x0002;

        //--------------------- METHODS ---------------------

        public static void ClickUp()
        {
            mouse_event(k_clickUp, 0, 0, 0, IntPtr.Zero);
        }

        public static void ClickDown()
        {
            mouse_event(k_clickDown, 0, 0, 0, IntPtr.Zero);
        }

        public static void MouseClick()
        {
            mouse_event(k_clickDown, 0, 0, 0, IntPtr.Zero);
            mouse_event(k_clickUp, 0, 0, 0, IntPtr.Zero);
        }

        public static void CommanderKey()
        {
            keybd_event(k_commanderKey, 0, k_keyDown | 0, 0);
            keybd_event(k_commanderKey, 0, k_keyUp | 0, 0);
        }

        public static void ArrowDownKey()
        {
            keybd_event(k_arrowKeyDown, 0, k_keyDown | 0, 0);
            keybd_event(k_arrowKeyDown, 0, k_keyUp | 0, 0);
        }
        public static void ArrowLeftKey()
        {
            keybd_event(k_arrowKeyLeft, 0, k_keyDown | 0, 0);
            keybd_event(k_arrowKeyLeft, 0, k_keyUp | 0, 0);
        }

        public static void EnterKey()
        {
            keybd_event(k_enterKey, 0, k_keyDown | 0, 0);
            keybd_event(k_enterKey, 0, k_keyUp | 0, 0);
        }

        public static async Task AutoClick(int repetitions, int interval, Action onClick)
        {
            for (int i = 0; i < repetitions; i++)
            {
                if (!AppConfig.IsAutofarmRunning) break;
                await Task.Delay(interval);
                onClick?.Invoke();
            }
        }
    }
}
