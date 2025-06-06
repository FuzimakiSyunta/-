using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    public GameManager gameManagerScript;
    public PlayerImageUI uiController;
    public PlayerStatus playerStatus;
    private HealEnargyManager healEnargyManagerScript;
    public GameObject healEnargyManager;

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
        healEnargyManagerScript = healEnargyManager.GetComponent<HealEnargyManager>();
    }

    public void Heal()
    {
        //まだ回復できない
        if (healEnargyManagerScript.GetHealBatteryEnargy() < 9)
            playerStatus.isHeal = false;
        
        if (healEnargyManagerScript.GetHealBatteryEnargy() < 9 && playerStatus.isHeal == false)
        {
            uiController.SetHealImage(false);
        }
        //回復できる
        if (healEnargyManagerScript.GetHealBatteryEnargy() >= 9 && playerStatus.isHeal == false && playerStatus.GetHp() < MaxHealHp)
        {
            uiController.SetHealImage(true);

            if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown("joystick button 2"))
            {
                playerStatus.IncreaseHp(HealAmount);
                playerStatus.isHeal = true;
                uiController.SetHealImage(false);
                healEnargyManagerScript.HealBatteryEnargyReset();
                healEnargyManagerScript.HealCounter();
            }
        }
    }
}