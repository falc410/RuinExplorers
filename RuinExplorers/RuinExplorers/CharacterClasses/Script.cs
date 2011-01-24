using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuinExplorers.CharacterClasses
{
    class Script
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
        /// <param name="animIndex">Index of the anim.</param>
        /// <param name="keyFrameIndex">Index of the key frame.</param>
        public void DoScript(int animIndex, int keyFrameIndex)
        {
            CharacterDefinition characterDefinition = character.Definition;
            Animation animation = characterDefinition.Animations[animIndex];
            KeyFrame keyFrame = animation.KeyFrames[keyFrameIndex];

            bool done = false;

            for (int i = 0; i < keyFrame.Scripts.Length; i++)
            {
                if (done)
                    break;

                ScriptLine line = keyFrame.Scripts[i];
                if (line != null)
                {
                    switch (line.Command)
                    {
                        case Commands.SetAnim:
                            character.SetAnim(line.SParam);
                            break;
                        case Commands.Goto:
                            character.AnimationFrame = line.IParam;
                            done = true;
                            break;
                        case Commands.IfUpGoto:
                            if (character.keyUp)
                            {
                                character.AnimationFrame = line.IParam;
                                done = true;
                            }
                            break;
                        case Commands.IfDownGoto:
                            if (character.keyDown)
                            {
                                character.AnimationFrame = line.IParam;
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
                            character.Slide(line.IParam);
                            break;
                        case Commands.Backup:
                            character.Slide(-line.IParam);
                            break;
                        case Commands.SetJump:
                            character.SetJump(line.IParam);
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
                            character.GotoGoal[(int)PressedKeys.Upper] = line.IParam;
                            break;
                        case Commands.SetLowerGoto:
                            character.GotoGoal[(int)PressedKeys.Lower] = line.IParam;
                            break;
                        case Commands.SetAtkGoto:
                            character.GotoGoal[(int)PressedKeys.Attack] = line.IParam;
                            break;
                        case Commands.SetAnyGoto:
                            character.GotoGoal[(int)PressedKeys.Upper] = line.IParam;
                            character.GotoGoal[(int)PressedKeys.Lower] = line.IParam;
                            character.GotoGoal[(int)PressedKeys.Attack] = line.IParam;
                            break;
                        case Commands.SetSecondaryGoto:
                            character.GotoGoal[(int)PressedKeys.SecUp] = line.IParam;
                            character.GotoGoal[(int)PressedKeys.SecDown] = line.IParam;
                            character.GotoGoal[(int)PressedKeys.Secondary] = line.IParam;
                            break;
                        case Commands.SetSecUpGoto:
                            character.GotoGoal[(int)PressedKeys.SecUp] = line.IParam;
                            break;
                        case Commands.SetSecDownGoto:
                            character.GotoGoal[(int)PressedKeys.SecDown] = line.IParam;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
