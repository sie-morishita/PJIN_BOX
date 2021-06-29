using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    public GameObject Fire;
    public bool isDamaged;
    Quaternion DefaultRot;
    Animator anim;

    void Start()
    {
        DefaultRot = transform.rotation;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDamaged) Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger) return;

        if(other.tag == "Player" && !StageControllerScript.isGameOver)
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
                    transform.LookAt(other.transform);
                    Fire.SetActive(true);
                    Invoke("DisableFire", 1.0f);

                    anim.SetTrigger("AttackTrigger");
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().isDamaged = true;
        }
    }

    void DisableFire()
    {
        Fire.SetActive(false);
        transform.rotation = DefaultRot;
    }
}
