using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour

{
    public GameObject cardFront;
    public GameObject cardBack;

    private bool isAnimating = false;
    private bool showingFront = false;

    public float flipSpeed = 5f; // control speed

    /// <summary>
    /// Animate card flip
    /// </summary>
    public void Flip(bool showFront)
    {
        if (!isAnimating)
            StartCoroutine(FlipRoutine(showFront));
    }

    private IEnumerator FlipRoutine(bool showFront)
    {
        isAnimating = true;

        float time = 0f;
        Quaternion startRot = transform.rotation;
        Quaternion midRot = Quaternion.Euler(0, 90, 0);
        Quaternion endRot = Quaternion.Euler(0, 0, 0);

        // First half → rotate to 90° (card is thin/invisible)
        while (time < 0.5f)
        {
            time += Time.deltaTime * flipSpeed;
            transform.rotation = Quaternion.Lerp(startRot, midRot, time / 0.5f);
            yield return null;
        }

        // Swap faces at halfway
        cardFront.SetActive(showFront);
        cardBack.SetActive(!showFront);

        // Second half → rotate back
        time = 0f;
        while (time < 0.5f)
        {
            time += Time.deltaTime * flipSpeed;
            transform.rotation = Quaternion.Lerp(midRot, endRot, time / 0.5f);
            yield return null;
        }

        showingFront = showFront;
        isAnimating = false;
    }

    public bool IsAnimating() => isAnimating;
    public bool IsFrontVisible() => showingFront;
}
