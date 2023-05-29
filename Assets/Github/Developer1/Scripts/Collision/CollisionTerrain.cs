using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTerrain : MonoBehaviour
{
    [SerializeField] GameObject m_explosion;
    public FireMagicDestroy m_fireMagicDestroy;
    Vector3 m_bombPos; //爆弾の座標

    private void Update()
    {
        if (m_fireMagicDestroy.ToDoExpFlgProperty)
        {
            Debug.Log("爆発します");
            Instantiate(m_explosion, m_bombPos, Quaternion.identity); //爆発(エフェクト)をインスタンス化
            m_fireMagicDestroy.ToDoExpFlgProperty = false; //何度もif文に入ってこないようにする
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bomb") //Terrain(地面)に爆弾が衝突した場合
        {
            Destroy(collision.gameObject, 2.0f);
            m_bombPos = collision.gameObject.transform.position; //爆弾(火魔法)の座標
        }
    }
}