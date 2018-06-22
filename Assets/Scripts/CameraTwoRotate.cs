using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTwoRotate : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 newRotate;
    private Vector3 curRot;

    void Start()
    {
        myTransform = transform;
        curRot = Input.acceleration;
    }

    private void FixedUpdate()
    {
        // за допомогою акселератора здійснюємо керування кораблем у режимі без VR
        newRotate = new Vector3(-(Input.acceleration.z - curRot.z) * 150, (Input.acceleration.x - curRot.x) * 150, 0);

        myTransform.rotation = Quaternion.Lerp(myTransform.rotation, Quaternion.Euler(newRotate), Time.deltaTime);
    }
}
