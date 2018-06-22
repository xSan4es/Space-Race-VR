using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControllerSimple : MonoBehaviour 
{
    public GameObject cameraOne;
    public GameObject cameraTwo;
    public AudioSource audio;
    public Toggle toggle;
    public Slider slider;

    public Canvas canvas;
    public Camera camOne;
    public Camera camTwo;

    public void Awake()
    {
        //записуємо початкові дані налаштування
        if (!PlayerPrefs.HasKey("Camera"))
        {
            PlayerPrefs.SetInt("Camera", 1);
        }

        if (PlayerPrefs.GetInt("Camera") == 0) {cameraTwo.SetActive(true); canvas.worldCamera = camTwo; }

        else if (PlayerPrefs.GetInt("Camera") == 1) { cameraOne.SetActive(true); canvas.worldCamera = camOne; }

        bool togglee = false;

        if (PlayerPrefs.GetInt("Toggle") == 0) togglee = false;
        else if (PlayerPrefs.GetInt("Toggle") == 1) togglee = true;

        audio.volume = PlayerPrefs.GetFloat("Slider");
        audio.mute = togglee;

        if (!PlayerPrefs.HasKey("Slider"))
        {
            PlayerPrefs.SetFloat("Slider", 1f);
        }
        slider.value = PlayerPrefs.GetFloat("Slider");

        if (!PlayerPrefs.HasKey("Toggle"))
        {
            PlayerPrefs.SetInt("Toggle", 1);
        }
        if (PlayerPrefs.GetInt("Toggle") == 0) toggle.isOn = false;
        else if (PlayerPrefs.GetInt("Toggle") == 1) toggle.isOn = true;
    }

    public void Changed_Toggle()
    {
        audio.mute = toggle.isOn;
        if (toggle.isOn == false) PlayerPrefs.SetInt("Toggle", 0);
        else if (toggle.isOn == true) PlayerPrefs.SetInt("Toggle", 1);

    }

    public void Changed_Slider()
    {
        audio.volume = slider.value;
        PlayerPrefs.SetFloat("Slider", slider.value);
        PlayerPrefs.Save();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Choise_menu()
    {
        SceneManager.LoadScene("Scene0");
    }
}