using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public float scalar = 0.5f;
    public void Generated(int[] arr)
    {
        this.transform.localScale *= scalar;
    }
}
