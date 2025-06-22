using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    //gamemanager
    private GameManager gameManagerScript;
    public GameObject gameManager;
    //wave
    private WaveManager waveManagerScript;
    public GameObject waveManager;
    //OperationTutorial
    private OperationTutorialManager operationTutorialManagerScript;
    public GameObject operationTutorialManager;

    //Enemy
    public GameObject attackEnemy;
    public GameObject meteoriteEnemy;
    public GameObject healPlaneEnemy;
    public GameObject hoverCarEnemy;
    public GameObject FinalAttackPlaneEnemy;

    //敵出現
    private int currentPatternIndex = 0;
    private float spawnTimer = 0.0f;
    private float spawnCooldown = 2.0f; // 2秒ごとに敵を出現

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
        waveManagerScript = waveManager.GetComponent<WaveManager>();
        operationTutorialManagerScript = operationTutorialManager.GetComponent<OperationTutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 5種類の敵配置パターン
    private Vector3[][] enemyPatterns = new Vector3[][]
    {
    new Vector3[] { new Vector3(-8.0f, 1.5f, 45.0f), new Vector3(0.0f, 1.5f, 45.0f), new Vector3(8.0f, 1.5f, 45.0f) },
    new Vector3[] { new Vector3(-4.0f, 1.5f, 45.0f), new Vector3(4.0f, 1.5f, 45.0f), new Vector3(0.0f, 1.5f, 45.0f) },
    new Vector3[] { new Vector3(-8.0f, 1.5f, 45.0f), new Vector3(8.0f, 1.5f, 45.0f), new Vector3(0.0f, 1.5f, 45.0f) },
    new Vector3[] { new Vector3(-8.0f, 1.5f, 45.0f), new Vector3(-4.0f, 1.5f, 45.0f), new Vector3(4.0f, 1.5f, 45.0f) },
    new Vector3[] { new Vector3(-4.0f, 1.5f, 45.0f), new Vector3(8.0f, 1.5f, 45.0f), new Vector3(0.0f, 1.5f, 45.0f) }
    };

    private void FixedUpdate()
    {
        if (gameManagerScript.IsGameOver() || gameManagerScript.IsGameClear()) return;

        if (gameManagerScript.IsGameStart()&&!operationTutorialManagerScript.IsOperationTutorial()&& waveManagerScript.IsWave()<=3)
        {
            // WAVEの値に応じてスポーンクールタイムを変更
            int currentWave = waveManagerScript.IsWave();
            if (currentWave >= 1)
            {
                spawnCooldown = 1.0f; // WAVE 2 以降は 1秒
            }
            else if (currentWave >= 2)
            {
                spawnCooldown = 1.5f; // WAVE 1 は 1.5秒
            }
            else
            {
                spawnCooldown = 2.0f; // それ以外は 2秒
            }

            spawnTimer += Time.deltaTime;// タイマーを更新

            // 2秒ごとに敵を出現
            if (spawnTimer >= spawnCooldown)
            {
                currentPatternIndex = Random.Range(0, enemyPatterns.Length);
                spawnTimer = 0.0f; // リセット

                // 敵の種類を決定
                List<GameObject> enemyTypes = new List<GameObject> { attackEnemy, meteoriteEnemy, healPlaneEnemy };

                if (waveManagerScript.IsWave() >= 1) enemyTypes.Add(hoverCarEnemy);
                if (waveManagerScript.IsWave() >= 2) enemyTypes.Add(FinalAttackPlaneEnemy);

                // ランダムな種類の敵を出現
                foreach (var pos in enemyPatterns[currentPatternIndex])
                {
                    int randomEnemyIndex = Random.Range(0, enemyTypes.Count);
                    GameObject newEnemy = Instantiate(enemyTypes[randomEnemyIndex], pos, Quaternion.identity);

                    // `attackEnemy` のみ y 座標を 8 に変更
                    if (enemyTypes[randomEnemyIndex] == attackEnemy)
                    {
                        newEnemy.transform.position = new Vector3(pos.x, 8.0f, pos.z);
                    }
                    // `meteorite` のみ y 座標を 3 に変更
                    if (enemyTypes[randomEnemyIndex] == meteoriteEnemy)
                    {
                        newEnemy.transform.position = new Vector3(pos.x, 3.0f, pos.z);
                    }
                    // `FinalAttackPlaneEnemy` のみ y 座標を 3 に変更
                    if (enemyTypes[randomEnemyIndex] == FinalAttackPlaneEnemy)
                    {
                        newEnemy.transform.position = new Vector3(pos.x, 5.5f, pos.z);
                    }
                }
            }
        }
    }
}
