using UnityEngine;

public class ButtonPushSound : MonoBehaviour
{
    public void PlayPushSound()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.SwitchPush);
    }
}
