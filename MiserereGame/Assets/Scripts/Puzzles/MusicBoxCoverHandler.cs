using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoxCoverHandler : MonoBehaviour
{
    [SerializeField] private MusicBoxManager mbManager;

    private void OnMouseDown()
    {
        if (mbManager.isBoxOpened)
        {
            mbManager.CloseMusicBox();
        }
        else
        {
            mbManager.OpenMusicBox();
        }
    }
}
