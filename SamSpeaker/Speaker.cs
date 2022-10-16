using System.Diagnostics;

namespace SamSpeaker
{
    public static class Speaker
    {
        public static void Speak(string speechLine)
        {
            Process speaker = new Process();
            speaker.StartInfo.FileName = "sam.exe";
            speaker.StartInfo.Arguments = speechLine;
            speaker.Start();
        }
    }
}