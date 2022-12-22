using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Tooltip("The puzzle piece connected to this pick up.")]
    [SerializeField] GameObject attachedPuzzlePiece;
    [Tooltip("The puzzle grid where the attached piece needs to go")]
    [SerializeField] PuzzleGrid puzzlePieceGrid;

    [Space(10)]
    [Header("Phrase")]
    [Tooltip("If the character needs to say something when picking this up.")]
    [TextArea(0, 10)]
    [SerializeField] string phrase = "";

    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnMouseDown()
    {
        if (attachedPuzzlePiece != null)
        {
            if (!attachedPuzzlePiece.activeSelf)
            {
                attachedPuzzlePiece.SetActive(true);
                puzzlePieceGrid.AddPuzzlePieceToList(attachedPuzzlePiece.GetComponent<PuzzlePiece>());
                if (phrase != "")
                {
                    uiManager.ShowPickUpText(phrase);
                }
                Destroy(gameObject);
            }
        }
        else if (phrase != "")
        {
            uiManager.ShowPickUpText(phrase);
        }
    }
}
