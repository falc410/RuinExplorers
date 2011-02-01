using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuinExplorers.CharacterClasses
{
    /// <summary>
    /// This class sets the command Parameter according to script input.
    /// It's called from Script.DoScript(int animIndex, int keyFrameIndex).
    /// Scriptline instances are created in the KeyFrame class (contains an array of 
    /// 4 ScriptLine instances).
    /// Script commands and parameters are saved in the character file and thus 
    /// created within the character editor.
    /// We have a switch statement for the different script commands and then set
    /// the command and parameter according to input.
    /// Notice that all script commands are lowercase only. A correspoding
    /// command should exist in the Commands enum.
    /// </summary>
    class ScriptLine
    {
        Commands command;
        String stringParameter;
        int intParameter;

        #region Properties
        
        public Commands Command
        {
            get { return command; }
        }

        public int IntParameter
        {
            get { return intParameter; }
        }

        public String StringParameter
        {
            get { return stringParameter; }
        }
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptLine"/> class.
        /// Contains a switch-case statement to read a supplied script command
        /// and parameter and set the local variables accordingly.
        /// </summary>
        /// <param name="line">The line.</param>
        public ScriptLine(string line)
        {
            string[] split = line.Split(' ');

            try
            {
                switch (split[0].Trim().ToLower())
                {
                    // setanim newanim : Set current Animation to 'newanim' at frame 0
                    case "setanim":
                        command = Commands.SetAnim;
                        stringParameter = split[1];
                        break;
                    // goto frame : jump to frame 'frame' of the current animation
                    case "goto":
                        command = Commands.Goto;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    // ifupgoto frame : jump to frame 'frame' of the current animation if up is pressed
                    case "ifupgoto":
                        command = Commands.IfUpGoto;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    // ifdowngoto frame : jump to frame 'frame' of the current animation if down is pressed
                    case "ifdowngoto":
                        command = Commands.IfDownGoto;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    // float : cause an airborne character to begin hovering. used for air combos
                    case "float":
                        command = Commands.Float;
                        break;
                    // cause an airborne, floating character to stop floating and drop to the ground at normal speed
                    case "unfloat":
                        command = Commands.UnFloat;
                        break;
                    // slide xval : slide the character forward by 'xval'
                    case "slide":
                        command = Commands.Slide;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    // backup xval : back up the character by 'xval'
                    case "backup":
                        command = Commands.Backup;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    // setjump yval : set the character airborne at speed 'yval'
                    case "setjump":
                        command = Commands.SetJump;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    // cause the character to move left or right if pressed in that direction
                    case "joymove":
                        command = Commands.JoyMove;
                        break;
                    // clear the key goto array
                    case "clearkeys":
                        command = Commands.ClearKeys;
                        break;
                    // setuppergoto frame : set the uppercut slot of the key goto array to link to frame 'frame'
                    case "setuppergoto":
                        command = Commands.SetUpperGoto;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    // setlowergoto frame : set the lower attack slot of the key goto array to link to frame 'frame'
                    case "setlowergoto":
                        command = Commands.SetLowerGoto;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    // setatkgoto frame : set the normal attack slot of the key goto array to link to frame 'frame'
                    case "setatkgoto":
                        command = Commands.SetAtkGoto;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                   // setanygoto frame : set the normal attack, uppercut and lower attack slots of the key goto array to link to frame 'frame'
                    case "setanygoto":
                        command = Commands.SetAnyGoto;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    // setsecgoto frame : set the secondary attack slot of the goto key array to link to frame 'frame'
                    case "setsecgoto":
                        command = Commands.SetSecondaryGoto;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    // setsecupgoto frame : set the upper secondary attack slot of the goto key array to link to frame 'frame'
                    case "setsecupgoto":
                        command = Commands.SetSecUpGoto;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    // setsecdowngoto frame : set the lower secondary attack slot of the goto key array to link to frame 'frame;
                    case "setsecdowngoto":
                        command = Commands.SetSecDownGoto;
                        intParameter = Convert.ToInt32(split[1]);
                        break;
                    case "play":
                        command = Commands.PlaySound;
                        stringParameter = split[1];
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
