using TMPro;
using UnityEngine;

public class AttackPlayerHealth : MonoBehaviour
{
    // 敵のhpのテキストUIを参照
    [SerializeField] private TextMeshProUGUI _hpText;
    private AttackPlayer _attackPlayer;

    private void Start()
    {
        _attackPlayer = GetComponent<AttackPlayer>();
    }

    private void Update()
    {
        // 敵のHPを参照してテキストUIに表示
        _hpText.text = _attackPlayer._hp.ToString();
    }

    public void SetText(string hp)
    {
        _hpText.text = hp;
    }
}
