using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points;
    public GameObject explosionParticle;
    
    private float lifeTime = 2f;

    private GameManager gameManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, lifeTime);
    }

    private void OnMouseDown()
    {
        if (!gameManager.isGameOver)
        {
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
            
            else if (gameObject.CompareTag("Good"))
            {
                gameManager.UpdateScore(points);
            }

            Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.
            Remove(transform.position);
    }
}
