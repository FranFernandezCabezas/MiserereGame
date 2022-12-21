using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Tooltip("The puzzle piece connected to this pick up.")]
    [SerializeField] GameObject attachedPuzzlePiece;
    [Tooltip("The puzzle grid where the attached piece needs to go")]
    [SerializeField] PuzzleGrid puzzlePieceGrid;

    [Tooltip("If the character needs to say something when picking this up.")]
    [SerializeField] string phrase = "";

    private void Start()
    {
    }

    private void OnMouseDown()
    {
        if (!attachedPuzzlePiece.activeSelf)
        {
            attachedPuzzlePiece.SetActive(true);
            puzzlePieceGrid.AddPuzzlePieceToList(attachedPuzzlePiece.GetComponent<PuzzlePiece>());
            Destroy(gameObject);
        }
    }

}
