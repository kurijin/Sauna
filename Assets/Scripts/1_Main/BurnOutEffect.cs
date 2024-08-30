using UnityEngine;

public class BurnOutEffect : MonoBehaviour
{
    public Shader _burnShader;
    public float _burnDuration = 2.0f;
    private Material _material;
    private float _burnAmount;
    private bool _isBurning;

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && _burnShader != null)
        {
            _material = new Material(spriteRenderer.material);
            _material.shader = _burnShader;
            spriteRenderer.material = _material;

            Texture2D noiseTexture = GenerateTexture();
            _material.SetTexture("_NoiseTex", noiseTexture);
        }
    }

    private void Update()
    {
        if (_isBurning)
        {
            _burnAmount += Time.deltaTime / _burnDuration;
            _material.SetFloat("_BurnAmount", _burnAmount);

            if (_burnAmount >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    // 燃焼を開始する
    public void StartBurning()
    {
        _isBurning = true;
        Debug.Log("燃焼");
    }

    private Texture2D GenerateTexture()
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