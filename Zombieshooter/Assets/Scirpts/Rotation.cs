using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float angle=30f;
    public void Generated(int[] arr)
    {
        this.transform.rotation *= Quaternion.Euler(angle * ((arr[0]*2)-1), 0, angle * ((arr[1] * 2) - 1));
    }
}
