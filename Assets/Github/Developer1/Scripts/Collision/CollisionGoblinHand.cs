using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGoblinHand : MonoBehaviour
{
    public GoblinAttack m_goblinAttack;
    [SerializeField]
    [Tooltip("当たり判定を入れる")] 
    private BoxCollider m_boxCollider;

    // Start is called before the first frame update
    private void Start()
    {
        m_boxCollider.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_goblinAttack.HandColliderFlgProperty)
        {
            m_boxCollider.enabled = true;
            Debug.Log("ゴブリンのこん棒によってダメージを受けた");
        }
        else
        {
            m_boxCollider.enabled = false;
            Debug.Log("こん棒の当たり判定を解除しました");
        }
    }
}