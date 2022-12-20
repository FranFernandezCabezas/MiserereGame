using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private int piecePos;
    [SerializeField] private int pieceMaterialPos;
    [SerializeField] private Material pieceMaterial;
    [SerializeField] private PuzzleGrid puzzleGrid;

    public int PiecePos { get { return piecePos; } set { } }
    public int PieceMaterialPos { get { return pieceMaterialPos; } set { pieceMaterialPos = value;} }
    public Material PieceMaterial { get { return pieceMaterial; } set { pieceMaterial = value; } }

    // Start is called before the first frame update
    void Start()
    {
        puzzleGrid = GetComponentInParent<PuzzleGrid>();
        pieceMaterial = gameObject.GetComponent<MeshRenderer>().material;
    }

    private void OnMouseDown()
    {
        if (!puzzleGrid.isPuzzleDone) puzzleGrid.PieceSelected(piecePos);
    }
}
