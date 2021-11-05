using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{

    public GameBehaviorScript gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviorScript>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Marble"))
        {
            Destroy(gameObject);
            gameManager.GoalsCollected += 1;
        }
    }
}