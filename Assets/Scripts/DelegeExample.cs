using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegeExample : MonoBehaviour
{
    public delegate void ExampleDelege();
    public ExampleDelege exampleDelege;

    private void Start()
    {
        exampleDelege = UpdateHoverText;




    }
    private void Update()
    {
        exampleDelege?.Invoke();
    }

    private void UpdateHoverText() 
    {
        Debug.Log("deneme");
    }
}
