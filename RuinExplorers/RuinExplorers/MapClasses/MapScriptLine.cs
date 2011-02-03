using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RuinExplorers.MapClasses
{
    public class MapScriptLine
    {
        public ScriptCommands Command;
        public int IntParameter;
        public Vector2 Vector2Parameter;
        public String[] StringParameter;

        public MapScriptLine(String line)
        {
            if (line.Length < 1)
                return;

            StringParameter = line.Split(' ');
            switch (StringParameter[0])
            {
                case "fog":
                    Command = ScriptCommands.Fog;
                    IntParameter = Convert.ToInt32(StringParameter[1]);
                    break;
                case "water":
                    Command = ScriptCommands.Water;
                    IntParameter = Convert.ToInt32(StringParameter[1]);
                    break;

                case "monster":
                    Command = ScriptCommands.Monster;
                    Vector2Parameter = new Vector2(
                        Convert.ToSingle(StringParameter[2]),
                        Convert.ToSingle(StringParameter[3])
                        );
                    break;
                case "makebucket":
                    Command = ScriptCommands.MakeBucket;
                    IntParameter = Convert.ToInt32(StringParameter[1]);
                    break;
                case "addbucket":
                    Command = ScriptCommands.AddBucket;
                    Vector2Parameter = new Vector2(Convert.ToSingle(StringParameter[2]),
                        Convert.ToSingle(StringParameter[3]));
                    break;
                case "ifnotbucketgoto":
                    Command = ScriptCommands.IfNotBucketGoto;
                    break;

                case "wait":
                    Command = ScriptCommands.Wait;
                    IntParameter = Convert.ToInt32(StringParameter[1]);
                    break;

                case "setflag":
                    Command = ScriptCommands.SetFlag;
                    break;
                case "iftruegoto":
                    Command = ScriptCommands.IfTrueGoto;
                    break;
                case "iffalsegoto":
                    Command = ScriptCommands.IfFalseGoto;
                    break;

                case "setglobalflag":
                    Command = ScriptCommands.SetGlobalFlag;
                    break;
                case "ifglobaltruegoto":
                    Command = ScriptCommands.IfGlobalTrueGoto;
                    break;
                case "ifglobalfalsegoto":
                    Command = ScriptCommands.IfGlobalFalseGoto;
                    break;

                case "stop":
                    Command = ScriptCommands.Stop;
                    break;
                case "tag":
                    Command = ScriptCommands.Tag;
                    break;

                case "setleftexit":
                    Command = ScriptCommands.SetLeftExit;
                    break;
                case "setleftentrance":
                    Command = ScriptCommands.SetLeftEntrance;
                    Vector2Parameter = new Vector2(Convert.ToSingle(StringParameter[1]),
                        Convert.ToSingle(StringParameter[2]));
                    break;
                case "setrightexit":
                    Command = ScriptCommands.SetRightExit;
                    break;
                case "setrightentrance":
                    Command = ScriptCommands.SetRightEntrance;
                    Vector2Parameter = new Vector2(Convert.ToSingle(StringParameter[1]),
                        Convert.ToSingle(StringParameter[2]));
                    break;
                case "setintroentrance":
                    Command = ScriptCommands.SetIntroEntrance;
                    Vector2Parameter = new Vector2(Convert.ToSingle(StringParameter[1]),
                        Convert.ToSingle(StringParameter[2]));
                    break;
                default:
                    break;
            }
        }
    }
}
