using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public float Period;
    public GameObject Enemy;
    private float TimeUntilNextSpawn;
    void Start()
    {
        TimeUntilNextSpawn = Random.Range(0, Period); 
    }

    // Update is called once per frame
    void Update()
    {
        TimeUntilNextSpawn -= Time.deltaTime;
        if (TimeUntilNextSpawn <= -0.0f)
        {
            TimeUntilNextSpawn = Period;
            Instantiate(Enemy, transform.position, transform.rotation);
        }
    }
}
