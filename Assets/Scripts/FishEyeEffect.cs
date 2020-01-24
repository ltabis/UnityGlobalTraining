using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEyeEffect : MonoBehaviour
{
    // Material that will be applied to the image.
    public Material EffectMat;

    // Rendering the image and mul the material on .
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Debug.Log("PASSED");
        Graphics.Blit(source, destination, EffectMat);
    }
}
