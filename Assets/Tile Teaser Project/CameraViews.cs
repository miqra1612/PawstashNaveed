using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViews : MonoBehaviour
{
    private Camera cam;
    private PuzzleGenerator puzzle;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        puzzle = GameObject.FindGameObjectWithTag("manager").GetComponent<PuzzleGenerator>();
        SetCameraView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCameraView()
    {
        if(puzzle.puzzleSize == 4)
        {
            cam.fieldOfView = 46;
        }
        else if (puzzle.puzzleSize == 5)
        {
            cam.fieldOfView = 56;
        }
        else if (puzzle.puzzleSize == 6)
        {
            cam.fieldOfView = 64;
        }
        else if (puzzle.puzzleSize == 7)
        {
            cam.fieldOfView = 72;
        }
        else if (puzzle.puzzleSize == 8)
        {
            cam.fieldOfView = 78;
        }
    }
}
