using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GoblinMove : MonoBehaviour
{
    private Animator m_animator;
    private NavMeshAgent m_agent;

    // Start is called before the first frame update
    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>(); //�R���|�[�l���g���擾
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
    }

    //�v���C���[��T�m�������Ɏ��s����֐�
    public void OnDetectObject(Collider _collider)
    {
        //���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O���t���Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (_collider.CompareTag("Player"))
        {
            m_agent.destination = _collider.transform.position;
            m_animator.SetBool("Move", true); //�ǔ��A�j���[�V�������J�n����
            Debug.Log(m_animator.GetBool("Move"));
        }
    }

    //�T�m�͈͂���v���C���[�����������Ɏ��s����֐�
    public void NotDetectObject(Collider _collider)
    {
        //���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O���t���Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (_collider.CompareTag("Player"))
        {
            m_agent.destination = _collider.transform.position;
            m_animator.SetBool("Move", false); //�ǔ��A�j���[�V�������I������
            Debug.Log(m_animator.GetBool("Move"));
        }
    }
}