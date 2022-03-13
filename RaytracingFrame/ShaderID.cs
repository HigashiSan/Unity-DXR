using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ShaderID
{
  public static readonly int _WorldSpaceCameraPos = Shader.PropertyToID("_WorldSpaceCameraPos");
  public static readonly int _InvCameraViewProj = Shader.PropertyToID("_InvCameraViewProj");
  public static readonly int _CameraFarDistance = Shader.PropertyToID("_CameraFarDistance");
  public static readonly int _outputTarget = Shader.PropertyToID("_OutputTarget");
  public static readonly int _outputTargetSize = Shader.PropertyToID("_OutputTargetSize");
  public static readonly int _AccelerationStructure = Shader.PropertyToID("_AccelerationStructure");
}

