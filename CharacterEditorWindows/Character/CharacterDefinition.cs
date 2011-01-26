using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CharacterEditorWindows.Character
{
    public class CharacterDefinition
    {
        Animation[] animations;
        Frame[] frames;
        public string Path;

        public int HeadIndex;
        public int TorsoIndex;
        public int LegsIndex;
        public int WeaponIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterDefinition"/> class.
        /// </summary>
        public CharacterDefinition()
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

            Path = "charName";
        }

        /// <summary>
        /// Gets the animations.
        /// </summary>
        public Animation[] Animations
        {
            get { return animations; }
        }

        /// <summary>
        /// Gets the frames.
        /// </summary>
        public Frame[] Frames
        {
            get { return frames; }
        }

        #region IO Methods
        
        /// <summary>
        /// Writes Character Data to file.
        /// </summary>
        public void Write()
        {
            BinaryWriter binaryReader = new BinaryWriter(File.Open(Path, FileMode.Create));

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

        /// <summary>
        /// Reads Character Data from file.
        /// </summary>
        public void Read()
        {
            BinaryReader binaryReader = new BinaryReader(File.Open(Path, FileMode.Open, FileAccess.Read));

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
        #endregion
    }
}
