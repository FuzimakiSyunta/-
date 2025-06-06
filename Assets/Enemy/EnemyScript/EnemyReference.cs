
using UnityEngine;

public class EnemyReference : MonoBehaviour
{
    public GameManager gameManagerScript { get; private set; }
    public EnergyManager energyManagerScript { get; private set; }
    public AudioSource audioSource { get; private set; }

    public ParticleSystem particle;

    void Awake()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        GameObject energyManager = GameObject.Find("EnergyManager");
        energyManagerScript = energyManager.GetComponent<EnergyManager>();

        audioSource = GetComponent<AudioSource>();
    }
}
