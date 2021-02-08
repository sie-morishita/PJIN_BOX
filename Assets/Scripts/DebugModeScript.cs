using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugModeScript : MonoBehaviour
{
    // デバッグ用のリトライボタンが押されたとき
    public void OnRetryButtonClick()
    {
        StageControllerScript.isGameOver = true;
    }

    // デバッグ用のクリアーボタンが押されたとき
    public void OnClearButtonClick()
    {
        StageControllerScript.isClear = true;
    }
}