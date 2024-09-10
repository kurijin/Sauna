using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ChangeStar : MonoBehaviour
{
    [SerializeField] private Image easyStar;
    [SerializeField] private Image normalStar;
    [SerializeField] private Image hardStar;
    [SerializeField] private Sprite whiteStar;
    [SerializeField] private Sprite yellowStar;

   /// <summary>
   /// 各ステージクリアしてたらPlayerPrefsで1,クリアしてなかったら0でクリア済みなら黄色い星になる。
   /// </summary>
    private void OnEnable()
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

        // hard
        if(PlayerPrefs.GetInt("hardClear", 0) == 1)
        {
            hardStar.sprite = yellowStar;
        } 
        else
        {
            hardStar.sprite = whiteStar; 
        }
    }
}
