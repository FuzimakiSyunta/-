
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public int batteryEnergy = 0;

    private GameManager gameManagerScript;

    void Start()
    {
        gameManagerScript = GetComponent<GameManager>();
    }

    void Update()
    {
        if (batteryEnergy <= 0)
        {
            batteryEnergy = 0;
        }
    }

    public void BatteryEnargyUp()
    {
        batteryEnergy += 1;
    }

    public void BatteryEnargyDown()
    {
        batteryEnergy -= 2;
    }

    public int GetBatteryEnargy()
    {
        return batteryEnergy;
    }

    public void ShieldBatteryEnargy()
    {
        batteryEnergy -= 30;
    }
}
