using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public GameObject blockParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ParticleSystem particleSystem = ShowParticle();
        Destroy(gameObject, (particleSystem.main.duration/2)); //Defino um tempo para deixar a destruição mais suave
        MyGameManager.destructedBlocksCount++;
    }

    private ParticleSystem ShowParticle()
    {
        SpriteRenderer thisObjectSprite = gameObject.transform.GetComponent<SpriteRenderer>();
        Vector3 position = gameObject.transform.position;
        position += new Vector3(thisObjectSprite.bounds.extents.x, -thisObjectSprite.bounds.extents.y);

        GameObject particle = Instantiate<GameObject>(blockParticles, position, Quaternion.identity);
        ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
        float waitTime = particleSystem.main.duration + particleSystem.main.startLifetime.constant;
        DestroyGameObject(waitTime);

        return particleSystem;
    }

    public void DestroyGameObject()
    {
        DestroyGameObject(0);
    }

    public void DestroyGameObject(float waitTime)
    {
        Destroy(gameObject, waitTime);
    }
}
