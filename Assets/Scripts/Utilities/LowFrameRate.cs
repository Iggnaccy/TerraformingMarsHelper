using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowFrameRate : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 10;
    }
}
