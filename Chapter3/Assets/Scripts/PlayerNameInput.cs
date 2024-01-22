using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    string name = null;

    public void NameButton()
    {
       name = playerNameInput.GetComponent<TMP_InputField>().text;   
        if(name.Length<3)
        {
            Debug.Log("�̸��� �Է����ּ���");
        }
        else
        {
            GameManager.Instance.PlayerName = name;
            SceneManager.LoadScene("Main");
        }
    }
}
