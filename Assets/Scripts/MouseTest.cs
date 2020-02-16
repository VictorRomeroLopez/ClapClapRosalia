using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour
{

    private void Start()
    {
        InputManager.Instance.SlideRight += OnSlideRight;
        InputManager.Instance.SlideLeft += OnSlideLeft;
    }

    private void OnSlideRight()
    {
        Debug.Log("Right");
    }

    private void OnSlideLeft()
    {
        Debug.Log("Left");
    }

    public void Print()
    {
        Debug.Log("hola");
    }
}
