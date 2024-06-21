using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class vidu : MonoBehaviour
{
    // Start is called before the first frame update
    // ham lambda
    void Start()
    { //demo lambda
        MoveGameObject(() =>
        {
            Debug.Log("call back");
        });
        //demo multi thread 1
        Debug.Log("start call count down");
        StartCoroutine(CountDown());
        Debug.Log("End call count down");
        //demo multi thread 2
        Multithread02();
    }

    private async void Multithread02()
    {
        Debug.Log("Start multi tasks");
        List<UniTask> tasks = new List<UniTask>();
        tasks.Add(TaskA("Move object", 2000));
        tasks.Add(TaskA("Scale object", 4000));
        await UniTask.WhenAll(tasks);
        Debug.Log("Completed tasks");

    }
    private async UniTask TaskA(string log, int delay)
    {
        Debug.Log($"Task Start {log}");
        await UniTask.Delay(delay);
        Debug.Log($"Task Done {log}");
    }
    private void MoveGameObject(Action callback)
    {
        Debug.Log("Move Game Object completed");
        callback?.Invoke();
    }
    private IEnumerator CountDown()
    {
        Debug.Log("Start Count Down");
        int countTime = 3;
        for (int i = 0; i < countTime; i++)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("End count down");
    }
}