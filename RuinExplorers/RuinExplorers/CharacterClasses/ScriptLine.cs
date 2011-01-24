using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuinExplorers.CharacterClasses
{
    class ScriptLine
    {
        Commands command;
        String sParam;
        int iParam;

        #region Properties
        
        public Commands Command
        {
            get { return command; }
        }

        public int IParam
        {
            get { return iParam; }
        }

        public String SParam
        {
            get { return sParam; }
        }
        #endregion

        #region Constructor        
        public ScriptLine(string line)
        {
            string[] split = line.Split(' ');

            try 
	        {
                switch (split[0].Trim().ToLower())
                {
                    case "setAnim":
                        command = Commands.SetAnim;
                        sParam = split[1];
                        break;
                    case "goto":
                        command = Commands.Goto;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "ifupgoto":
                        command = Commands.IfUpGoto;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "ifdowngoto":
                        command = Commands.IfDownGoto;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "float":
                        command = Commands.Float;
                        break;
                    case "unfloat":
                        command = Commands.UnFloat;
                        break;
                    case "slide":
                        command = Commands.Slide;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "backup":
                        command = Commands.Backup;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "setjump":
                        command = Commands.SetJump;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "joymove":
                        command = Commands.JoyMove;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "clearkeys":
                        command = Commands.ClearKeys;
                        break;
                    case "setuppergoto":
                        command = Commands.SetUpperGoto;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "setlowergoto":
                        command = Commands.SetLowerGoto;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "setatkgoto":
                        command = Commands.SetAtkGoto;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "setanygoto":
                        command = Commands.SetAnyGoto;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "setsecgoto":
                        command = Commands.SetSecondaryGoto;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "setsecupgoto":
                        command = Commands.SetSecUpGoto;
                        iParam = Convert.ToInt32(split[1]);
                        break;
                    case "setsecdowngoto":
                        command = Commands.SetSecDownGoto;
                        iParam = Convert.ToInt32(split[1]);
                        break;                       

                    default:
                        break;
                }
	        }
	        catch (Exception e)
	        {		
		        Console.WriteLine(e.StackTrace);
	        }
        }
        #endregion
    }
}
