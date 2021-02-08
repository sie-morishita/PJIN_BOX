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
}
