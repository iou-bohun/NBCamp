using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataAManager : MonoBehaviour
{
    private static DataAManager instance;
    public static DataAManager Instance
    {
        get
        {
            if(null == instance)
                return null;
            else
                return instance;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private int score;
    public int Score
    {
        get { return score;}
        set { score = value; }
    }

    [SerializeField]
    float leftTime = 60;
    [SerializeField]
    TextMeshProUGUI scoret, time;

    private void Update()
    {
        leftTime -= Time.deltaTime;
        if(leftTime < 0)
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
        }
        scoret.text = "Score: "+score.ToString(); 
        time.text = "LeftTime: "+ leftTime.ToString("N2");
    }

}
