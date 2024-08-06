# Outline Filter

[![Twitter](https://img.shields.io/badge/Twitter-Twitter?logo=X&color=red)](https://twitter.com/NullTale)
[![Discord](https://img.shields.io/badge/Discord-Discord?logo=discord&color=white)](https://discord.gg/CkdQvtA5un)
[![Boosty](https://img.shields.io/badge/Support-Boosty?logo=boosty&color=white)](https://boosty.to/nulltale/donate)
[![Asset Store](https://img.shields.io/badge/Asset%20Store-asd?logo=Unity&color=blue)](https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/270019)

Screen Outline effect for Unity Urp, controlled via volume profile </br>
Works as render feature or a pass for selective post processing [VolFx](https://github.com/NullTale/VolFx)

Effect work like [sobel](https://en.wikipedia.org/wiki/Sobel_operator) filter by image [luma](https://en.wikipedia.org/wiki/Luma_(video)) or [chroma](https://en.wikipedia.org/wiki/Chrominance), outline the contrast zones.<br>
Also can work by depth for 3D objects or alpha if used in [VolFx](https://github.com/NullTale/VolFx).<br>
Has gradient coloring and fill options for stylization purposes.
> To work by depth the depth texture must be enabled in the urp asset settings

![_cover](https://github.com/NullTale/OutlineFilter/assets/1497430/ca30a418-585d-40f0-8ccf-cb847d8e5f46)

## Part of Artwork Project

* [Vhs](https://github.com/NullTale/VhsFx)
* [OldMovie](https://github.com/NullTale/OldMovieFx)
* [GradientMap](https://github.com/NullTale/GradientMapFilter)
* [ScreenOutline]
* [ImageFlow](https://github.com/NullTale/FlowFx)
* [Pixelation](https://github.com/NullTale/PixelationFx)
* [Ascii](https://github.com/NullTale/AsciiFx)
* [Dither](https://github.com/NullTale/DitherFx)
* ...
  
## Usage
Install via Unity [PackageManager](https://docs.unity3d.com/Manual/upm-ui-giturl.html)</br>
Add `OutlineFilter` to the UrpRenderer
```
https://github.com/NullTale/OutlineFilter.git
```

Can be used for short accents or drawing stylization</br>
Default Volume parameters like outline color and filter mode can be configured in the asset</br>

![_asset](https://github.com/NullTale/OutlineFilter/assets/1497430/e64fb73e-3e37-4ec3-b260-9a2fb338139f)
