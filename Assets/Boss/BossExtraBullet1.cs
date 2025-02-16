using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExtraBullet1 : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        float moveSpeedX = 7.0f;
        float moveSpeedZ = 20.0f;
        rb.velocity = new Vector3(-moveSpeedX, 0, -moveSpeedZ);
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -13)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }
}
