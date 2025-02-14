using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            ParticleSystem newParticle = Instantiate(particle);
            //�ꏊ�Œ�
            newParticle.transform.position = this.gameObject.transform.position;
            //����
            newParticle.Play();

            Destroy(newParticle.gameObject,0.5f);
        }
    }
}
