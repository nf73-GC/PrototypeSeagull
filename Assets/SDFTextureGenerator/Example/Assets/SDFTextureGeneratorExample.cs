/*
	Copyright © Carl Emil Carlsen 2021
	http://cec.dk
*/

using UnityEngine;
using UnityEngine.Events;

public class SDFTextureGeneratorExample : MonoBehaviour
{
	[SerializeField] Texture depthMaskTexture;
	[SerializeField] float sourceValueThreshold = 0.5f;
    public Material waterMaterial;
    [Range(0f, 1f)] public float threshold = 0.5f;

    private SDFTextureGenerator _sdfGen;

	void onAwake()
	{
		_sdfGen = new SDFTextureGenerator();
	}


	void OnDisable()
	{
		_sdfGen.Release();
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