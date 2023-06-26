using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField] GameObject _standerd;
    [SerializeField] float _standerdSpeed = 100;

    [SerializeField] GameObject _special;

    //杖のアニメーター
    private Animator _cameAnimator;

    private void Awake()
    {
        //杖のアニメーター取得
        _cameAnimator = GetComponentInChildren<Animator>().GetComponentInChildren<Animator>();
    }

    public void ShotIceMagic()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            //通常魔法発動
            ShotMagicStanderd();
            return;
        }

        if(Input.GetMouseButtonDown(1))
        {
            //魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            //特殊魔法発動
            ShotMagicSpecial();
            return;
        }

        //魔法を発動していない時はアニメーションさせない
        _cameAnimator.SetBool("Attack",false);
    }

    private void ShotMagicStanderd()
    {
        
        Quaternion quaternion = transform.root.rotation * Quaternion.Euler(0, -90, 0);

        //出現位置
        Vector3 pos = transform.GetChild(0).GetChild(0).transform.position;

        //魔法が出現
        GameObject magic = (GameObject)Instantiate(_standerd, pos, quaternion);
        Rigidbody rigidbody = magic.GetComponent<Rigidbody>();

        //プレイヤーの正面に飛ばす
        rigidbody.AddForce(transform.root.forward * _standerdSpeed,ForceMode.Acceleration);

        Destroy(magic,3.0f);
    }

    private void ShotMagicSpecial()
    {
        //出現位置
        Vector3 pos = transform.GetChild(0).GetChild(0).transform.position;

        //魔法が出現
        GameObject magic = (GameObject)Instantiate(_special, pos, transform.root.rotation);

        //Destroy(magic,3.0f);
    }
}
