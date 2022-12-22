using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private int pieceCorrectPosition, currentPosition;
    [SerializeField] private PuzzleGrid puzzleGrid;

    public int PieceCorrectPosition { get { return pieceCorrectPosition; } set { } }
    public int CurrentPosition { get { return currentPosition; } set { currentPosition = value; } }

    // Start is called before the first frame update
    void Start()
    {
        puzzleGrid = GetComponentInParent<PuzzleGrid>();
    }

    private void OnMouseDown()
    {
        if (!puzzleGrid.isPuzzleDone) puzzleGrid.PieceSelected(pieceCorrectPosition);
    }
}
