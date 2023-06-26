using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    //弾のPrefab
    [SerializeField, Tooltip("弾のPrefab")]
    private GameObject _bulletPrefab;

    //砲身のオブジェクト
    [SerializeField, Tooltip("砲身のオブジェクト")]
    private GameObject _barrelObject;

    //弾を生成する位置情報
    private Vector3 _instantiatePosition;

    //弾の生成座標(読み取り専用)
    public Vector3 InstantiatePosition
    {
        get { return _instantiatePosition; }
    }

    //弾の速さ
    [SerializeField, Range(1.0f,20.0f), Tooltip("弾の射出する速さ")]
    private float _speed = 1.0f;

    //弾の初速度
    private Vector3 _shootVelocity;

    //弾の初速度(読み取り専用)
    public Vector3 ShootVelocity
    {
        get { return _shootVelocity; }
    }

    ///<summary>
    ///着弾点の座標を持つコンポーネント
    ///</summary>
    private DrawMarker _drawMarker;

    [SerializeField] private GameObject _groundPrehab;

    ///<summary>
    ///発射オブジェクトの正面ベクトル(読み取り専用)
    ///</summary>
    public Vector3 GetTransformForward
    {
        get { return _barrelObject.transform.forward; }
    }

    private void Start()
    {
        _drawMarker = GetComponent<DrawMarker>();
    }

    private void Update()
    {
        // 弾の初速度を更新
        _shootVelocity = _barrelObject.transform.up * _speed;

        // 弾の生成座標を更新
        _instantiatePosition = _barrelObject.transform.position;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //弾を生成
            //GameObject obj = Instantiate(_bulletPrefab,startPosition,Quaternion.identity);

        }
    }
}
