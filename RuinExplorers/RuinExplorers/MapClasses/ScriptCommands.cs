using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuinExplorers.MapClasses
{
    public enum ScriptCommands
    {
        Fog = 0,
        Monster,
        MakeBucket,
        AddBucket,
        IfNotBucketGoto,
        Wait,
        SetFlag,
        IfTrueGoto,
        IfFalseGoto,
        SetGlobalFlag,
        IfGlobalTrueGoto,
        IfGlobalFalseGoto,
        Stop,
        SetLeftExit,
        SetLeftEntrance,
        SetRightExit,
        SetRightEntrance,
        SetIntroEntrance,
        Water,
        Tag        
    }
}
