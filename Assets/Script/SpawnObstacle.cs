using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1.0f;
    [SerializeField] private float radius = 20f;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > spawnInterval)
        {
            _timer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        if (!ObjectPool.Instance.CanSpawn()) return;
        var obj = ObjectPool.Instance.PickOne(transform);
        var pos = Random.insideUnitSphere * radius;
        pos.y = Mathf.Abs(pos.y);
        obj.transform.position = pos;
        obj.SetActive(true);
    }

    private void Return()
    {
        ObjectPool.Instance.ReturnOne(gameObject);
    }
}
