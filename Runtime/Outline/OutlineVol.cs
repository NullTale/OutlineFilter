using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

//  OutlineFilter © NullTale - https://twitter.com/NullTale/
namespace VolFx
{
    [Serializable, VolumeComponentMenu("VolFx/Outline")]
    public sealed class OutlineVol : VolumeComponent, IPostProcessComponent
    {
        public ClampedFloatParameter m_Sensitive = new ClampedFloatParameter(0, 0, .2f);
        public ClampedFloatParameter m_Thickness = new ClampedFloatParameter(0.15f, 0, 1);
        public GradientParameter     m_Color     = new GradientParameter(OutlineDefault, false);
        public ColorParameter        m_Fill      = new ColorParameter(new Color(1, 1, 1, 0), false);
        public ModeParameter         m_Mode      = new ModeParameter(OutlinePass.Mode.Luma, false);

        public static GradientValue OutlineDefault
        {
            get
            {
                var grad = new Gradient();
                grad.SetKeys(new []{new GradientColorKey(Color.black, 0f), new GradientColorKey(Color.black, 1f)}, new GradientAlphaKey[]{new GradientAlphaKey(0f, 0f), new GradientAlphaKey(0f, 0f)});
                
                return new GradientValue(grad);
            }
        }
        
        [Serializable]
        public class ModeParameter : VolumeParameter<OutlinePass.Mode>
        {
            public ModeParameter(OutlinePass.Mode value, bool overrideState) : base(value, overrideState) { }
        } 
        
        // =======================================================================
        public bool IsActive() => active && (m_Thickness.value > 0f && m_Sensitive.value > 0f) || m_Fill.value.a > 0f;

        public bool IsTileCompatible() => false;
    }
}