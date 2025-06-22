using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    private GameManager gameManagerScript;
    public GameObject gameManager;
    private Result ResultScript;
    public GameObject result;
    private PauseMenuSelector pauseMenuSelectorScript;
    public GameObject pauseMenuSelector;

    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
        pauseMenuSelectorScript = pauseMenuSelector.GetComponent<PauseMenuSelector>();
        ResultScript = result.GetComponent<Result>();
    }

    void Update()
    {
        // タイトルに戻るとき
        if (pauseMenuSelectorScript.IsTitleBack())
        {
            PlayerPrefs.SetInt("TutorialDone", 1);
            PlayerPrefs.Save();

            SceneManager.LoadScene("Load");
        }

        // ゲームクリア時にスペースキーでシーン切り替え
        if (gameManagerScript.IsGameClear() && ResultScript.IsRankOpen())
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
            {
                PlayerPrefs.SetInt("TutorialDone", 1);
                PlayerPrefs.Save();

                SceneManager.LoadScene("Load");
            }
        }
    }

}
