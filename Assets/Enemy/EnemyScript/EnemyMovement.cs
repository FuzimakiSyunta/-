using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float backMoveSpeed = -27.0f;

    private GameManager gameManagerScript;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        float move = moveSpeed * Time.deltaTime;
        float backMove = backMoveSpeed * Time.deltaTime;

        if (gameManagerScript.IsGameStart())
        {
            Vector3 velocity = new Vector3(0, 0, backMove);
            transform.position += transform.rotation * velocity;
        }

        transform.position += new Vector3(0, 0, move);
    }

    public float Speed() => moveSpeed * Time.deltaTime;
    public float BackSpeed() => backMoveSpeed * Time.deltaTime;
}
