using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlip : MonoBehaviour

{
    [Header("Card Faces")]
    public GameObject cardFront; 
    public GameObject cardBack;  

    [Header("Front Image")]
    public Image frontImage;

    [HideInInspector] public int cardId;   
    [HideInInspector] public BoardBuilder manager; 

    private bool isMatched = false;
    private CardAnimation animationScript;

    void Awake()
    {
        animationScript = GetComponent<CardAnimation>(); // Get the animation script
    }

    void Start()
    {
        ShowBack(); // default back
    }

    public void OnClick()
    {
        if (isMatched || animationScript.IsAnimating() || animationScript.IsFrontVisible()) return;

        // Flip with animation
        animationScript.Flip(true);

        // play flip sound
        if (AudioManager.Instance != null && AudioManager.Instance.flipCard != null)
            AudioManager.Instance.PlaySound(AudioManager.Instance.flipCard);

        // notify manager
        if (manager != null)
            manager.OnCardRevealed(this);
    }

    public void ShowBack()
    {
        if (!animationScript.IsAnimating())
            animationScript.Flip(false);
    }

    public void MarkMatched()
    {
        isMatched = true;
    }

    // Set sprite from BoardBuilder
    public void SetFrontSprite(Sprite sprite)
    {
        if (frontImage != null)
            frontImage.sprite = sprite;
    }
}
