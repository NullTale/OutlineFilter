using System;
using UnityEngine;

//  OutlineFilter © NullTale - https://twitter.com/NullTale/
namespace VolFx
{
    [ShaderName("Unlit/Vol/Outline")]
    public class OutlinePass : VolFx.Pass
    {
        private static readonly int s_Thickness       = Shader.PropertyToID("_Thickness");
        private static readonly int s_Sensitive       = Shader.PropertyToID("_Sensitive");
        private static readonly int s_GradientTex     = Shader.PropertyToID("_GradientTex");
        private static readonly int s_BackgroundColor = Shader.PropertyToID("_BackgroundColor");

        [Tooltip("Default mode to filter by value if volume parameter is not set")]
        public  Mode                    _modeDefault  = Mode.Luma;
        private Mode                    _mode         = Mode.Luma;
        private Mode                    _modePrev     = Mode.Alpha;
        private Texture2D               _tex;
        [Tooltip("Default fill color if volume parameter is not set")]
        public  GradientValue           _colorDefault = OutlineVol.OutlineDefault;

        // =======================================================================
        public enum Mode
        {
            // grayscale
            Luma,
            // brightness
            Chroma,
            // alpha, default render camera format hos no alpha channel
            Alpha,
            // from depth buffer [depth texture must be enabled in renderer asset settings!]
            Depth
        }
        
        // =======================================================================
        public override void Init()
        {
            if (_material == null)
                return;
            
            _updateMode(_material);
            _colorDefault.Build(GradientMode.Blend);
        }

        public override bool Validate(Material mat)
        {
            var settings = Stack.GetComponent<OutlineVol>();

            if (settings.IsActive() == false)
                return false;
            
            _mode = settings.m_Mode.overrideState ? settings.m_Mode.value : _modeDefault;
            if (_modePrev != _mode)
                _updateMode(mat);

            mat.SetFloat(s_Thickness, settings.m_Thickness.value.Remap(0, .005f));
            mat.SetFloat(s_Sensitive, settings.m_Sensitive.value.Remap(0, 50f));
            mat.SetColor(s_BackgroundColor, settings.m_Fill.value);
            
            if (_tex == null)
            {
                _tex = new Texture2D(GradientValue.k_Width, 1, TextureFormat.RGBA32, false);
                _tex.wrapMode = TextureWrapMode.Clamp;
            }
            
            var grad = settings.m_Color.overrideState ? settings.m_Color.value : _colorDefault;
            _tex.filterMode = grad._grad.mode == GradientMode.Fixed ? FilterMode.Point : FilterMode.Bilinear;
            _tex.SetPixels(grad._pixels);
            _tex.Apply();
            mat.SetTexture(s_GradientTex, _tex);
            
            return true;
        }

        private void _updateMode(Material mat)
        {
            _modePrev = _mode;
            mat.DisableKeyword("_LUMA");
            mat.DisableKeyword("_ALPHA");
            mat.DisableKeyword("_CHROMA");
            mat.DisableKeyword("_DEPTH");

            mat.EnableKeyword(_mode switch
            {
                Mode.Luma   => "_LUMA",
                Mode.Alpha  => "_ALPHA",
                Mode.Chroma => "_CHROMA",
                Mode.Depth  => "_DEPTH",
                _           => throw new ArgumentOutOfRangeException()
            });
        }
    }
}