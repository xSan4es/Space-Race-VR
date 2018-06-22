using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Button button;
    public Slider slider;
    public Text text;

    private AsyncOperation AsOp;
    private AsyncOperation AsOpM;
    private float loading_progress = 0f;
    private float round_load;
    private int load_lvl;

    public GameObject cameraOne;
    public GameObject cameraTwo;

    public void Awake()
    {
        if (!PlayerPrefs.HasKey("Camera"))
        {
            PlayerPrefs.SetInt("Camera", 1);
        }

        if (PlayerPrefs.GetInt("Camera") == 0) { cameraTwo.SetActive(true); }

        else if (PlayerPrefs.GetInt("Camera") == 1) { cameraOne.SetActive(true); }
    }

    void Start()
    {
        StartCoroutine("loading_lvl");
    }

    IEnumerator loading_lvl()
    {
        AsOp = SceneManager.LoadSceneAsync("OneSceneProject");
        AsOp.allowSceneActivation = false;


        while (AsOp.isDone == false) //загрузка сцени
        {
            loading_progress = AsOp.progress * 100f;
            if (loading_progress == 90)
            {
                button.gameObject.SetActive(true);
                loading_progress = 100;
            }
            round_load = Mathf.RoundToInt(loading_progress);

            slider.value = round_load / 100;
            text.text = "Loading " + round_load.ToString() + '%';

            yield return true;
        }
    }

    public void Allow()
    {
        AsOp.allowSceneActivation = true;
    }
}
