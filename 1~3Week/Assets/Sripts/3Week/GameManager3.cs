using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instance;
    public GameObject retryBtn;

    int level = 0;
    int cat = 0;
    public GameObject dog;
    public GameObject food;
    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;

    public TextMeshProUGUI text;
    public GameObject levelFront;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("SpawnFood", 0.0f, 0.2f);
        InvokeRepeating("MakeCat", 0.0f, 1f);
    }

    public void SpawnFood()
    {
        float x = dog.transform.position.x;
        float y = dog.transform.position.y;
        Instantiate(food, new Vector3(x,y,0), Quaternion.identity);

    }

    public void MakeCat()
    {
        Instantiate(normalCat);

        if (level == 1)
        {
            float p = Random.Range(0, 10);
            if (p < 2) Instantiate(normalCat);
        }
        else if (level == 2)
        {
            float p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        else if (level >= 3)
        {
            float p = Random.Range(0, 10);
            if (p < 6) Instantiate(normalCat);

            Instantiate(fatCat);
        }
        else if (level >= 4)
        {
            float p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);

            Instantiate(fatCat);
            Instantiate(pirateCat);
        }
    }
    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddCat()
    {
        cat += 1;
        level = cat / 5;

        text.text = level.ToString();
        levelFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1.0f, 1.0f);
    }
}
