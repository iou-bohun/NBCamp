using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            else
                return instance;
        }
    }
    private string _playerName = null;
    public string PlayerName
    { get { return _playerName; } 
        set { _playerName = value; }
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
}
