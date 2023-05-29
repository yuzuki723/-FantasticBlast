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
        m_slider.value = 1; //スライダーをマックスにする
        m_playerCurrentHP = m_playerMaxHP; //プレイヤーのHP設定
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "Goblin")
        //{
        //    //プレイヤーのダメージ処理↓
        //    int playerDamage = 10;
        //    Debug.Log(playerDamage + "ダメージ受けた");
        //    m_playerCurrentHP = m_playerCurrentHP - playerDamage;

        //    //プレイヤーの最大HPにおける現在のHPをスライダーに反映させる
        //    m_slider.value = (float)m_playerCurrentHP / (float)m_playerMaxHP;
        //}

        if (collision.gameObject.tag == "GoblinRightHand")
        {
            //プレイヤーのダメージ処理↓
            int playerDamage = 50;
            Debug.Log(playerDamage + "ダメージ受けた");
            m_playerCurrentHP = m_playerCurrentHP - playerDamage;

            //プレイヤーの最大HPにおける現在のHPをスライダーに反映させる
            m_slider.value = (float)m_playerCurrentHP / (float)m_playerMaxHP;
        }
    }
}