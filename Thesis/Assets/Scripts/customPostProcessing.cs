using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[SerializeField, VolumeComponentMenuForRenderPipeline
("CustomPostProcess/Tint", typeof(UniversalRenderPipeline))]
public class CustomPostProcessing : VolumeComponent, IPostProcessComponent
{
    public Material material;

    // 新增一个函数，用于获取当前效果是否激活
    public bool IsActive() => material != null && material.shader != null;

    // 新增一个函数，用于检测效果是否兼容Tiled渲染
    public bool IsTileCompatible() => false;

}