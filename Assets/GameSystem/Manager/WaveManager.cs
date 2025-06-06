using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //WAVEŠÖ˜A
    public int Wave;
    public float GamePlayCount;
    private bool BossWaveFlag;

    private const int MaxWave = 4;
    private bool[] waveStarted = new bool[MaxWave];
    private bool[] bossStarted = new bool[MaxWave];
    private float[] waveStartTimes = { 0f, 40f, 80f, 125f };
    private float[] bossStartTimes = { 18f, 58f, -1f, 125f };

    public GameObject SpeedParticle;

    private GameManager gameManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.IsGameStart())
        {
            GamePlayCount += Time.deltaTime;
            SpeedParticle.SetActive(true);

            for (int i = 0; i < MaxWave; i++)
            {
                if (!waveStarted[i] && GamePlayCount >= waveStartTimes[i])
                {
                    Wave = i;
                    BossWaveFlag = false;
                    waveStarted[i] = true;
                    Debug.Log($"Wave {i} Started");
                }

                if (!bossStarted[i] && bossStartTimes[i] > 0 && GamePlayCount >= bossStartTimes[i])
                {
                    BossWaveFlag = true;
                    bossStarted[i] = true;
                    Debug.Log($"Wave {i} Boss Started");
                }
            }
        }
        else
        {
            SpeedParticle.SetActive(false);
        }
    }

    public void BossWaveCountStart()
    {
        GamePlayCount++;
    }

    public int IsWave()
    {
        return Wave;
    }

    public float[] GetBossStartTimes()
    {
        return bossStartTimes;
    }

    public bool IsBossWave()
    {
        return BossWaveFlag;
    }

    public float IsGamePlayCount()
    {
        return GamePlayCount;
    }

}
