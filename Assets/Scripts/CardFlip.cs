using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlip : MonoBehaviour

{
    [Header("Card Faces")]
    public GameObject cardFront; // child "CardFront"
    public GameObject cardBack;  // child "CardBack"

    [Header("Front Image")]
    public Image frontImage; // assign the Image component of CardFront in the Inspector

    [HideInInspector] public int cardId;   // ID for matching
    [HideInInspector] public BoardBuilder manager; // who spawned this card

    private bool isFlipped = false;
    private bool isMatched = false;

    void Start()
    {
        ShowBack(); // default = back side
    }

    public void OnClick()
    {
        if (isMatched || isFlipped) return; // don't flip matched or already open

        ShowFront();

        // tell the manager this card was revealed
        if (manager != null)
            manager.OnCardRevealed(this);
    }

    private void ShowFront()
    {
        cardFront.SetActive(true);
        cardBack.SetActive(false);
        isFlipped = true;
    }

    public void ShowBack()
    {
        cardFront.SetActive(false);
        cardBack.SetActive(true);
        isFlipped = false;
    }

    public void MarkMatched()
    {
        isMatched = true;
        // (optional) tint green to show it's matched
       
    }

    // ⭐ NEW: BoardBuilder calls this when spawning
    public void SetFrontSprite(Sprite sprite)
    {
        if (frontImage != null)
            frontImage.sprite = sprite;
    }
}
