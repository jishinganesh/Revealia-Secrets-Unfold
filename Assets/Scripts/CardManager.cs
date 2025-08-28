using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject CardPrefab;
    public Transform gridHolder;

    public int colums = 2;
    public int rows = 2;

    void Start()
    {
        GenerateCard();
    }
    void GenerateCard()
    {
        int totalCard = colums * rows;

        for (int i = 0; i < totalCard; i++)
        {
            GameObject card = Instantiate(CardPrefab, gridHolder);
            card.name = "cards" + i;
        }
    }
}
