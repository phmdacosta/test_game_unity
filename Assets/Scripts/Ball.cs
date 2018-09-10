using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 direction;
    public float velocity;

	// Use this for initialization
	void Start () {
        direction.Normalize(); // Equivalente a direction = direction.normalized;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += direction * velocity * Time.deltaTime;
	}

    // Função chamada quando este elemento colidir com outro
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        EdgeGenerator edgeGenerator = collision.transform.GetComponent<EdgeGenerator>();
        if (edgeGenerator != null && normal == Vector2.up)
        {
            MyGameManager.instancia.GameOver();
        }
        direction = Vector2.Reflect(direction, normal);
        direction.Normalize();
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
