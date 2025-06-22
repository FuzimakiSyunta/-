using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecDemo : MonoBehaviour
{
    //ゲームマネージャ
    public GameObject gameManager;
    private GameManager gameManagerScript;
    //エナジーマネージャ
    public GameObject energyManager;
    private EnergyManager energyManagerScript;
    //ウェーブマネージャ
    private WaveManager waveManagerScript;
    public GameObject waveManager;
    //ヒールエナジーマネージャ
    private HealEnergyManager healEnergyManagerScript;
    public GameObject healEnergyManager;
    //ボスコントローラー
    public GameObject boss;
    private BossController bossController;
    //プレイヤー
    public GameObject player;
    private PlayerStatus playerStatus;

    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
        bossController = boss.GetComponent<BossController>();
        playerStatus = player.GetComponent<PlayerStatus>();
        energyManagerScript = energyManager.GetComponent<EnergyManager>();
        waveManagerScript = waveManager.GetComponent<WaveManager>();
        healEnergyManagerScript = healEnergyManager.GetComponent<HealEnergyManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) energyManagerScript.BatteryEnergyUp();
        if (Input.GetKey(KeyCode.N)) bossController.BossWaveTimeAdd(1f);
        if (Input.GetKeyDown(KeyCode.K)) waveManagerScript.BossWaveCountStart();

        if (Input.GetKeyDown(KeyCode.Alpha0)) playerStatus.DecreaseHp(10);
        if (Input.GetKey(KeyCode.Alpha1)) playerStatus.IncreaseHp(10);
        if (Input.GetKey(KeyCode.Alpha2)) bossController.ReduceHp(100);
        if (Input.GetKey(KeyCode.Alpha3)) bossController.ReduceHp(-100);
        if (Input.GetKeyDown(KeyCode.Alpha4)) healEnergyManagerScript.HealCounter();

        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale += 0.5f;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 10f);
            Debug.Log("TimeScale: " + Time.timeScale);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Time.timeScale -= 0.5f;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 5f);
            Debug.Log("TimeScale: " + Time.timeScale);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Time.timeScale = 1.0f;
            Debug.Log("TimeScale Reset: " + Time.timeScale);
        }
    }
}
