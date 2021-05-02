using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public enum PlayerAction { Default, TurnLeft, TurnRight }

    public PlayerAction playerAction;

    private void OnCollisionEnter(Collision other)
    {
        // defaultなら何もしない
        if (playerAction == PlayerAction.Default) {
            return;
        }

        if (other.transform.tag == "Player") {
            PlayerScript player = other.gameObject.GetComponent<PlayerScript>();

            // プレイヤーの移動を開始する
            switch (playerAction)
            {
                case PlayerAction.TurnLeft:
                    player.TurnLeft();
                    break;
                case PlayerAction.TurnRight:
                    player.TurnRight();
                    break;
            }
        }
    }
}
