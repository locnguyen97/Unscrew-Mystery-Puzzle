using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RamdomRot : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(new Vector3(0,0,Random.Range(0,360)));
    }
}
