using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public float Period;
    public GameObject helper;
    private float TimeUntilNextSpawn;
    // Start is called before the first frame update
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
            var x = Random.Range(0, 228);
            var z = Random.Range(0, 223);
            var pos = new Vector3(x, 0, -z);
            Instantiate(helper, pos, transform.rotation);
        }
    }
}
