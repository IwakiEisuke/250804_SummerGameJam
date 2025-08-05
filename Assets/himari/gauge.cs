using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class gauge : MonoBehaviour
{
    //満腹ゲージのMAXを最少を1最大を100の範囲で開始する
    [Range(1,100)]public float _fullnessgauge = 100.0f;
    //現在の満腹ゲージ
     [Range(1, 100), SerializeField] private float _currentGauge = 0.0f;
    //画像を取得する(満腹ゲージのゲージ画像をアタッチする)
    [SerializeField] private  Image _image;

    [SerializeField] UnityEvent OnGaugeFull;

    private void Start()
    {
        //最初は空腹
        _image.fillAmount = _currentGauge / _fullnessgauge;
    }
    

/// <summary>
/// 満腹ゲージの関数
/// </summary>
/// <param name="increaseValue">満腹具合</param>
    public void AddFullness(float increaseValue)
    {
        //ゲージを増やす
        _currentGauge += increaseValue;

        _image.fillAmount = _currentGauge/_fullnessgauge;

        //もし現在の満腹ゲージがMAXになったら
        if (_currentGauge >= _fullnessgauge)
        {
            //これは仮の出力
            Debug.Log("おなかいっぱいになりました");
            OnGaugeFull.Invoke();
        }
    }
}
