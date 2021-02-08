using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Animator charaAnim;

    public bool isMove;

    void Start()
    {
        charaAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isMove)
        {
            transform.position += transform.forward * 0.03f;
        }
    }

    void Update()
    {
        charaAnim.SetBool("isRunning", isMove);
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    switch (collision.gameObject.tag)
    //    {
    //        case "Wall":
    //            if (isMove) turn();
    //            break;
    //    }
    //}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (isMove) turn();
        }
    }

    // プレイヤーの向きを反転
    public void turn()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
