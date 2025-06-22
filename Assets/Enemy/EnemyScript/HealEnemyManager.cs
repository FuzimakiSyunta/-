using UnityEngine;

[RequireComponent(typeof(EnemyReference))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyHPController))]
[RequireComponent(typeof(EnemyDamageHandler))]
[RequireComponent(typeof(EnemyShooter))]

public class HealEnemyManager : MonoBehaviour
{
    //参照
    private EnemyReference reference;
    private EnemyMovement movement;
    private EnemyHPController hpController;
    private EnemyDamageHandler damageHandler;
    private EnemyShooter shooter;

    //エネルギー管理スクリプト
    private HealEnergyManager healEnergyManagerScript;

    void Awake()
    {
        reference = GetComponent<EnemyReference>();
        movement = GetComponent<EnemyMovement>();
        hpController = GetComponent<EnemyHPController>();
        damageHandler = GetComponent<EnemyDamageHandler>();
        shooter = GetComponent<EnemyShooter>();
        if (healEnergyManagerScript == null)
        {
            healEnergyManagerScript = FindObjectOfType<HealEnergyManager>();
            if (healEnergyManagerScript == null)
            {
                Debug.LogError("HealEnergyManager script not found in the scene.");
            }
        }
    }

    void Update()
    {
        if (hpController.IsDead())
        {
            ParticleSystem newParticle = Instantiate(reference.particle);
            newParticle.transform.position = transform.position;
            newParticle.Play();
            Destroy(newParticle.gameObject, 0.5f);
            reference.energyManagerScript.BatteryEnergyUp();
            if (healEnergyManagerScript != null)
            {
                healEnergyManagerScript.HealBatteryEnergyUp();
            }
            else
            {
                Debug.LogWarning("healEnergyManagerScript is null");
            }
            Destroy(gameObject);
        }
    }
}
