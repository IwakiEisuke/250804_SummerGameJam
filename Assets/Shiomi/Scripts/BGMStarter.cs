using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMStarter : MonoBehaviour
{
    //シーンスタート時にBGMを流す
    void Start()
    {
        //現在のシーンを取得
        var currentScene = SceneManager.GetActiveScene().buildIndex;

        //シーンに合わせてBGMを流す
        switch(currentScene)
        {
            case 0:
                SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Title);
                break;
            case 1:
                SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Ingame);
                break;
            case 2:
                SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Result);
                break;
        }
    }
}
