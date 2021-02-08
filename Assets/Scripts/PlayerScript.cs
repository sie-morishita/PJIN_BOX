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

    private void OnCollisionStay(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                if (isMove) turn();
                break;
        }
    }

    // プレイヤーの向きを反転
    public void turn()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    // プレイヤーを左に向ける
    public void TurnLeft()
    {
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    // プレイヤーを右に向ける
    public void TurnRight()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // 左に走る
    public void MoveLeft()
    {
        TurnLeft();
        isMove = true;
    }

    // 右に走る
    public void MoveRight()
    {
        TurnRight();
        isMove = true;
    }
}
