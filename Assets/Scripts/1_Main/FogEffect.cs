using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class FogEffect : MonoBehaviour
{
    public Shader fogShader;
    private Material fogMaterial;

    public int textureWidth = 256;
    public int textureHeight = 256;
    public float scale = 20f;

    [Range(0.0f, 1.0f)]
    public float fogDensity = 0.1f;

    public Color fogColor = Color.gray;

    [Range(0.1f, 1.0f)]
    public float noiseScale = 1.0f;

    public Vector2 noiseSpeed = new Vector2(0.1f, 0.1f);

    private Vector2 noiseOffset = Vector2.zero;

    void Start()
    {
        fogMaterial = new Material(fogShader);
        fogMaterial.SetVector("_NoiseOffset", noiseOffset);
        fogMaterial.SetTexture("_NoiseTex", GenerateTexture());
    }


    
    void Update()
    {
        noiseOffset += noiseSpeed * Time.deltaTime;
        fogMaterial.SetVector("_NoiseOffset", noiseOffset);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (fogMaterial != null)
        {
            fogMaterial.SetFloat("_FogDensity", fogDensity);
            fogMaterial.SetColor("_FogColor", fogColor);
            fogMaterial.SetFloat("_NoiseScale", noiseScale);

            Graphics.Blit(source, destination, fogMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    Texture2D GenerateTexture()
    //霧ノイズテクスチャを作成。
    {
        Texture2D texture = new Texture2D(textureWidth, textureHeight);

        for (int y = 0; y < textureHeight; y++)
        {
            for (int x = 0; x < textureWidth; x++)
            {
                float xCoord = (float)x / textureWidth * scale;
                float yCoord = (float)y / textureHeight * scale;

                // シームレスにする
                float sample = (Mathf.PerlinNoise(xCoord, yCoord) +
                                Mathf.PerlinNoise(xCoord + scale, yCoord) +
                                Mathf.PerlinNoise(xCoord, yCoord + scale) +
                                Mathf.PerlinNoise(xCoord + scale, yCoord + scale)) / 4.0f;

                texture.SetPixel(x, y, new Color(sample, sample, sample));
            }
        }
        texture.Apply();
        return texture;
    }

}
