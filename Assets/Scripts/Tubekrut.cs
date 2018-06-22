using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubekrut : MonoBehaviour
{

    private Transform myTransform;
    public Vector3 v;

    void Start()
    {
        myTransform = transform;
    }
    
    void Update ()
    {
        myTransform.Rotate(v); // здійснюємо поворот країв ігрової зони (труби)
    }
}
