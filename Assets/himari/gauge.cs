using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class gauge : MonoBehaviour
{
    //�����Q�[�W��MAX���ŏ���1�ő��100�͈̔͂ŊJ�n����
    [Range(1,100)]public float _fullnessgauge = 100.0f;
    //���݂̖����Q�[�W
     [Range(1, 100), SerializeField] private float _currentGauge = 0.0f;
    //�摜���擾����(�����Q�[�W�̃Q�[�W�摜���A�^�b�`����)
    [SerializeField] private  Image _image;

    [SerializeField] UnityEvent OnGaugeFull;

    private void Start()
    {
        //�ŏ��͋�
        _image.fillAmount = _currentGauge / _fullnessgauge;
    }
    

/// <summary>
/// �����Q�[�W�̊֐�
/// </summary>
/// <param name="increaseValue">�����</param>
    public void AddFullness(float increaseValue)
    {
        //�Q�[�W�𑝂₷
        _currentGauge += increaseValue;

        _image.fillAmount = _currentGauge/_fullnessgauge;

        //�������݂̖����Q�[�W��MAX�ɂȂ�����
        if (_currentGauge >= _fullnessgauge)
        {
            //����͉��̏o��
            Debug.Log("���Ȃ������ς��ɂȂ�܂���");
            OnGaugeFull.Invoke();
        }
    }
}
