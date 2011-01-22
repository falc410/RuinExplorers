using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RuinExplorers.CharacterClasses
{
    class CharacterDefinition
    {
        Animation[] animations;
        Frame[] frames;
        public string Path;

        public int HeadIndex;
        public int TorsoIndex;
        public int LegsIndex;
        public int WeaponIndex;

        public CharacterType CharType = CharacterType.Player1;

        public CharacterDefinition(string path)
        {
            animations = new Animation[64];
            for (int i = 0; i < animations.Length; i++)
            {
                animations[i] = new Animation();
            }
            frames = new Frame[512];
            for (int i = 0; i < frames.Length; i++)
            {
                frames[i] = new Frame();
            }

            Path = path;
            Read();
        }

        public Animation[] Animations
        {
            get { return animations; }
        }

        public Frame[] Frames
        {
            get { return frames; }
        }

        public void Write()
        {
            BinaryWriter binaryReader = new BinaryWriter(File.Open(@"Content/data/" + Path + ".dat", FileMode.Create));

            binaryReader.Write(Path);
            binaryReader.Write(HeadIndex);
            binaryReader.Write(TorsoIndex);
            binaryReader.Write(LegsIndex);
            binaryReader.Write(WeaponIndex);

            for (int i = 0; i < animations.Length; i++)
            {
                binaryReader.Write(animations[i].Name);

                for (int j = 0; j <
                    animations[i].KeyFrames.Length; j++)
                {
                    KeyFrame keyframe = animations[i].KeyFrames[j];
                    binaryReader.Write(keyframe.FrameReference);
                    binaryReader.Write(keyframe.Duration);
                    String[] scripts = keyframe.Scripts;
                    for (int s = 0; s < scripts.Length; s++)
                        binaryReader.Write(scripts[s]);
                }
            }

            for (int i = 0; i < frames.Length; i++)
            {
                binaryReader.Write(frames[i].Name);

                for (int j = 0; j < frames[i].Parts.Length; j++)
                {
                    Part part = frames[i].Parts[j];
                    binaryReader.Write(part.Index);
                    binaryReader.Write(part.Location.X);
                    binaryReader.Write(part.Location.Y);
                    binaryReader.Write(part.Rotation);
                    binaryReader.Write(part.Scaling.X);
                    binaryReader.Write(part.Scaling.Y);
                    binaryReader.Write(part.Flip);
                }
            }

            binaryReader.Close();
        }

        public void Read()
        {
            BinaryReader binaryReader = new BinaryReader(File.Open(@"Content/data/characters/" + Path + ".dat", FileMode.Open, FileAccess.Read));

            Path = binaryReader.ReadString();
            HeadIndex = binaryReader.ReadInt32();
            TorsoIndex = binaryReader.ReadInt32();
            LegsIndex = binaryReader.ReadInt32();
            WeaponIndex = binaryReader.ReadInt32();


            for (int i = 0; i < animations.Length; i++)
            {
                animations[i].Name = binaryReader.ReadString();

                for (int j = 0; j <
                    animations[i].KeyFrames.Length; j++)
                {
                    KeyFrame keyframe = animations[i].KeyFrames[j];
                    keyframe.FrameReference = binaryReader.ReadInt32();
                    keyframe.Duration = binaryReader.ReadInt32();

                    string[] scripts = keyframe.Scripts;
                    for (int s = 0; s < scripts.Length; s++)
                        scripts[s] = binaryReader.ReadString();
                }
            }

            for (int i = 0; i < frames.Length; i++)
            {
                frames[i].Name = binaryReader.ReadString();

                for (int j = 0; j < frames[i].Parts.Length; j++)
                {
                    Part part = frames[i].Parts[j];
                    part.Index = binaryReader.ReadInt32();
                    part.Location.X = binaryReader.ReadSingle();
                    part.Location.Y = binaryReader.ReadSingle();
                    part.Rotation = binaryReader.ReadSingle();
                    part.Scaling.X = binaryReader.ReadSingle();
                    part.Scaling.Y = binaryReader.ReadSingle();
                    part.Flip = binaryReader.ReadInt32();
                }
            }

            binaryReader.Close();

            Console.WriteLine("Loaded.");

        }
    }
}
