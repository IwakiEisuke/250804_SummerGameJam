

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gauge : MonoBehaviour
{
    //�����Q�[�W�̃}�b�N�X���ŏ���1�ő��100�͈̔͂ŊJ�n����
    [Range(1,100)]public float _fullnessgauge = 100.0f;
    [Range(1, 10)] public float _damaage = 10.0f;
    //�摜���擾����(�����Q�[�W�̃Q�[�W�摜���A�^�b�`����)
    [SerializeField] private  Image _image;



    void Update()
    {
        //����space�L�[����������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damaage(_damaage);
        }


    }

    public void Damaage(float damage)
    {
        //�Q�[�W�����炷
        _fullnessgauge -= damage;

        _image.fillAmount = _fullnessgauge / 100.0f;
    }
}
