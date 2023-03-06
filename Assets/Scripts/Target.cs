using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points; // Puntuación del objeto (positiva para Good, 0 para Bad)
    public GameObject explosionParticle;
    
    private float lifeTime = 2f;

    private GameManager gameManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, lifeTime); // Autodestrucción
    }

    private void OnMouseDown()
    {
        if (!gameManager.isGameOver)
        {
            if (gameObject.CompareTag("Bad"))
            {
                if (gameManager.hasPowerupShield)
                {
                    gameManager.hasPowerupShield = false;
                }
                else
                {
                    gameManager.MinusLife();
                }
            }
            
            else if (gameObject.CompareTag("Good"))
            {
                gameManager.UpdateScore(points);
            }
            
            else if (gameObject.CompareTag("Shield"))
            {
                gameManager.hasPowerupShield = true;
            }

            Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.
            Remove(transform.position); // Dejamos libre la posición
    }
}
