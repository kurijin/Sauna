using UnityEngine;
using Random = UnityEngine.Random;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField, Header("アイテムスプライト")] private GameObject _itemSprite;

    [SerializeField, Header("アイテムのクールタイムの最低値")] private float _minCoolTime;

    [SerializeField, Header("クールタイムの最大値")] private float _maxCoolTime;

    private float _itemCreateCoolTime = 0f;

    [SerializeField,Header("生成する位置")] private Vector2 _createPos;

    private void Update()
    {
        CreateHealthItem();
    }

    /// <summary>
    /// ランダムにItemを生成する
    /// </summary>
    private void CreateHealthItem()
    {
        _itemCreateCoolTime += Time.deltaTime;
        float randomTime = Random.Range(_minCoolTime, _maxCoolTime);

        if (_itemCreateCoolTime > randomTime)
        {
            Instantiate(_itemSprite, new Vector2(_createPos.x, _createPos.y),Quaternion.identity);
            _itemCreateCoolTime = 0f;
        }
    }
}