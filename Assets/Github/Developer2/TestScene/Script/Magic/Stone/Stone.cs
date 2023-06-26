using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] GameObject _standerd;
    [SerializeField] float _standerdSpeed = 100;

    private float _standerdInterval = 0.1f;
    private float _standerdTime = 0.0f;

    [SerializeField] GameObject _special;



    //杖のアニメーター
    private Animator _cameAnimator;

    private void Awake()
    {
        //杖のアニメーター取得
        _cameAnimator = GetComponentInChildren<Animator>().GetComponentInChildren<Animator>();
    }

    public void ShotStoneMagic()
    {
        if(Input.GetMouseButton(0) && _standerdTime <= 0.0f)
        {
            //魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            //通常魔法発動
            ShotMagicStanderd();
            _standerdTime = _standerdInterval;

            return;
        }

        if(_standerdTime > 0.0f)
        {
            _standerdTime -=Time.deltaTime;
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

        //出現位置
        Vector3 pos = transform.GetChild(0).GetChild(0).transform.position;

        //魔法が出現
        GameObject magic = (GameObject)Instantiate(_standerd, pos, Random.rotation);
        Rigidbody rigidbody = magic.GetComponent<Rigidbody>();

        //プレイヤーの正面に飛ばす
        rigidbody.AddForce(transform.root.forward * _standerdSpeed);

        Destroy(magic,1.0f);
    }

    private void ShotMagicSpecial()
    {

    }
}
