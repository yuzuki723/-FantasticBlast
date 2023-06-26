using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMarker : MonoBehaviour
{

    /// <summary>
    /// 放物線を構成する線分の数
    /// </summary>
    //[SerializeField]
    private int _segmentCount = 120;

    /// <summary>
    /// 放物線を何秒分計算するか(距離)
    /// </summary>
    private float _predictionTime =6.0f;

    /// <summary>
    /// 弾の初速度や生成座標を持つコンポーネント
    /// </summary>
    private ShootBullet _shootBuleet;

    /// <summary>
    /// 弾の初速度
    /// </summary>
    private Vector3 _initialVelocity;

    ///<summary>
    ///放物線の開始座標
    ///</summary>
    private Vector3 _arcStartPosition;

    ///<summary>
    ///放物線の終了座標
    ///</summary>
    private Vector3 _arcEndPosition;

    ///<summary>
    ///放物線の終了座標(読み取り専用)
    ///</summary>
    public Vector3 GetArcEndPosition
    {
        get { return _arcEndPosition; }
    }
    
    /// <summary>
    /// 着弾マーカーオブジェクトのPrefab
    /// </summary>
    [SerializeField, Tooltip("着弾マーカーオブジェクトのPrefab")]
    private GameObject _pointerPrefab;

    /// <summary>
    /// 着弾点のマーカーのオブジェクト
    /// </summary>
    private GameObject _pointerObject;


    private void Start()
    {

        //マーカーのオブジェクトを用意
        _pointerObject = Instantiate(_pointerPrefab,Vector3.zero,Quaternion.identity);
        _pointerObject.SetActive(false);

        //弾の初速度や生成座標を持つコンポーネント
        _shootBuleet = gameObject.GetComponent<ShootBullet>();
    }

    private void Update()
    {
        //初速度と放物線の開始座標を更新
        _initialVelocity = _shootBuleet.ShootVelocity;
        _arcStartPosition = _shootBuleet.InstantiatePosition;

        //放射線を表示
        float timeStep = _predictionTime;
        bool draw = false;
        float hitTime = float.MaxValue;
        for (int i = 0; i < _segmentCount; i++)
        {
            //線の座標を更新
            float startTime = timeStep * i;
            float endTime = startTime + timeStep;

            //衝突判定
            if (!draw)
            {
                hitTime = GetArcHitTime(startTime,endTime);
                if (hitTime != float.MaxValue)
                {
                    //衝突したらその先の放射物は表示しない
                    draw = true;
                }
            }
        }

        //マーカーの表示    
        if (hitTime != float.MaxValue)
        {
            Vector3 hitPosition = GetArcPositionAtTime(hitTime);
            _arcEndPosition = hitPosition;
            ShowPointer(hitPosition);
        }

    }

    /// <summary>
    /// 指定時間に対するアーチの放物線上の座標を返す
    /// </summary>
    /// <param name="time">経過時間</param>
    /// <returns>座標</returns>
    private Vector3 GetArcPositionAtTime(float time)
    {
        return (_arcStartPosition + ((_shootBuleet.GetTransformForward * time)));
    }

    /// <summary>
    /// 指定座標にマーカーを表示
    /// </summary>
    /// <param name="position"></param>
    private void ShowPointer(Vector3 position)
    {
        _pointerObject.transform.position = position;
        _pointerObject.SetActive(true);
    }

    /// <summary>
    /// 2点間の線分で衝突判定し、衝突する時間を返す
    /// </summary>
    /// <returns>衝突した時間(してない場合はfloat.MaxValue)</returns>
    private float GetArcHitTime(float startTime, float endTime)
    {
        //Linecastする線分の始終点の座標
        Vector3 startPosition = GetArcPositionAtTime(startTime);
        Vector3 endPosition = GetArcPositionAtTime(endTime);

        //衝突判定
        RaycastHit hitInfo;
        if (Physics.Linecast(startPosition,endPosition,out hitInfo))
        {
            //衝突したColliderまで距離から実際の衝突時間を算出
            float distance = Vector3.Distance(startPosition,endPosition);
            return startTime + (endTime - startTime) * (hitInfo.distance / distance);
        }
        return float.MaxValue;
    }
}
