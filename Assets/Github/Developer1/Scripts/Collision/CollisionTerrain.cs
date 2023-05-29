using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTerrain : MonoBehaviour
{
    [SerializeField] GameObject m_explosion;
    public FireMagicDestroy m_fireMagicDestroy;
    Vector3 m_bombPos; //���e�̍��W

    private void Update()
    {
        if (m_fireMagicDestroy.ToDoExpFlgProperty)
        {
            Debug.Log("�������܂�");
            Instantiate(m_explosion, m_bombPos, Quaternion.identity); //����(�G�t�F�N�g)���C���X�^���X��
            m_fireMagicDestroy.ToDoExpFlgProperty = false; //���x��if���ɓ����Ă��Ȃ��悤�ɂ���
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bomb") //Terrain(�n��)�ɔ��e���Փ˂����ꍇ
        {
            Destroy(collision.gameObject, 2.0f);
            m_bombPos = collision.gameObject.transform.position; //���e(�Ζ��@)�̍��W
        }
    }
}