using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "RayTracingRenderPipelineAsset", menuName = "Rendering/RayTracingRenderPipelineAsset", order = -1)]
public class RayTracingRenderPipelineAsset : RenderPipelineAsset
{
  public RaytracingRenderFeatureAsset tutorialAsset;

  protected override RenderPipeline CreatePipeline()
  {
    return new RayTracingRenderPipeline(this);
  }
}
