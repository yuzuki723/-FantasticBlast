using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinAttack : MonoBehaviour
{
    private Animator m_animator;
    static bool m_handColliderFlg; //�S�u�����̎�̓����蔻���t���邩�𔻒f����

    // Start is called before the first frame update
    private void Start()
    {
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
        m_handColliderFlg = false;
    }

    //�v���C���[��T�m�������Ɏ��s����֐�
    public void OnDetectObject(Collider _collider)
    {
        //���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O���t���Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (_collider.CompareTag("Player"))
        {
            m_animator.SetBool("Attack", true); //�U���A�j���[�V�������J�n����
            Debug.Log(m_animator.GetBool("Attack"));
            m_handColliderFlg = true; //��̓����蔻���t����
        }
    }

    //�T�m�͈͂���v���C���[�����������Ɏ��s����֐�
    public void NotDetectObject(Collider _collider)
    {
        //���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O���t���Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (_collider.CompareTag("Player"))
        {
            m_animator.SetBool("Attack", false); //�U���A�j���[�V�������I������
            Debug.Log(m_animator.GetBool("Attack"));
            m_handColliderFlg = false; //��̓����蔻��𖳂���
        }
    }

    public bool HandColliderFlgProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_handColliderFlg; }
        set { m_handColliderFlg = value; }
    }
}