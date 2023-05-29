using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGoblinHand : MonoBehaviour
{
    public GoblinAttack m_goblinAttack;
    [SerializeField]
    [Tooltip("“–‚½‚è”»’è‚ğ“ü‚ê‚é")] 
    private BoxCollider m_boxCollider;

    // Start is called before the first frame update
    private void Start()
    {
        m_boxCollider.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_goblinAttack.HandColliderFlgProperty)
        {
            m_boxCollider.enabled = true;
            Debug.Log("ƒSƒuƒŠƒ“‚Ì‚±‚ñ–_‚É‚æ‚Á‚Äƒ_ƒ[ƒW‚ğó‚¯‚½");
        }
        else
        {
            m_boxCollider.enabled = false;
            Debug.Log("‚±‚ñ–_‚Ì“–‚½‚è”»’è‚ğ‰ğœ‚µ‚Ü‚µ‚½");
        }
    }
}