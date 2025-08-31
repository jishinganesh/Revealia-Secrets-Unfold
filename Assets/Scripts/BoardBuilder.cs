using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardBuilder : MonoBehaviour

{
    [Header("Card Prefab")]
    public GameObject cardPrefab;

    public GameObject gameOverpannel;
    public GameObject backbutton;

    [Header("Parent with GridLayoutGroup")]
    public GridLayoutGroup gridLayout;


    [Header("Card Faces")]
    public List<Sprite> frontSprites; // assign images in Inspector

    private List<CardFlip> comparing = new List<CardFlip>();
    private int totalPairs;
    private int matchedPairs = 0;
    private int lastColumns;
    private int lastRow;

    void Start()
    {
        if (gameOverpannel != null)
            gameOverpannel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            BuildBoard(2, 2); // Level 1
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            BuildBoard(2, 3); // Level 2
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            BuildBoard(5, 6); // Level 3
    }
    public void loadlevel1Easy()
    {
        BuildBoard(2, 2);

    }
    public void loadlevel2Medium()
    {
        BuildBoard(2, 3);
    }
    public void loadlevel3Hard()
    {
        BuildBoard(5, 6);
    }

    public void BuildBoard(int rows, int columns)
    {
        lastRow = rows;
        lastColumns = columns;
        // Clear old cards
        foreach (Transform child in gridLayout.transform)
            Destroy(child.gameObject);

        // Set grid
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = columns;

        // Prepare deck
        List<int> ids = new List<int>();
        totalPairs = (rows * columns) / 2;
        matchedPairs = 0;

        for (int i = 0; i < totalPairs; i++)
        {
            ids.Add(i);
            ids.Add(i);
        }
        Shuffle(ids);

        // Spawn cards
        for (int i = 0; i < ids.Count; i++)
        {
            GameObject go = Instantiate(cardPrefab, gridLayout.transform);
            CardFlip card = go.GetComponent<CardFlip>();

            card.cardId = ids[i];
            card.manager = this;

            // give each pair a unique front image
            if (ids[i] < frontSprites.Count)
                card.SetFrontSprite(frontSprites[ids[i]]);
        }

        Debug.Log($" Built {rows}x{columns} board with {totalPairs} pairs.");
    }

    public void retry()
    {
        BuildBoard(lastRow, lastColumns);


        if (gameOverpannel != null)
            gameOverpannel.SetActive(false);
    }

    private void Shuffle(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }

    // 🔹 Called by CardFlip.OnClick()
    public void OnCardRevealed(CardFlip card)
    {
        if (comparing.Contains(card)) return;
        comparing.Add(card);

        if (comparing.Count == 2)
        {
            StartCoroutine(CheckPair());
        }
    }

    private System.Collections.IEnumerator CheckPair()
    {
        yield return new WaitForSeconds(0.5f); // small delay to show both cards

        var a = comparing[0];
        var b = comparing[1];
        comparing.Clear();

        if (a.cardId == b.cardId)
        {
            a.MarkMatched();
            b.MarkMatched();
            matchedPairs++;
            Debug.Log($" Pair matched! {matchedPairs}/{totalPairs}");

            AudioManager.Instance.PlaySound(AudioManager.Instance.matchCard);

            if (matchedPairs >= totalPairs)
            {
                if (gameOverpannel != null)
                    gameOverpannel.SetActive(true);
                    backbutton.SetActive(false);

                AudioManager.Instance.PlaySound(AudioManager.Instance.gameOver);
            }

        }
        else
        {
            a.ShowBack();
            b.ShowBack();
            
            AudioManager.Instance.PlaySound(AudioManager.Instance.mismatchCard);
        }
    }
    
}
