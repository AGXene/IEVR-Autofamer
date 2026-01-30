using System.Media;
using System.Windows;

namespace IEVRAutofamer.Systems
{
    public enum AudioExecutionType
    {
        EveryMatch,
        AutofarmFinished
    }

    internal class AudioSystem
    {
        //private const string k_processFinishedSound = "../../Resources/Sounds/Sound_ProcessFinished.wav";
        //private const string k_processFinishedSoundDebug = "X:\\Projects\\Inazuma Eleven\\IEVR_Autofarmer_App\\IEVRAutofamer\\IEVRAutofamer\\Resources\\Sounds\\Sound_ProcessFinished.wav";
        
        public static void PlaySound(string path)
        {
            SoundPlayer player = new SoundPlayer();
            try
            {
                player.SoundLocation = path;
                player.Play();
            }
            catch
            {
                MessageBox.Show("Audio couldn't be found at the following path -> " + path);
            }

        }

        public static void PlayFinishedSound()
        {
            PlaySound("Sound_ProcessFinished.wav");
        }
    }
}
