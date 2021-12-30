using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZombieCounter : MonoBehaviour
{
    int Count = 0;
    Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddKill()
    {
        Count = Count + 1;
        text.text = $"{Count}";
    }
}
