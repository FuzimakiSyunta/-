
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    private EnemyHPController hpController;

    void Start()
    {
        hpController = GetComponent<EnemyHPController>();
        if (hpController == null)
        {
            Debug.LogError("EnemyHPController ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ", this);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (hpController == null) return;

        switch (other.gameObject.tag)
        {
            case "Bullet":
                hpController.ApplyDamage(200);
                break;
            case "Machinegun":
                hpController.ApplyDamage(150);
                break;
            case "PenetrationBullet":
                hpController.ApplyDamage(400);
                break;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (hpController == null) return;

        switch (other.gameObject.tag)
        {
            case "PlayerLazer":
                hpController.ApplyDamage(180);
                break;
            case "PlayerLazer_R":
                hpController.ApplyDamage(150);
                break;
            case "PlayerLazer_L":
                hpController.ApplyDamage(150);
                break;
        }
    }
}
