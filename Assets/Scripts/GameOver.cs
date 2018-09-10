using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Image stars;

    public float scoreFillVelocity;
    public float finalScore;
    private float score;

    public Ball ball;
    public Platform platform;

    private void Start()
    {
        finalScore = 0;
        score = 0;
        Hide();
    }

    void Update () {
        if (gameObject.activeSelf && score < finalScore)
        {
            score += finalScore * scoreFillVelocity;
            stars.fillAmount = score;
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        platform.enabled = false;
        ball.DestroyGameObject();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
