using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour    
{
    public static GameManager instance;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject end;

    private void Awake()
    {
        instance = this;
    }
    [SerializeField] TextMeshProUGUI timeTxt;
    float time;
    [SerializeField] GameObject card;
    
    private void Start()
    {
        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if(time > 30f)
        {
            GameEnd();
        }
        Debug.Log(GameObject.Find("Cards").transform.childCount);
    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            firstCard.GetComponent<Card>().destroyCard();
            secondCard.GetComponent<Card>().destroyCard();

            int childCont = GameObject.Find("Cards").transform.childCount;
            if(childCont == 2)
            {
                Invoke("GameEnd", 1f);
            }
        }
        else
        {
            firstCard.GetComponent<Card>().closeCard();
            secondCard.GetComponent<Card>().closeCard();
        }

        firstCard = null;
        secondCard = null;
    }

    private void GameEnd()
    {
        Time.timeScale = 0;
        end.SetActive(true);
    }
}
