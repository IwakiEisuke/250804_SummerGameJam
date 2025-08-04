

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gauge : MonoBehaviour
{
    //満腹ゲージのマックスを最少を1最大を100の範囲で開始する
    [Range(1,100)]public float _fullnessgauge = 100.0f;
    [Range(1, 10)] public float _damaage = 10.0f;
    //画像を取得する(満腹ゲージのゲージ画像をアタッチする)
    [SerializeField] private  Image _image;



    void Update()
    {
        //もしspaceキーを押したら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damaage(_damaage);
        }


    }

    public void Damaage(float damage)
    {
        //ゲージを減らす
        _fullnessgauge -= damage;

        _image.fillAmount = _fullnessgauge / 100.0f;
    }
}
