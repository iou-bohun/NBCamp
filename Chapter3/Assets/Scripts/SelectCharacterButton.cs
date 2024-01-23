using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterButton : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    public bool toggle;

    public void ChangeBtn()
    {
        toggle = !toggle;
        if (toggle)
        {
            this.GetComponent<Image>().sprite = sprites[0];
        }
        else
        {
            this.GetComponent<Image>().sprite = sprites[1];
        }
    }
}
