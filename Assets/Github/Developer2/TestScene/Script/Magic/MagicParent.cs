using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicParent : MonoBehaviour
{
    //���ꖂ�@�͔������Ă��Ȃ�
    bool SpecialMagicFlg;

    //�ʏ햂�@�͔������Ă��Ȃ�
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
            //�E�N���b�N�Œʏ햂�@����
            StandardMagicFlg = true;
            return;
        }
        else
        {
            StandardMagicFlg = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //�E�N���b�N�œ��ꖂ�@����
            SpecialMagicFlg = true;
            return;
        }
        else
        {
            SpecialMagicFlg = false;
        }
    }
}
