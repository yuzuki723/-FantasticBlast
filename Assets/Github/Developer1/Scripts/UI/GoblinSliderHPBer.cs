using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinSliderHPBer : MonoBehaviour
{
    private Animator m_animator; //�A�j���[�^�[�R���|�[�l���g�擾�p
    public Canvas m_canvas;
    public Slider m_slider;
    private int m_goblinMaxHP = 100;
    private int m_goblinCurrentHP;

    // Start is called before the first frame update
    private void Start()
    {
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
        m_slider.value = 1; //�X���C�_�[���}�b�N�X�ɂ���
        m_goblinCurrentHP = m_goblinMaxHP; //�S�u������HP�ݒ�
    }

    // Update is called once per frame
    private void Update()
    {
        //GoblinCanvas��FPSCamera(MainCamera)�Ɍ�������(�r���{�[�h�ɂ���)
        m_canvas.transform.rotation = Camera.main.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            //�S�u�����̃_���[�W������
            int goblinDamage = 60;
            Debug.Log(goblinDamage + "�_���[�W�󂯂�");
            m_goblinCurrentHP = m_goblinCurrentHP - goblinDamage;

            //�S�u�����̍ő�HP�ɂ����錻�݂�HP���X���C�_�[�ɔ��f������
            m_slider.value = (float)m_goblinCurrentHP / (float)m_goblinMaxHP;

            if(m_goblinCurrentHP <= 0)
            {
                m_animator.SetBool("Die", true); //���S�A�j���[�V�������J�n����
                Debug.Log("�S�u������|����");
                //Destroy(this.gameObject); //�S�u�������폜����
                //��ɃJ��������f��Ȃ��Ȃ������ɍ폜����
            }
        }
    }
}