using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEnargyManager : MonoBehaviour
{
    //回復エネルギーの管理
    public int healBatteryEnergy = 0;
    public int healcount = 5;

    private GameManager gameManagerScript;

    void Start()
    {
        gameManagerScript = GetComponent<GameManager>();
        healBatteryEnergy = 0;
        healcount = 5; // 初期回復カウントを設定
    }

    void Update()
    {
        HealManager();
    }

    void HealManager()
    {
        if (healBatteryEnergy >= 9)
        {
            healBatteryEnergy = 9;
        }
    }
    public void HealBatteryEnargyReset()
    {
        healBatteryEnergy = 0;
    }

    public void HealBatteryEnergyUp()
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
