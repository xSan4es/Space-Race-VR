using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGo : MonoBehaviour
{
    private Transform myTransform;
    private float speed;
    private int record;
    private int circle = 0;
    private float curr_time;

    void Start ()
    {
        curr_time = PlayerPrefs.GetFloat("time_in_game");
        myTransform = transform;
        speed = 5;
    }
	
	void Update ()
    {
        curr_time += Time.fixedDeltaTime;

        myTransform.position += myTransform.forward * Time.deltaTime * speed; //рух у напрямку погляду
        record = (int)myTransform.position.z;

        if (myTransform.position.z > 100) // прискорення 
        {
            myTransform.position -= new Vector3(0, 0, 100);
            speed += speed/3;
            circle++;
        }
        
        if ((Mathf.Abs(myTransform.position.x) * Mathf.Abs(myTransform.position.x) + Mathf.Abs(myTransform.position.y) 
            * Mathf.Abs(myTransform.position.y)) > Mathf.Abs(0.81f)) // смерть при виході із зони гри
        {
            myTransform.GetChild(0).GetComponent<Player>().die();
        }
    }

    public int getRecord()
    {
        return circle * 100 + record;
    }

    public void died()
    {
        PlayerPrefs.SetFloat("time_in_game", curr_time);
        gameObject.SetActive(false);
    }
}
