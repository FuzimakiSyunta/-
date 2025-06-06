using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEnargyManager : MonoBehaviour
{
    public int healBatteryEnergy = 0;
    public int healcount = 5;

    private GameManager gameManagerScript;

    void Start()
    {
        gameManagerScript = GetComponent<GameManager>();
    }

    void Update()
    {
        HwalManager();
    }

    void HwalManager()
    {
        if (healcount <= 0)
        {
            HealBatteryEnargyReset();
        }
    }

    public void HealBatteryEnargyReset()
    {
        healBatteryEnergy = 0;
    }

    public void HealBatteryEnargyUp()
    {
        healBatteryEnergy += 1;
    }

    public int GetHealBatteryEnargy()
    {
        return healBatteryEnergy;
    }

    public void HealCounter()
    {
        healcount -= 1;
    }

    public int HealCount()
    {
        return healcount;
    }
}
