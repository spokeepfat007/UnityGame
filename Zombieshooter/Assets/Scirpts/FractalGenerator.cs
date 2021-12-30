using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalGenerator : MonoBehaviour
{
    public int NRecurse = 5;
    public int splitNumber = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        NRecurse -= 1;
        for (int j = 0; j < splitNumber; j++)
        {
            for (int i = 0; i < splitNumber; i++)
            {
                if (NRecurse > 0)
                {

                    var copy = Instantiate(gameObject);
                    var recursive = copy.GetComponent<FractalGenerator>();
                    var arr = new int[2];
                    arr[0]= i;
                    arr[1] = j;
                    recursive.SendMessage("Generated", arr);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
