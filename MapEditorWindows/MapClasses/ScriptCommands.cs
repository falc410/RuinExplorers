using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditorWindows.MapClasses
{
    public enum ScriptCommands
    {
        fog,
        monster,
        makebucket,
        addbucket,
        ifnotbucketgoto,
        wait,
        setflag,
        iftruegoto,
        iffalsegoto,
        setglobalflag,
        ifglobaltruegoto,
        ifglobalfalsegoto,
        stop,
        setleftexit,
        setleftentrance,
        setrightexit,
        setrightentrance,
        setintroentrance,
        water,
        tag        
    }
}
