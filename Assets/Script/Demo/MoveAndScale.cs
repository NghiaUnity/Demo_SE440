using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoveAndScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(endValue: Vector3.one * 3, duration: 2f)
        .SetLoops(5, LoopType.Yoyo)
        .SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            Debug.Log("Move Done");
        });
        transform.DOScale(Vector3.one * 2, 1f)
        .SetLoops(-1, LoopType.Yoyo)
        .SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {

    }
}