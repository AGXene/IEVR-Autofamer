using System.Windows.Media;

namespace IEVRAutofamer.Systems
{
    public enum AudioExecutionType
    {
        EveryMatch,
        AutofarmFinished
    }

    internal class AudioSystem
    {
        private const string k_processFinishedSound = "../../Resources/Sounds/Sound_ProcessFinished.wav";
        private const string k_processFinishedSoundDebug = "X:\\Projects\\Inazuma Eleven\\IEVR_Autofarmer_App\\IEVRAutofamer\\IEVRAutofamer\\Resources\\Sounds\\Sound_ProcessFinished.wav";
        
        public static void PlaySound(string path)
        {
            Uri uri = new Uri(path, UriKind.Relative);
            var media = new MediaPlayer();
            media.Open(uri);
            media.Play();
        }

        public static void PlayFinishedSound()
        {
#if DEBUG
            PlaySound(k_processFinishedSoundDebug);
#else
            PlaySound(k_processFinishedSound);
#endif
        }
    }
}
