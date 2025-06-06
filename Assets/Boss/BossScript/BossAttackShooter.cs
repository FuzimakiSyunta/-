using UnityEngine;

public class BossAttackShooter : MonoBehaviour
{
    [Header("弾Prefab")]
    [SerializeField] private GameObject bossBullet;
    [SerializeField] private GameObject bossBurstBulletL;
    [SerializeField] private GameObject bossBurstBulletR;

    [Header("制御関連")]
    [SerializeField] private Animator animator;
    [SerializeField] private BossController bossController;

    private float multiBulletTimer = 0f;
    private float burstBulletTimer = 0f;
    private float multiBulletCooldown = 0f;
    private float burstBulletCooldown = 0f;

    private OperationTutorialManager operationTutorialManagerScript;
    public GameObject operationTutorialManager;

    private void Start()
    {
        // 操作チュートリアルのスクリプトを取得
        operationTutorialManagerScript = operationTutorialManager.GetComponent<OperationTutorialManager>();
    }

    private void FixedUpdate()
    {
        // 操作チュートリアルが進行中でない場合に弾の発射を処理
        if (operationTutorialManagerScript == null)
        {
            Debug.LogError("OperationTutorialManager script is not assigned.");
            return;
        }
        if (!operationTutorialManagerScript.IsOperationTutorial())
        {
            HandleMultiBullet();
            HandleBurstBullet();
        }
    }

    private void HandleMultiBullet()
    {
        if (multiBulletTimer == 0.0f)
        {
            multiBulletCooldown += Time.deltaTime;
            // 弾の発射条件を確認
            if (!animator.GetBool("isMove") && !animator.GetBool("isLazer") &&
                !animator.GetBool("isRobotStay") && !animator.GetBool("FinalWave") &&
                !bossController.IsFinalBattle())
            {
                if (multiBulletCooldown >= 4.0f)
                {
                    Vector3 pos = transform.position;
                    pos.y += 0.3f;
                    pos.z -= 30.0f;
                    Instantiate(bossBullet, pos, Quaternion.identity);
                    multiBulletTimer = 1.0f;
                }
            }
        }
        else
        {
            multiBulletTimer += Time.deltaTime;
            if (multiBulletTimer > 5.0f)
            {
                multiBulletTimer = 0.0f;
            }
            burstBulletCooldown = 0f;
        }
    }

    private void HandleBurstBullet()
    {
        if (burstBulletTimer == 0.0f)
        {
            burstBulletCooldown += Time.deltaTime;

            if (animator.GetBool("isMove") && !animator.GetBool("isFinalBattle"))
            {
                if (burstBulletCooldown >= 2.5f)
                {
                    Vector3 posR = transform.position;
                    Vector3 posL = transform.position;
                    Instantiate(bossBurstBulletR, posR, Quaternion.identity);
                    Instantiate(bossBurstBulletL, posL, Quaternion.identity);
                    burstBulletTimer = 1.0f;
                }
            }
        }
        else
        {
            burstBulletTimer += Time.deltaTime;
            if (burstBulletTimer > 2.5f)
            {
                burstBulletTimer = 0.0f;
            }
            multiBulletCooldown = 0f;
        }
    }
}
