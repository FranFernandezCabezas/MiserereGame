using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGrid : MonoBehaviour
{
    [Header("Puzzle arrays")]
    [Tooltip("Shows the full content of the array containing the puzzle pieces")]
    [SerializeField] private PuzzlePiece[] puzzlePieces;
    [Tooltip("Contains the reference to the materials forming the full puzzle")]
    [SerializeField] private Material[] puzzleMaterials;
    [Tooltip("-1 = No piece selected")]
    [SerializeField] private int selectedPuzzlePiece = -1;
    public bool isPuzzleDone;

    // Start is called before the first frame update
    void Start()
    {
        puzzlePieces = gameObject.GetComponentsInChildren<PuzzlePiece>();
        isPuzzleDone = false;
    }

    // Checks if all the piece and materials are in their right place
    private bool CheckPuzzleSolved()
    {
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (puzzlePieces[i].PiecePos != puzzlePieces[i].PieceMaterialPos) 
            {
                return false;
            }
        }
        return true;
    }

    // Checks when a piece is selected if it's the same than last time or if its a new one.
    public void PieceSelected(int piecePos)
    {
        // If it's the same it unselects that piece.
        if (selectedPuzzlePiece == piecePos)
        {
            selectedPuzzlePiece = -1;
        }
        // If it's not the same and it's not -1 it means it's a different piece and they have to swap.
        else if (selectedPuzzlePiece != -1)
        {
            SwapMaterials(selectedPuzzlePiece, piecePos);
        }
        // this else only works if selectedPuzzlePiece is -1, which means it has no piece selected.
        else
        {
            selectedPuzzlePiece = piecePos;
        }
    }

    // Method called when two pieces are pressed. We change the material from the first one with the second one
    private void SwapMaterials(int firstSelected, int secondSelected)
    {
        PuzzlePiece firstPiece = puzzlePieces[firstSelected];
        PuzzlePiece secondPiece = puzzlePieces[secondSelected];

        // We swap the pointer to the materials
        int selectedPrevPos = firstPiece.PieceMaterialPos;
        firstPiece.PieceMaterialPos = secondPiece.PieceMaterialPos;
        secondPiece.PieceMaterialPos = selectedPrevPos;

        firstPiece.PieceMaterial = puzzleMaterials[firstPiece.PieceMaterialPos];
        secondPiece.PieceMaterial = puzzleMaterials[secondPiece.PieceMaterialPos];
        firstPiece.gameObject.GetComponent<MeshRenderer>().material = firstPiece.PieceMaterial;
        secondPiece.gameObject.GetComponent<MeshRenderer>().material = secondPiece.PieceMaterial;
        selectedPuzzlePiece = -1;
        CheckPuzzleSolved();
    }
}
