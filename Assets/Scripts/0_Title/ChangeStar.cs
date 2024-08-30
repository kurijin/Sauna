using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ChangeStar : MonoBehaviour
{
    [SerializeField] private Image easyStar;
    [SerializeField] private Image normalStar;
    [SerializeField] private Image difficultStar;
    [SerializeField] private Sprite whiteStar;
    [SerializeField] private Sprite yellowStar;

   /// <summary>
   /// 各ステージクリアしてたらPlayerPrefsで1,クリアしてなかったら0でクリア済みなら黄色い星になる。
   /// </summary>
    void Start()
    {
        // easy
        if(PlayerPrefs.GetInt("easyClear", 0) == 1)
        {
            easyStar.sprite = yellowStar;
        } 
        else
        {
            easyStar.sprite = whiteStar; 
        }

        // normal
        if(PlayerPrefs.GetInt("normalClear", 0) == 1)
        {
            normalStar.sprite = yellowStar;
        } 
        else
        {
            normalStar.sprite = whiteStar; 
        }

        // difficult
        if(PlayerPrefs.GetInt("difficultClear", 0) == 1)
        {
            difficultStar.sprite = yellowStar;
        } 
        else
        {
            difficultStar.sprite = whiteStar; 
        }
    }
}
