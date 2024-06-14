using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayItems : MonoBehaviour, IRayItem
{

    [SerializeField] Color deActiveColor;
    [SerializeField] Color activeColor;
    [SerializeField] Renderer gameObjectRenderer;


    public void Start()
    {
        //gameObjectRenderer = GetComponent<Renderer>();
        gameObjectRenderer.material.color = deActiveColor;
    }
    public void OnPointerEnter()
    {
        Debug.Log("OnPointerEnter");
        gameObjectRenderer.material.color = activeColor;
    }

    public void OnPointerExit()
    {
        Debug.Log("OnPointerExit");
        gameObjectRenderer.material.color = deActiveColor;
    }

}