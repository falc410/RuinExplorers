using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuinExplorers.CharacterClasses;
using Microsoft.Xna.Framework;

namespace RuinExplorers.MapClasses
{
    public class MapScript
    {
        Map map;

        public MapScriptLine[] Lines;

        int currentLine;
        float waiting;
        public bool IsReading;

        public MapFlags Flags;

        public MapScript(Map _map)
        {
            this.map = _map;
            Flags = new MapFlags(32);
            Lines = new MapScriptLine[128];
        }

        public void DoScript(Character[] characters)
        {
            if (waiting > 0f)
            {
                waiting -= RuinExplorersMain.FrameTime;
            }
            else
            {
                bool done = false;
                while (!done)
                {
                    currentLine++;
                    if (Lines[currentLine] != null)
                    {
                        switch (Lines[currentLine].Command)
                        {
                            case ScriptCommands.Fog:
                                map.Fog = Lines[currentLine].IntParameter;
                                break;
                            case ScriptCommands.Water:
                                map.Water = (float)Lines[currentLine].IntParameter;
                                break;
                            case ScriptCommands.Monster:
                                for (int i = 0; i < characters.Length; i++)
                                {
                                    if (characters[i] == null)
                                    {
                                        characters[i] = new Character(
                                            Lines[currentLine].Vector2Parameter,
                                            RuinExplorersMain.CharacterDefinitions[(int)GetMonsterFromString(Lines[currentLine].StringParameter[1])],
                                            i, Character.TEAM_NPC);
                                        if (Lines[currentLine].StringParameter.Length > 4)
                                            characters[i].Name = Lines[currentLine].StringParameter[4];
                                        break;
                                    }
                                }
                                break;

                            case ScriptCommands.MakeBucket:
                                map.Bucket = new Bucket(Lines[currentLine].IntParameter);
                                break;
                            case ScriptCommands.AddBucket:
                                map.Bucket.AddItem(Lines[currentLine].Vector2Parameter,
                                    GetMonsterFromString(Lines[currentLine].StringParameter[1]));
                                break;
                            case ScriptCommands.IfNotBucketGoto:
                                if (map.Bucket.IsEmpty)
                                {
                                    GotoTag(Lines[currentLine].StringParameter[1]);
                                }
                                break;

                            case ScriptCommands.Wait:
                                waiting = (float)Lines[currentLine].IntParameter / 100f;
                                done = true;
                                break;

                            case ScriptCommands.SetFlag:
                                Flags.SetFlag(Lines[currentLine].StringParameter[1]);
                                break;
                            case ScriptCommands.IfTrueGoto:
                                if (Flags.GetFlag(Lines[currentLine].StringParameter[1]))
                                    GotoTag(Lines[currentLine].StringParameter[2]);
                                break;
                            case ScriptCommands.IfFalseGoto:
                                if (!Flags.GetFlag(Lines[currentLine].StringParameter[1]))
                                    GotoTag(Lines[currentLine].StringParameter[2]);
                                break;

                            case ScriptCommands.SetGlobalFlag:
                                map.GlobalFlags.SetFlag(Lines[currentLine].StringParameter[1]);
                                break;
                            case ScriptCommands.IfGlobalTrueGoto:
                                if (map.GlobalFlags.GetFlag(Lines[currentLine].StringParameter[1]))
                                    GotoTag(Lines[currentLine].StringParameter[2]);
                                break;
                            case ScriptCommands.IfGlobalFalseGoto:
                                if (!map.GlobalFlags.GetFlag(Lines[currentLine].StringParameter[1]))
                                    GotoTag(Lines[currentLine].StringParameter[2]);
                                break;

                            case ScriptCommands.Stop:
                                IsReading = false;
                                done = true;
                                break;
                            case ScriptCommands.Tag:
                                //
                                break;
                            //case ScriptCommands.SetLeftExit:
                            //    map.TransitionDestination[(int)TransitionDirection.Left] =
                            //        Lines[currentLine].StringParameter[1];
                            //    break;
                            //case ScriptCommands.SetRightExit:
                            //    map.TransitionDestination[(int)TransitionDirection.Right] =
                            //        Lines[currentLine].StringParameter[1];
                            //    break;
                            //case ScriptCommands.SetLeftEntrance:
                            //    if (map.TransDir ==
                            //        TransitionDirection.Right)
                            //    {
                            //        characters[0].Loc = Lines[currentLine].Vector2Parameter;
                            //        characters[0].Face = CharDir.Right;
                            //        characters[0].SetAnim("fly");
                            //        characters[0].State = CharState.Air;
                            //        characters[0].Trajectory = new Vector2(200f, 0f);
                            //        map.TransDir = TransitionDirection.None;
                            //    }
                            //    break;
                            //case ScriptCommands.SetRightEntrance:
                            //    if (map.TransDir ==
                            //        TransitionDirection.Left)
                            //    {
                            //        characters[0].Loc = Lines[currentLine].Vector2Parameter;
                            //        characters[0].Face = CharDir.Left;
                            //        characters[0].SetAnim("fly");
                            //        characters[0].State = CharState.Air;
                            //        characters[0].Trajectory = new Vector2(-200f, 0f);
                            //        map.TransDir = TransitionDirection.None;
                            //    }
                            //    break;
                            //case ScriptCommands.SetIntroEntrance:
                            //    if (map.TransDir ==
                            //        TransitionDirection.Intro)
                            //    {
                            //        characters[0].Loc = Lines[currentLine].Vector2Parameter;
                            //        characters[0].Face = CharDir.Right;
                            //        characters[0].SetAnim("fly");
                            //        characters[0].State = CharState.Air;
                            //        characters[0].Trajectory = new Vector2(0f, 0f);
                            //        map.TransDir = TransitionDirection.None;
                            //    }
                            //    break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        public bool GotoTag(String tag)
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i] != null)
                {
                    if (Lines[i].Command == ScriptCommands.Tag)
                    {
                        if (Lines[i].StringParameter[1] == tag)
                        {
                            currentLine = i;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static CharacterType GetMonsterFromString(String m)
        {
            switch (m)
            {
                case "zombie":
                    return CharacterType.Zombie;
            }
            return CharacterType.Zombie;
        }
    }
}
