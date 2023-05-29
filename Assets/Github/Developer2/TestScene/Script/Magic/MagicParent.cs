using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicParent : MonoBehaviour
{
    //特殊魔法は発動していない
    bool SpecialMagicFlg;

    //通常魔法は発動していない
    bool StandardMagicFlg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //右クリックで通常魔法発動
            StandardMagicFlg = true;
            return;
        }
        else
        {
            StandardMagicFlg = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //右クリックで特殊魔法発動
            SpecialMagicFlg = true;
            return;
        }
        else
        {
            SpecialMagicFlg = false;
        }
    }
}
