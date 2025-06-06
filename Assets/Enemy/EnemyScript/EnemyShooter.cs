using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    private float[] bulletTimer = new float[3];
    private GameManager gameManagerScript;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        for (int i = 0; i < bulletTimer.Length; i++)
        {
            bulletTimer[i] = 0.0f;
        }
    }

    void FixedUpdate()
    {
        if (!gameManagerScript.IsGameOver())
        {
            if (bulletTimer[0] == 0.0f)
            {
                Vector3 position = transform.position;
                position.y += 0.3f;
                position.z -= 3.0f;
                Instantiate(enemyBullet, position, Quaternion.identity);
                bulletTimer[0] = 1.0f;
            }
            else
            {
                bulletTimer[0] += Time.deltaTime;
                if (bulletTimer[0] > 2.0f)
                {
                    bulletTimer[0] = 0.0f;
                }
            }
        }
    }
}
