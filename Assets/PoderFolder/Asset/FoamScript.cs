using UnityEngine;
using UnityEngine.Events;

public class WaterFoam : MonoBehaviour
{
    [SerializeField] Texture depthMaskTexture;
    [SerializeField] float sourceValueThreshold = 0.5f;
    public Material waterMaterial;
    [Range(0f, 1f)] public float threshold = 0.5f;

    private SDFTextureGenerator _sdfGen;

    void Awake()
    {
        _sdfGen = new SDFTextureGenerator();
    }
    void OnDestroy()
    {
        _sdfGen.Release();
    }

    void Update()
    {
        if (depthMaskTexture == null || waterMaterial == null) return;
        _sdfGen.Update(depthMaskTexture, sourceValueThreshold);
        waterMaterial.SetTexture("_SDFTex", _sdfGen.sdfTexture);
    }
}