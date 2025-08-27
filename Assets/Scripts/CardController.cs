using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManagement : MonoBehaviour

{

    public GameObject front;  
    public GameObject back;   
    private bool isFlipped = false;

    public void OnCardClicked()
    {
        if (isFlipped) return;

        FlipCard();
    }

    public void FlipCard()
    {
        isFlipped = true;
        back.SetActive(false);
        front.SetActive(true);
    }

    public void ResetCard()
    {
        isFlipped = false;
        back.SetActive(true);
        front.SetActive(false);
    }
}
