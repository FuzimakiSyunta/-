
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public int batteryEnergy = 0;

    private GameManager gameManagerScript;
    public GameObject gameManager;

    void Start()
    {
        gameManagerScript = GetComponent<GameManager>();
        if (gameManager != null)
        {
            gameManagerScript = gameManager.GetComponent<GameManager>();
        }
    }

    void Update()
    {
        if (batteryEnergy <= 0)
        {
            batteryEnergy = 0;
        }
    }

    public void BatteryEnergyUp()
    {
        batteryEnergy += 1;
    }

    public void BatteryEnergyDown()
    {
        batteryEnergy -= 2;
    }

    public void ResetBattery()
    {
        batteryEnergy = 0;
    }

    public int GetBatteryEnergy()
    {
        return batteryEnergy;
    }
    //バッテリー消費
    public void ReduceBatteryEnergy()
    {
        batteryEnergy -= 30;
    }
    //バッテリー加算
    public void AddBatteryEnergy()
    {
        batteryEnergy = 30;
    }
}
