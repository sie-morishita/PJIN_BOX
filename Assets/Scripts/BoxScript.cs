using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public void onBoxClick()
    {
        Destroy(gameObject);
    }
}
