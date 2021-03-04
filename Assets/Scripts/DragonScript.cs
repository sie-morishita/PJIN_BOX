using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    public GameObject Fire;
    bool isFire;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger) return;

        if(other.tag == "Player")
        {
            // ターゲット位置
            Vector3 targetPos = other.bounds.center;

            // プレイヤー以外のレイヤマスク
            int layerMask = ~(1 << other.gameObject.layer);

            // プレイヤー以外を対象にLinecastして、ヒットするかチェック
            // ヒットしなければ、炎を吐く
            if (!Physics.Linecast(transform.position, targetPos, layerMask, QueryTriggerInteraction.Ignore))
            {
                if (!Fire.activeSelf)
                {
                    Fire.SetActive(true);
                    Invoke("DisableFire", 1.0f);
                }
            }
        }
    }

    void DisableFire()
    {
        Fire.SetActive(false);
    }
}
