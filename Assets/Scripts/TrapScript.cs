using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerScript>().isDamaged = true;
        }

        if (other.gameObject.tag == "Dragon")
        {
            other.gameObject.GetComponent<DragonScript>().isDamaged = true;
        }
    }
}