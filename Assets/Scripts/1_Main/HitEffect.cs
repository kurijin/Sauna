using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public Shader hitShader;
    public float effectDuration = 2.0f;
    public Color hitColor = Color.red; // ヒット時の色
    public float shakePower = 10.0f; // 揺れのパワー
    public float shakeFrequency = 10.0f; // 揺れの周波数

    private float shakeRate = 0.5f;
    private Material material;
    private float effectTime = 0.0f;
    private bool isEffectActive = false;
    private Color originalColor;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && hitShader != null)
        {
            material = new Material(hitShader);
            spriteRenderer.material = material;

            originalColor = spriteRenderer.color;
            material.SetColor("_HitColor", hitColor);
            material.SetColor("_OriginalColor", originalColor);
        }
    }

    void Update()
    {
        if (isEffectActive)
        {
            effectTime += Time.deltaTime / effectDuration;

            // 時間経過とともに shakePower を減少させる
            float currentShakePower = shakePower * (1.0f - effectTime);

            float shakeOffsetX = Mathf.Sin(Time.time * shakeFrequency) * currentShakePower * shakeRate;
            float shakeOffsetY = Mathf.Sin(Time.time * shakeFrequency + Mathf.PI / 2) * currentShakePower * shakeRate;

            Vector2 shakeOffset = new Vector2(shakeOffsetX, shakeOffsetY);

            material.SetVector("_ShakeOffset", shakeOffset);
            material.SetFloat("_EffectTime", effectTime);

            if (effectTime >= 1.0f)
            {
                isEffectActive = false;
                effectTime = 0.0f;
                material.SetVector("_ShakeOffset", Vector2.zero);
            }
        }
    }

    public void StartEffect()
    {
        isEffectActive = true;
    }

    void OnDestroy()
    {
        if (material != null)
        {
            Destroy(material);
        }
    }
}
