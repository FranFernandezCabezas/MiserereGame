using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleGrid : MonoBehaviour
{
    [Header("Puzzle list")]
    [Tooltip("Shows the full content of the list containing the puzzle pieces")]
    [SerializeField] private List<PuzzlePiece> puzzlePieces;
    [SerializeField] private int numOfPieces;
    [Tooltip("-1 = No piece selected")]
    [SerializeField] private int selectedPuzzlePiece = -1;
    public bool isPuzzleDone;

    public List<PuzzlePiece> PuzzlePieces { get { return puzzlePieces; } }

    [Header("After puzzle variables")]
    [Tooltip("Gameobjects of the locked zone completing this puzzle unlocks")]
    [SerializeField] private GameObject lockedDoor, openDoor;

    // Start is called before the first frame update
    void Start()
    {
        puzzlePieces = gameObject.GetComponentsInChildren<PuzzlePiece>().ToList();
        isPuzzleDone = false;
    }

    private void Update()
    {
        if (isPuzzleDone)
        {
            lockedDoor.SetActive(false);
            openDoor.SetActive(true);
        }
    }

    // Checks if all the piece and materials are in their right place
    private bool CheckPuzzleSolved()
    {
        for (int i = 0; i < puzzlePieces.Count; i++)
        {
            if (puzzlePieces[i].PieceCorrectPosition != puzzlePieces[i].CurrentPosition) 
            {
                return false;
            }
        }
        return true;
    }

    // Checks when a piece is selected if it's the same than last time or if its a new one.
    public void PieceSelected(int pressedPiece)
    {
        // Checks if all the pieces have been recolected
        if (puzzlePieces.Count == numOfPieces)
        {
            // If it's the same it unselects that piece.
            if (selectedPuzzlePiece == pressedPiece)
            {
                selectedPuzzlePiece = -1;
            }
            // If it's not the same and it's not -1 it means it's a different piece and they have to swap.
            else if (selectedPuzzlePiece != -1)
            {
                SwapPieces(selectedPuzzlePiece, pressedPiece);
            }
            // this else only works if selectedPuzzlePiece is -1, which means it has no piece selected.
            else
            {
                selectedPuzzlePiece = pressedPiece;
            }
        }
        else
        {
            UIManager uiManager = FindObjectOfType<UIManager>();
            uiManager.ShowPickUpText("There are missing pieces for this puzzle.");
        }
    }

    // Method called when two pieces are pressed. We change the position from the first one with the second one
    private void SwapPieces(int firstSelected, int secondSelected)
    {
        PuzzlePiece firstPiece = puzzlePieces[firstSelected];
        PuzzlePiece secondPiece = puzzlePieces[secondSelected];

        // We swap the position
        Vector3 selectedPrevPos = firstPiece.transform.position;
        firstPiece.transform.position = secondPiece.transform.position;
        secondPiece.transform.position = selectedPrevPos;

        // We swap the "Current place" of the pieces
        int previousPos = firstPiece.CurrentPosition;
        firstPiece.CurrentPosition = secondPiece.CurrentPosition;
        secondPiece.CurrentPosition = previousPos;


        selectedPuzzlePiece = -1;
        isPuzzleDone = CheckPuzzleSolved();
    }

    public void AddPuzzlePieceToList(PuzzlePiece puzzlePiece)
    {
        puzzlePieces.Add(puzzlePiece);
    }
}
