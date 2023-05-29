using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSliderHPBer : MonoBehaviour
{
    int m_playerMaxHP = 200;
    int m_playerCurrentHP;
    public Slider m_slider;

    // Start is called before the first frame update
    private void Start()
    {
        m_slider.value = 1; //�X���C�_�[���}�b�N�X�ɂ���
        m_playerCurrentHP = m_playerMaxHP; //�v���C���[��HP�ݒ�
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "Goblin")
        //{
        //    //�v���C���[�̃_���[�W������
        //    int playerDamage = 10;
        //    Debug.Log(playerDamage + "�_���[�W�󂯂�");
        //    m_playerCurrentHP = m_playerCurrentHP - playerDamage;

        //    //�v���C���[�̍ő�HP�ɂ����錻�݂�HP���X���C�_�[�ɔ��f������
        //    m_slider.value = (float)m_playerCurrentHP / (float)m_playerMaxHP;
        //}

        if (collision.gameObject.tag == "GoblinRightHand")
        {
            //�v���C���[�̃_���[�W������
            int playerDamage = 50;
            Debug.Log(playerDamage + "�_���[�W�󂯂�");
            m_playerCurrentHP = m_playerCurrentHP - playerDamage;

            //�v���C���[�̍ő�HP�ɂ����錻�݂�HP���X���C�_�[�ɔ��f������
            m_slider.value = (float)m_playerCurrentHP / (float)m_playerMaxHP;
        }
    }
}