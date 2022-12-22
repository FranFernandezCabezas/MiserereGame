using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoxManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicBoxAS;
    [SerializeField] private GameObject coverOpened, coverClosed;
    [SerializeField] public bool isBoxOpened;
    [SerializeField] private PuzzleGrid puzzle;
    // Start is called before the first frame update
    void Start()
    {
        isBoxOpened = false;
        musicBoxAS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseMusicBox()
    {
        coverOpened.SetActive(false);
        coverClosed.SetActive(true);
        CheckCorrectOrder();
        isBoxOpened = false;
    }

    public void OpenMusicBox()
    {
        if (!puzzle.isPuzzleDone)
        {
            coverOpened.SetActive(true);
            coverClosed.SetActive(false);
            isBoxOpened = true;
        }
    }

    private void CheckCorrectOrder()
    {
        if (puzzle.isPuzzleDone)
        {
            musicBoxAS.Play();
        }
        else
        {
            for (int i = 0; i < puzzle.PuzzlePieces.Count; i++)
            {
                puzzle.PuzzlePieces[i].GetComponent<AudioSource>().Play();
            }
        }
    }
}
