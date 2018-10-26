using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Models.Enumerations
{
    public enum AgeRestriction
    {
        //These need to be numbers instead of words
        [Description("All")]
        All,
        [Description("3")]
        Three,
        [Description("6")]
        Six,
        [Description("9")]
        Nine,
        [Description("12")]
        Twelve,
        [Description("16")]
        Sixteen,
        [Description("18")]
        Eighteen
    }
}
