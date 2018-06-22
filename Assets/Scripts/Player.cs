using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool check;
    public Text ScoreLabel;
    public GameObject menu;
    public GameObject gm2;
    public GameObject gm1;

    void Start()
    {
        check = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Finish")) // якщо це астероїд
        {
            die();
        }
    }

    public void die()
    {
        if(check)
        {
            //якщо був отриманий новий рекорд, записуємо його
            int record = transform.GetComponentInParent<CameraGo>().getRecord();

            if (!PlayerPrefs.HasKey("Record"))
            {
                PlayerPrefs.SetInt("Record", record);
            }

            if (PlayerPrefs.GetInt("Record") < record)
                PlayerPrefs.SetInt("Record", record);


            //перехід на сцену після смерті
            transform.GetComponentInParent<CameraGo>().died();
            ScoreLabel.text = "Your score: " + record.ToString() + " km\nRecord: " + PlayerPrefs.GetInt("Record").ToString() + " km";
            menu.SetActive(true);

            if (PlayerPrefs.GetInt("Camera") == 0) { gm2.SetActive(true); }

            else if (PlayerPrefs.GetInt("Camera") == 1) { gm1.SetActive(true); }

            check = false;
        }
    }
}
