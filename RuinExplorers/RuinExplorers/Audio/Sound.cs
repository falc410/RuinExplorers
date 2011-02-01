using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace RuinExplorers.Audio
{
    static class Sound
    {
        private static AudioEngine engine;
        private static SoundBank soundBank;
        private static WaveBank waveBank;

        static Sound()
        {
            engine = new AudioEngine(@"Content/sfx/audioproject.xgs");
            soundBank = new SoundBank(engine, @"Content/sfx/sfxsounds.xsb");
            waveBank = new WaveBank(engine, @"Content/sfx/sfxwavs.xwb");
        }

        public static void PlayCue(String cue)
        {
            soundBank.PlayCue(cue);
        }

        public static Cue GetCue(String cue)
        {
            return soundBank.GetCue(cue);
        }

        public static void Update()
        {
            engine.Update();
        }

        public static AudioEngine GetEngine()
        {
            return engine;
        }
    }
}
