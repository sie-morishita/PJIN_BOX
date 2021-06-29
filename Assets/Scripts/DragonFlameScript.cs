using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFlameScript : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                other.gameObject.GetComponent<PlayerScript>().isDamaged = true;
                break;
        }
    }
}
