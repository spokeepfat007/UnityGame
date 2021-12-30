using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cartridges : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    int NumOfCart = 7;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int Shot()
    {
        NumOfCart -= 1;
        text.text = $"{NumOfCart}";
        return NumOfCart;
    }
    public int Recharge()
    {
        NumOfCart = 7;
        text.text = $"{NumOfCart}";
        return NumOfCart;
    }
}
