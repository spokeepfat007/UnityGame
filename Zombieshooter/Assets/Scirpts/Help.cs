using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    float distance;
    bool dead = false;
    void Start()
    {
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
            return;
        GetDistance();
        if (distance < 1)
            kill();


    }
    void GetDistance()
    {
        distance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.z - transform.position.z, 2));
    }
    public void kill()
    {
        if (!dead)
        {
            Destroy(gameObject, 0f);
            dead = true;
            player.AddHealth();
        }
    }

    }
