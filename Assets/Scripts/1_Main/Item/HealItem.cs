using UnityEngine;

/// <summary>回復アイテムクラス</summary>
public class HealItem : MonoBehaviour
{
    [SerializeField] private int _healPoint;
    private PlayerHealth _playerHealth;

    [SerializeField, Header("オブジェクトを消す時間")] private float _destroyTime = 2f;
    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerHealth = player.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.Log("PlayerHealthが存在しません");
        }
    }

    private void Update()
    {
        _destroyTime -= Time.deltaTime;

        if (_destroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        _playerHealth.Heal(_healPoint);
        Destroy(gameObject);
    }
}
