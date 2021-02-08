using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool isMove;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (isMove)
        {
            transform.position += transform.forward * 0.03f;
        }
    }
}
