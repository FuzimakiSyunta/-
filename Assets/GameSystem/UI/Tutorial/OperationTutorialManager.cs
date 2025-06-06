using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationTutorialManager : MonoBehaviour
{
    private GameManager gameManagerScript; // GameManagerのスクリプトを参照するための変数
    public GameObject gameManager; // Inspectorで設定するGameManagerオブジェクト

    public GameObject operationTutorialPanel; // Inspectorで設定する操作チュートリアルパネル

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
