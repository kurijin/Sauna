using TMPro;
using UnityEngine;

public class AttackPlayerHealth : MonoBehaviour
{
    // 敵のhpのテキストUIを参照
    [SerializeField] private TextMeshProUGUI hpText;

    private AttackPlayer attackPlayer;

    void Start()
    {
        attackPlayer = GetComponent<AttackPlayer>();
    }

    void Update()
    {
        // 敵のHPを参照してテキストUIに表示
        hpText.text = attackPlayer.hp.ToString();
    }

    public void SetText(string hp)
    {
        hpText.text = hp;
    }
}
