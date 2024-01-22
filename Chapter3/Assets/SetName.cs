using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetName : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerName;

    private void Start()
    {
        playerName.text = GameManager.Instance.PlayerName;
    }
}
