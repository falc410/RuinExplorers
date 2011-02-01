using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Microsoft.Xna.Framework.Audio;

namespace RuinExplorers.Audio
{
    static class Music
    {
        private static WaveBank waveBank;
        private static SoundBank soundBank;
        private static Cue musicCue;
        private static String musicString;

        static Music()
        {
            waveBank = new WaveBank(Sound.GetEngine(), @"Content/sfx/musicwavs.xwb", 0, 16);
            soundBank = new SoundBank(Sound.GetEngine(), @"Content/sfx/musicsounds.xsb");
        }

        public static void Play(String musicName)
        {
            if (musicString != musicName)
            {
                musicString = musicName;

                if (musicCue != null)
                    musicCue.Dispose();

                musicCue = soundBank.GetCue(musicString);
                musicCue.Play();
            }
        }
    }
}
