using ArionDigital;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public enum PlayerMove { Default, MoveLeft, MoveRight }

    public PlayerMove playerMove;

    PlayerScript player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    public void onBoxClick()
    {
        // プレイヤーの移動を開始する
        switch (playerMove)
        {
            case PlayerMove.MoveLeft:
                PlayerMoveLeft();
                break;
            case PlayerMove.MoveRight:
                PlayerMoveRight();
                break;
        }

        // 子オブジェクト（箱）を全て破壊
        foreach (Transform unit in transform)
        {
            unit.gameObject.GetComponent<CrashCrate>().Crash();
        }

        // 破片が残るので消滅させる
        Destroy(gameObject, 1.0f);
    }

    // 初期配置で右に移動させる場合に使う
    void PlayerMoveRight()
    {
        if (!player.isMove)
        {
            player.MoveRight();
        }
    }

    // 初期配置で左に移動させる場合に使う
    void PlayerMoveLeft()
    {
        if (!player.isMove)
        {
            player.MoveLeft();
        }
    }
}