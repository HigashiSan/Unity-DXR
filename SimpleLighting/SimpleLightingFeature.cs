using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

public class SimpleLightingFeature : RaytracingRenderFeature
{
  public SimpleLightingFeature(RaytracingRenderFeatureAsset asset) : base(asset)
  {
  }

  public override void Render(ScriptableRenderContext context, Camera camera)
  {
    base.Render(context, camera);
    var pipelineData = _pipeline.RequirePipelineData(camera);
    var outputTarget = pipelineData.rtColor;
    var outputTargetSize = new Vector4(outputTarget.rt.width, outputTarget.rt.height, 1.0f / outputTarget.rt.width, 1.0f / outputTarget.rt.height);
    var accelerationStructure = _pipeline.RequestAccelerationStructure();

    var cmd = CommandBufferPool.Get(typeof(SimpleLightingFeature).Name);
    try
    {
      using (new ProfilingSample(cmd, "RayTracing"))
      {
        cmd.SetRayTracingShaderPass(_shader, "RayTracing");
        cmd.SetRayTracingAccelerationStructure(_shader, ShaderID._AccelerationStructure,
          accelerationStructure);
        cmd.SetRayTracingTextureParam(_shader, ShaderID._outputTarget, outputTarget);
        cmd.SetRayTracingVectorParam(_shader, ShaderID._outputTargetSize, outputTargetSize);
        cmd.DispatchRays(_shader, "SimpleLightingRayGenShader", (uint) outputTarget.rt.width,
          (uint) outputTarget.rt.height, 1, camera);
      }

      context.ExecuteCommandBuffer(cmd);

      using (new ProfilingSample(cmd, "FinalBlit"))
      {
        cmd.Blit(outputTarget, BuiltinRenderTextureType.CameraTarget, Vector2.one, Vector2.zero);
      }

      context.ExecuteCommandBuffer(cmd);
    }
    finally
    {
      CommandBufferPool.Release(cmd);
    }
  }
}
