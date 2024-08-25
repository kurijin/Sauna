using UnityEngine;

public class BurnOutEffect : MonoBehaviour
{
    public Shader burnShader; 
    public float burnDuration = 2.0f;
    private Material material;
    private float burnAmount = 0.0f;
    private bool isBurning = false;

    void Start()
    {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && burnShader != null)
        {
            material = new Material(spriteRenderer.material);
            material.shader = burnShader;
            spriteRenderer.material = material;

            Texture2D noiseTexture = GenerateTexture();
            material.SetTexture("_NoiseTex", noiseTexture);
        }
    }

    void Update()
    {

        if (isBurning)
        {
            burnAmount += Time.deltaTime / burnDuration;
            material.SetFloat("_BurnAmount", burnAmount);

            if (burnAmount >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    // 燃焼を開始する
    public void StartBurning()
    {
        isBurning = true;
        Debug.Log("燃焼");
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(256, 256);

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                float xCoord = (float)x / texture.width * 10.0f;
                float yCoord = (float)y / texture.height * 10.0f;

                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                texture.SetPixel(x, y, new Color(sample, sample, sample));
            }
        }

        texture.Apply();
        return texture;
    }
}
