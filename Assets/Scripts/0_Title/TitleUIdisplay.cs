using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityEngine.UI;

public class TitleUIdisplay : MonoBehaviour
{
    [SerializeField] private PageContainer _pageContainer;  

    private void Awake()
    {
        // 最初にタイトルページを表示
        _pageContainer.Push("TitlePage", false);
    }
}
