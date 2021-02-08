using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageControllerScript : MonoBehaviour
{
    public const string GAME_SCENE_NAME = "GameScene"; // シーン名のプレフィクス
    public const int GAME_SCENE_COUNT = 1;             // シーンの数

    private int stageNum;　　　 // 現在のステージ数
    public Text stageName;      // 現在のステージ名（"Stage" + stageNum）

    public static bool isClear;　　　// クリアフラグ
    public static bool isGameOver;   // ゲームオーバーフラグ

    public GameObject clearCanvas;   // クリア時のUI
    public GameObject retryCanvas;   // ゲームオーバー時のUI

    // デバッグ用
    private bool isDebug = true;     // デバッグフラグ
    public GameObject debugCanvas;   // デバッグメニューのUI

    void Start()
    {
        // ステージ数（画面表示用　※実際のシーン名とは必ずしも対応しない！）
        stageNum = PlayerPrefs.GetInt("StageNum", 1);
        stageName.text = "Stage" + stageNum;

        // 自分のシーンではない場合、ロードし直す
        if (GetLoadSceneName() != SceneManager.GetActiveScene().name)
        {
            LoadScene();
        }

        // 初期化
        isClear = false;
        isGameOver = false;

        // デバッグモード表示の切り替え
        debugCanvas.SetActive(isDebug);
    }

    void Update()
    {
        // クリアしたとき
        if (isClear)
        {
            ShowClearCanvas();
            enabled = false;
        }
        // ゲームオーバーのとき
        else if (isGameOver)
        {
            ShowRetryCanvas();
            enabled = false;
        }
    }

    // クリアUIを表示する
    private void ShowClearCanvas()
    {
        clearCanvas.SetActive(true);
    }

    // リトライUIを表示する
    private void ShowRetryCanvas()
    {
        retryCanvas.SetActive(true);
    }

    // ロードするシーン名を取得
    private string GetLoadSceneName()
    {
        int loadSceneNum = PlayerPrefs.GetInt("SceneNum", 1);
        return GAME_SCENE_NAME + loadSceneNum;
    }

    // ステージを読み込む処理（現在のstageNumに対応するステージ）
    private void LoadScene()
    {
        SceneManager.LoadScene(GetLoadSceneName());
    }
}