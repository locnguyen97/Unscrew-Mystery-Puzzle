using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class TouchPoint : MonoBehaviour
{
    private bool isSelected = false;
    [SerializeField] List<GameObject> particleVFXs;
    private Vector3 startPos;
    public int id = 0;

    private void OnEnable()
    {
        startPos = transform.position;
    }

    public void Move()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
        StartCoroutine(Move(new Vector3(transform.position.x,-2000) ));
    }

    public void Scale()
    {
        transform.DOScale(Vector3.one * 1.15f, 0.15f).OnComplete(() => { transform.DOScale(Vector3.one, 0.15f).OnComplete(
            () =>
            {
                GameManager.Instance.EnableDrag(false);
            }); });
    }

    IEnumerator Move(Vector3 target)
    {
        yield return new WaitForSeconds(1.25f);
        GameManager.Instance.EnableDrag(true);
        GameManager.Instance.GetCurLevel().RemoveObject(gameObject);
    }
}