using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public void Show()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
