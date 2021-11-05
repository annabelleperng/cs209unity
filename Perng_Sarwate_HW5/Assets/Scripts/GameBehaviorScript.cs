using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviorScript : MonoBehaviour
{
    public string labelText = "The marble's current health is: 100";
    public string goalsLabel = "Goals Collected: 0";
    public string goalsLeft = "Goals Left: 4";

    public bool showWinScreen = false;
    public bool showLoseScreen = false;

    private float _playerHealth = 100f;
    private int _goalsCollected = 0;
    private int _totalGoals = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_playerHealth);
        Debug.Log(_goalsCollected);
    }

    public float PlayerHealth {
        get {
            return _playerHealth;
        }

        set {
            _playerHealth = value;

            labelText = "The marble's current health is: " + _playerHealth;
            if (_playerHealth == 0)
            {
                showLoseScreen = true;
                Time.timeScale = 0f;
            }
        }
    }


    public int GoalsCollected {
        get {
            return _goalsCollected;
        }

        set {
            _goalsCollected = value;

            goalsLabel = "Goals Collected: " + _goalsCollected;
            goalsLeft = "Goals Left: " + (_totalGoals - _goalsCollected);
            if (_goalsCollected == _totalGoals)
            {
                showWinScreen = true;
                Time.timeScale = 0f;
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHealth);
        GUI.Box(new Rect(20, 50, 150, 25), "Goals Collected: " + _goalsCollected);
        GUI.Box(new Rect(20, 80, 150, 25), "Goals Left: " + (_totalGoals - _goalsCollected));

        if (showWinScreen && !showLoseScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "YOU WIN!\nClick here to restart"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        } else if (showLoseScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "YOU LOSE."))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
    }
}
