using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleFingerRotator : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, Time.time * 10, 0);
    }
}