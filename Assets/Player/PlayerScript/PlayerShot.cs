using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameManager gameManagerScript;
    public PlayerModels playerModelsScript;
    public PlayerStatus playerStatus;
    private EnergyManager energyManagerScript;
    public GameObject energyManager;
    private OperationTutorialManager operationTutorialManagerScript;
    public GameObject operationTutorialManager;

    public GameObject bullet;
    public GameObject machineGun;
    public GameObject Lazer;
    public GameObject Lazer_R;
    public GameObject Lazer_L;
    public GameObject PenetrationBullet;
    public GameObject DamegeRing;

    public float[] bulletTimer;
    public bool singleShotChenge;
    public bool lazerShotChenge;
    public bool penetrationShotChenge;
    public bool isLaserPoweredUp;
    public bool isSinglePoweredUp;
    public bool isPenetrationPoweredUp;

    void Start()
    {
        bulletTimer = new float[3];
        energyManagerScript = energyManager.GetComponent<EnergyManager>();
        operationTutorialManagerScript = operationTutorialManager.GetComponent<OperationTutorialManager>();
    }

    public void UpdateShotPattern()
    {
        int energy = energyManagerScript.GetBatteryEnergy();
        // エナジーに応じてショットパターンを更新
        lazerShotChenge = energy >= 35;
        if (lazerShotChenge && !isLaserPoweredUp)
        {
            isLaserPoweredUp = true;
            playerStatus.isLaserPoweredUp = true;
        }

        singleShotChenge = energy >= 32;
        if (singleShotChenge && !isSinglePoweredUp)
        {
            isSinglePoweredUp = true;
            playerStatus.isSinglePoweredUp = true;
        }

        penetrationShotChenge = energy >= 38;
        if (penetrationShotChenge && !isPenetrationPoweredUp)
        {
            isPenetrationPoweredUp = true;
            playerStatus.isPenetrationPoweredUp = true;
        }
    }
    public void HandleFixedUpdate()
    {
        //
        if (!operationTutorialManagerScript.IsOperationTutorial()&&!gameManagerScript.IsGameStart()) return;
        // ショットパターン
        int index = playerModelsScript.IsIndex();

        if (index == 0)
        {
            HandleSingleShot();
        }
        else if (index == 1)
        {
            Lazer.SetActive(true);
            Lazer_R.SetActive(playerStatus.IsLaserPoweredUp());
            Lazer_L.SetActive(playerStatus.IsLaserPoweredUp());
        }
        else
        {
            Lazer.SetActive(false);
            Lazer_R.SetActive(false);
            Lazer_L.SetActive(false);
        }

        if (index == 2)
        {
            HandlePenetrationShot();
        }
    }
    //単発
    private void HandleSingleShot()
    {
        if (bulletTimer[0] == 0.0f)
        {
            Vector3 position = transform.position + new Vector3(0, 0.3f, 1.6f);
            Instantiate(bullet, position, Quaternion.identity);
            bulletTimer[0] = 1.0f;
        }
        else if (++bulletTimer[0] > 15.0f)
        {
            bulletTimer[0] = 0.0f;
        }

        if (bulletTimer[1] == 0.0f && singleShotChenge)
        {
            Vector3 positionR = transform.position + new Vector3(2.0f, 0.3f, 0f);
            Vector3 positionL = transform.position + new Vector3(-2.0f, 0.3f, 0f);
            Instantiate(machineGun, positionR, Quaternion.identity);
            Instantiate(machineGun, positionL, Quaternion.identity);
            bulletTimer[1] = 1.0f;
        }
        else if (++bulletTimer[1] > 5.0f)
        {
            bulletTimer[1] = 0.0f;
        }
    }
    //貫通弾
    private void HandlePenetrationShot()
    {
        if (bulletTimer[0] == 0.0f)
        {
            Vector3 position = transform.position + new Vector3(0, 0.3f, 1.6f);
            Instantiate(PenetrationBullet, position, Quaternion.identity);
            if (playerStatus.IsPenetrationPoweredUp())
            {
                // 左右からも発射
                Vector3 positionR = transform.position + new Vector3(2.0f, 0.3f, 1.6f);
                Vector3 positionL = transform.position + new Vector3(-2.0f, 0.3f, 1.6f);
                Instantiate(PenetrationBullet, positionR, Quaternion.identity);
                Instantiate(PenetrationBullet, positionL, Quaternion.identity);
            }
            bulletTimer[0] = 1.0f;
        }
        else if (++bulletTimer[0] > 20.0f)
        {
            bulletTimer[0] = 0.0f;
        }

        DamegeRing.SetActive(playerStatus.IsPenetrationPoweredUp());
    }
}