using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    public GameManager gameManagerScript;
    public PlayerImageUI uiController;
    public PlayerStatus playerStatus;
    private HealEnergyManager healEnergyManagerScript;
    public GameObject healEnergyManager;
    private PlayerStatus playerStatusScript;
    public GameObject playerStatusObject;

    //プレイヤーの最大HP
    private const int MaxHealHp = 300;
    //回復量
    private const int HealAmount = 150;
    //回復エフェクト
    public AudioClip healSound;
    public ParticleSystem healEffect;
    // プレイヤーのAudioSource
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        healEnergyManagerScript = healEnergyManager.GetComponent<HealEnergyManager>();
        playerStatusScript = playerStatusObject.GetComponent<PlayerStatus>();
    }

    public void Heal()
    {
        //まだ回復できない
        if (healEnergyManagerScript.GetHealBatteryEnergy() < 9)
            playerStatus.isHeal = false;
        
        if (healEnergyManagerScript.GetHealBatteryEnergy() < 9 && playerStatus.isHeal == false)
        {
            uiController.SetHealImage(false);
        }
        //回復できる
        if (healEnergyManagerScript.GetHealBatteryEnergy() >= 9 && playerStatus.isHeal == false && playerStatus.GetHp() < MaxHealHp)
        {
            uiController.SetHealImage(true);

            if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown("joystick button 2")||playerStatus.GetHp() <= 150)
            {
                playerStatus.IncreaseHp(HealAmount);
                playerStatus.isHeal = true;
                uiController.SetHealImage(false);
                healEnergyManagerScript.HealBatteryEnergyReset();
                healEnergyManagerScript.HealCounter();
            }
        }
    }
}