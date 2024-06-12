using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _force = 10f; // Fixed the variable declaration
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //var force1 = Vector3.forward * _force;
            var force = transform.forward * _force; // Corrected the force declaration
            _rb.AddForce(force, ForceMode.VelocityChange);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("player collided with " + other.gameObject.name);
        Debug.Log("player collided with force " + other.impulse);
        Debug.Log("player collided with relative velocity " + other.relativeVelocity);

    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Destroy(other.gameObject, 1f);
    }
}

