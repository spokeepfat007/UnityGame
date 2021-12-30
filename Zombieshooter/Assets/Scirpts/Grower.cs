using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grower : MonoBehaviour
{
    public void Generated(int[] arr)
        
    {
        var scale = this.transform.GetChild(0).transform.localScale.y;
        this.transform.position += this.transform.up* scale * this.transform.localScale.y;
    }
}
