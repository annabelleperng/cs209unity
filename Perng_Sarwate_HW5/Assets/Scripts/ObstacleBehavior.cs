using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public float obstacleHealth = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Blast"))
        {
            obstacleHealth -= 10;
            if (obstacleHealth <= 0)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
