using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuinExplorers.Audio;
using RuinExplorers.AIClasses;

namespace RuinExplorers.CharacterClasses
{
    public class Script
    {
        Character character;

        public Script(Character _character)
        {
            this.character = _character;
        }

        /// <summary>
        /// Will be called from Character every time the animation hits a new keyframe.
        /// When a goto is called, done is set to true and script reading ends. This way
        /// a keyframe can call setanim x and then goto y, effectively setting the animation
        /// to x, frame y, but two gotos in a row cannot be called from the same keyframe
        /// </summary>
        /// <param name="animIndex">Index of the animation.</param>
        /// <param name="keyFrameIndex">Index of the key frame.</param>
        public void DoScript(int animIdx, int keyFrameIdx)
        {
            CharacterDefinition charDef = character.Definition;
            Animation animation = charDef.Animations[animIdx];
            KeyFrame keyFrame = animation.KeyFrames[keyFrameIdx];

            bool done = false;

            for (int i = 0; i < keyFrame.Scripts.Length; i++)
            {
                if (done) break;

                ScriptLine line = keyFrame.Scripts[i];

                if (line != null)
                {
                    switch (line.Command)
                    {
                        case Commands.SetAnim:
                            character.SetAnim(line.StringParameter);
                            break;
                        case Commands.Goto:
                            character.AnimationFrame = line.IntParameter;
                            break;
                        case Commands.IfUpGoto:
                            if (character.keyUp)
                            {
                                character.AnimationFrame = line.IntParameter;
                                done = true;
                            }
                            break;
                        case Commands.IfDownGoto:
                            if (character.keyDown)
                            {
                                character.AnimationFrame = line.IntParameter;
                                done = true;
                            }
                            break;
                        case Commands.Float:
                            character.floating = true;
                            break;
                        case Commands.UnFloat:
                            character.floating = false;
                            break;
                        case Commands.Slide:
                            character.Slide(line.IntParameter);
                            break;
                        case Commands.Backup:
                            character.Slide(-line.IntParameter);
                            break;
                        case Commands.SetJump:
                            character.SetJump(line.IntParameter);
                            break;
                        case Commands.JoyMove:
                            if (character.keyLeft)
                                character.Trajectory.X = -character.Speed;
                            else if (character.keyRight)
                                character.Trajectory.X = character.Speed;
                            break;
                        case Commands.ClearKeys:
                            character.PressedKey = PressedKeys.None;
                            break;
                        case Commands.SetUpperGoto:
                            character.GotoGoal[(int)PressedKeys.Upper] = line.IntParameter;
                            break;
                        case Commands.SetAtkGoto:
                            character.GotoGoal[(int)PressedKeys.Attack] = line.IntParameter;
                            break;
                        case Commands.SetAnyGoto:
                            character.GotoGoal[(int)PressedKeys.Upper] = line.IntParameter;
                            character.GotoGoal[(int)PressedKeys.Lower] = line.IntParameter;
                            character.GotoGoal[(int)PressedKeys.Attack] = line.IntParameter;
                            break;
                        case Commands.SetSecondaryGoto:
                            character.GotoGoal[(int)PressedKeys.Secondary] = line.IntParameter;
                            character.GotoGoal[(int)PressedKeys.SecUp] = line.IntParameter;
                            character.GotoGoal[(int)PressedKeys.SecDown] = line.IntParameter;
                            break;
                        case Commands.SetSecUpGoto:
                            character.GotoGoal[(int)PressedKeys.SecUp] = line.IntParameter;
                            break;
                        case Commands.SetSecDownGoto:
                            character.GotoGoal[(int)PressedKeys.SecDown] = line.IntParameter;
                            break;
                        case Commands.PlaySound:
                            Sound.PlayCue(line.StringParameter);
                            break;
                        case Commands.Ethereal:
                            character.Ethereal = true;
                            break;
                        case Commands.Solid:
                            character.Ethereal = false;
                            break;
                        case Commands.Speed:
                            character.Speed = (float)line.IntParameter;
                            break;
                        case Commands.HP:
                            character.HP = character.MHP = line.IntParameter;
                            break;
                        case Commands.DeathCheck:
                            if (character.HP < 0)
                            {
                                character.KillMe();
                            }
                            break;
                        case Commands.IfDyingGoto:
                            if (character.HP < 0)
                            {
                                character.SetFrame(line.IntParameter);
                                done = true;
                            }
                            break;
                        case Commands.KillMe:
                            character.KillMe();
                            break;
                        case Commands.AI:
                            switch (line.StringParameter)
                            {
                                case "zombie":
                                    character.Ai = new Zombie();
                                    break;                              
                                default:
                                    character.Ai = new Zombie();
                                    break;
                            }
                            break;
                        case Commands.Size:
                            character.Scale = (float)(line.IntParameter) / 200f;
                            break;
                        case Commands.NoLifty:
                            character.NoLifty = true;
                            break;
                    }
                }
            }

        }
    }
}
