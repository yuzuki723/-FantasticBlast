using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinSliderHPBer : MonoBehaviour
{
    private Animator m_animator; //アニメーターコンポーネント取得用
    public Canvas m_canvas;
    public Slider m_slider;
    private int m_goblinMaxHP = 100;
    private int m_goblinCurrentHP;

    // Start is called before the first frame update
    private void Start()
    {
        m_animator = GetComponent<Animator>(); //アニメーターコンポーネントを取得
        m_slider.value = 1; //スライダーをマックスにする
        m_goblinCurrentHP = m_goblinMaxHP; //ゴブリンのHP設定
    }

    // Update is called once per frame
    private void Update()
    {
        //GoblinCanvasをFPSCamera(MainCamera)に向かせる(ビルボードにする)
        m_canvas.transform.rotation = Camera.main.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            //ゴブリンのダメージ処理↓
            int goblinDamage = 60;
            Debug.Log(goblinDamage + "ダメージ受けた");
            m_goblinCurrentHP = m_goblinCurrentHP - goblinDamage;

            //ゴブリンの最大HPにおける現在のHPをスライダーに反映させる
            m_slider.value = (float)m_goblinCurrentHP / (float)m_goblinMaxHP;

            if(m_goblinCurrentHP <= 0)
            {
                m_animator.SetBool("Die", true); //死亡アニメーションを開始する
                Debug.Log("ゴブリンを倒した");
                //Destroy(this.gameObject); //ゴブリンを削除する
                //後にカメラから映らなくなった時に削除する
            }
        }
    }
}