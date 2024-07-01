using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnObstacle : NetworkBehaviour
{
    [SerializeField] private float spawnInterval = 1.0f;
    [SerializeField] private float radius = 20f;
    private float _timer;

    private void Update()
    {
        // _timer += Time.deltaTime;
        // if (_timer > spawnInterval)
        // {
        //     _timer = 0f;
        //     Spawn();
        // }
    }

    public void Spawn()
    {
        if (!ObjectPool.Instance.CanSpawn()) return;
        var obj = ObjectPool.Instance.PickOne(transform);
        var pos = Random.insideUnitSphere * radius;
        pos.y = Mathf.Abs(pos.y);
        obj.transform.position = pos;
        obj.SetActive(true);
        NetworkServer.Spawn(obj);
    }
}
