using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectMoveByDrag : MonoBehaviour
{
    [SerializeField] List<GameObject> particleVFXs;

    private Vector3 startPos;
    private Transform target;

    private void OnEnable()
    {
        startPos = transform.position;
    }

    public void PickUp()
    {
        //transform.rotation = new Quaternion(0,0,0,0);
    }

    public void CheckOnMouseUp()
    {
        //transform.position = startPos;
        if (target)
        {
            target.GetComponent<Hole>().Show();
            if (transform.parent.childCount == 1)
            {
                transform.parent.GetComponent<Rigidbody2D>().isKinematic = false;
                GameManager.Instance.CheckLevelUp();
            }
            Destroy(gameObject);
            GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
            Destroy(explosion, .75f);
        }
        else
        {
            transform.position = startPos;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Hole>())
        {
            target = collision.transform;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Hole>())
        {
            target = null;
        }
    }
}
