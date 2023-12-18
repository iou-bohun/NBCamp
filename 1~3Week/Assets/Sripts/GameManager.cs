using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject rain;


    private void Start()
    {
        InvokeRepeating("SpawnRain",0,0.5f);
    }

    void SpawnRain()
    {
        Instantiate(rain);
    }

    public void Retrty()
    {
        SceneManager.LoadScene("Main");
    }
}
