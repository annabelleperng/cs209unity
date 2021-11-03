using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviorScript : MonoBehaviour
{
    

    private float _playerHealth = 100f;
    private int _goalsCollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float PlayerHealth {
        get {
            return _playerHealth;
        }

        set {
            _playerHealth = value;
        }
    }


    public int GoalsCollected {
        get {
            return _goalsCollected;
        }

        set {
            _goalsCollected = value;
        }
    }
}
