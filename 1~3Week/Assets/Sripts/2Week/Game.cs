using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game I;
    public GameObject drop;
    public GameObject pannel;
    float gTime;
    bool isRunning = true;
    [SerializeField] TextMeshProUGUI timeTxt;
    [SerializeField] TextMeshProUGUI thisScoreTxt;
    [SerializeField] TextMeshProUGUI maxScore;
    public Animator anim;
    private void Awake()
    {
        I = this;
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("Spawn", 0.0f,0.5f);
    }

    private void Update()
    {
        if (isRunning)
        {
            gTime += Time.deltaTime;
            timeTxt.text = gTime.ToString("N2");
        }
        
    }
    public void Spawn()
    {
        Instantiate(drop);
    }

    public void GameOver()
    {
        isRunning =false;
        anim.SetBool("Pop", true);
        Invoke("EndTime", 0.5f);
        pannel.SetActive(true);
        thisScoreTxt.text = gTime.ToString("N2");
        if (PlayerPrefs.HasKey("betScore") == false)
        {
            PlayerPrefs.SetFloat("betScore", gTime);
        }
        else
        {
            if(gTime > PlayerPrefs.GetFloat("betScore"))
            {
                PlayerPrefs.SetFloat("betScore", gTime);
            }
        }
        float maxs = PlayerPrefs.GetFloat("betScore");
        maxScore.text = maxs.ToString("N2");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndTime()
    {
        Time.timeScale = 0f;
    }

}
