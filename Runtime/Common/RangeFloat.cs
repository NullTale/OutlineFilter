#if !VOL_FX

using System;
using UnityEngine;

//  OutlineFilter © NullTale - https://twitter.com/NullTale/
namespace VolFx
{
    [Serializable]
    public class RangeFloat
    {
        public Vector2 Range;
        public float   Value;
        
        public RangeFloat(Vector2 range, float value)
        {
            Range = range;
            Value = value;
        }
    }
}

#endif