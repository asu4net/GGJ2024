using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bending : MonoBehaviour
{
    #region Constants

    private const string BENDING_FEATURE = "_ENABLEBENDING";

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        if (Application.isPlaying)
        {
            Shader.EnableKeyword(BENDING_FEATURE);
        } else
        {
            Shader.DisableKeyword(BENDING_FEATURE);
        }
    }

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
    }

    #endregion

    #region Methods

    private static void OnBeginCameraRendering(ScriptableRenderContext ctx, Camera cam)
    {
        cam.cullingMatrix = Matrix4x4.Ortho(-99, 99, -99, 99, 0.001f, 99) * cam.worldToCameraMatrix;
    }

    private static void OnEndCameraRendering(ScriptableRenderContext ctx, Camera cam)
    {
        cam.ResetCullingMatrix();
    }

    #endregion
}
