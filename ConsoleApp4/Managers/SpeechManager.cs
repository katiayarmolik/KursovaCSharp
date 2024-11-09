using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace TaskScheduler.Managers
{
    public static class SpeechManager
    {
        public static SpeechSynthesizer InitializeSynthesizer()
        {
            return new SpeechSynthesizer();
        }

        public static void SelectVoice(SpeechSynthesizer synthesizer)
        {
            var voices = synthesizer.GetInstalledVoices();
            List<string> voiceNames = new List<string>();

            foreach (var voice in voices)
            {
                voiceNames.Add(voice.VoiceInfo.Name);
            }

            int selectedIndex = MenuManager.NavigateMenu(voiceNames.ToArray());
            synthesizer.SelectVoice(voiceNames[selectedIndex]);
            synthesizer.Speak($"Voice {voiceNames[selectedIndex]} selected.");
        }
    }
}
