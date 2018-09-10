using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public float movementVelocity;
    public float xAxisLimit;
    public GameObject platformParticle;

    // Use this for initialization
    void Start () {
        // Definindo o limite de movimentação da plataforma em X, subtraindo da metade de seu tamanho
        xAxisLimit = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, 0, 0)).x - GetComponent<SpriteRenderer>().bounds.extents.x; // bounds.extends = bounds.size / 2
        // GetComponent<SpriteRenderer>() pega o componente sprite da plataforma
    }

    // Update is called once per frame
    void Update () {
        float mouseDirection = Input.GetAxis("Mouse X");
        //GetComponent<Transform>().position += Vector3.right * mouseDirection * movementVelocity * Time.deltaTime;
        transform.position += Vector3.right * mouseDirection * movementVelocity * Time.deltaTime;
        /*
         * Dependendo no computador os frames são processados mais rapidamente, executando o método Update mais 
         * vezes do que outras máquinas, fazendo com que o movimento da plataforma seja mais rápida em umas. 
         * O "Time.deltaTime" pega o tempo que o frame demorou para ser processado assim, a velocidade de movimento 
         * da plataforma será compensada pelo tempo de processmento, diminuindo a velocidade em computadores mais rápidos.
         */
        float currentX = transform.position.x;
        currentX = Mathf.Clamp(currentX, -xAxisLimit, xAxisLimit);
        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShowParticle();
    }

    private ParticleSystem ShowParticle()
    {
        GameObject particle = Instantiate<GameObject>(platformParticle, gameObject.transform.position, Quaternion.identity);
        ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
        float lifeTime = particleSystem.main.duration + particleSystem.main.startLifetime.constant;
        Destroy(particle, lifeTime);

        return particleSystem;
    }
}
