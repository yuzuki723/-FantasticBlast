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
        m_agent = GetComponent<NavMeshAgent>(); //コンポーネントを取得
        m_animator = GetComponent<Animator>(); //アニメーターコンポーネントを取得
    }

    //プレイヤーを探知した時に実行する関数
    public void OnDetectObject(Collider _collider)
    {
        //検知したオブジェクトに「Player」のタグが付いていれば、そのオブジェクトを追いかける
        if (_collider.CompareTag("Player"))
        {
            m_agent.destination = _collider.transform.position;
            m_animator.SetBool("Move", true); //追尾アニメーションを開始する
            Debug.Log(m_animator.GetBool("Move"));
        }
    }

    //探知範囲からプレイヤーが消えた時に実行する関数
    public void NotDetectObject(Collider _collider)
    {
        //検知したオブジェクトに「Player」のタグが付いていれば、そのオブジェクトを追いかける
        if (_collider.CompareTag("Player"))
        {
            m_agent.destination = _collider.transform.position;
            m_animator.SetBool("Move", false); //追尾アニメーションを終了する
            Debug.Log(m_animator.GetBool("Move"));
        }
    }
}