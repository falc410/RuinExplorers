using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RuinExplorers.CharacterClasses
{
    /// <summary>
    /// Deinfes a character. 
    /// A character consists of an array of Frames[512] (each made up out of parts) 
    /// and another array of animations[64] (each made up out of keyFrames which in fact are frames + duration)
    /// Requires a previously created character data from the editor.
    /// </summary>
    public class CharacterDefinition
    {
        Animation[] animations;
        Frame[] frames;
        public string Path;

        public int HeadIndex;
        public int TorsoIndex;
        public int LegsIndex;
        public int WeaponIndex;

        public CharacterType CharType = CharacterType.Player1;
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterDefinition"/> class.
        /// Creates the animation and frame array and then reads character data from file to fill
        /// all fields
        /// </summary>
        /// <param name="path">The path.</param>
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
        #endregion
        #region Properties

        public Animation[] Animations
        {
            get { return animations; }
        }

        public Frame[] Frames
        {
            get { return frames; }
        }
        #endregion
        /// <summary>
        /// Reads character definition (parts, animations, scripts, keyframes) from file.
        /// </summary>
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

                    ScriptLine[] scripts = keyframe.Scripts;
                    for (int s = 0; s < scripts.Length; s++)
                        scripts[s] = new ScriptLine(binaryReader.ReadString());
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
