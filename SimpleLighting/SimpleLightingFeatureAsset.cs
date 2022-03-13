using UnityEngine;

[CreateAssetMenu(fileName = "SimpleLightingFeatureAsset", menuName = "Rendering/SimpleLightingFeatureAsset")]
public class SimpleLightingFeatureAsset : RaytracingRenderFeatureAsset
{
  public override RaytracingRenderFeature CreateInstance()
  {
    return new SimpleLightingFeature(this);
  }
}
