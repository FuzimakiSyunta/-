
using UnityEngine;

[RequireComponent(typeof(EnemyReference))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyHPController))]
[RequireComponent(typeof(EnemyDamageHandler))]
[RequireComponent(typeof(EnemyShooter))]
public class MeteoriteEnemyManager : MonoBehaviour
{
    private EnemyReference reference;
    private EnemyMovement movement;
    private EnemyHPController hpController;
    private EnemyDamageHandler damageHandler;
    private EnemyShooter shooter;

    public ParticleSystem damegeParticle;

    void Awake()
    {
        reference = GetComponent<EnemyReference>();
        movement = GetComponent<EnemyMovement>();
        hpController = GetComponent<EnemyHPController>();
        damageHandler = GetComponent<EnemyDamageHandler>();
        shooter = GetComponent<EnemyShooter>();
    }

    void Update()
    {
        if (hpController.IsDead())
        {
            ParticleSystem newParticle = Instantiate(reference.particle);
            newParticle.transform.position = transform.position;
            newParticle.Play();
            Destroy(newParticle.gameObject, 0.5f);
            reference.energyManagerScript.BatteryEnargyUp();
            Destroy(gameObject);
        }
    }

    public void Damaged()
    {
        ParticleSystem newParticle = Instantiate(damegeParticle);
        newParticle.transform.position = transform.position;
        newParticle.Play();
        Destroy(newParticle.gameObject, 5.0f);
    }
}
