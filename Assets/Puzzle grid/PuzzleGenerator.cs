using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGenerator : MonoBehaviour
{
    public GameObject tiles;
    public GameObject tilesParent;
    public int puzzleSize = 4;

    public Sprite[] tilesSprite;
    public List<GameObject> generatedPuzzle;
    public List<TilesColor> stepDone;

    private GamesManager gameManager;
    private string lightTileColor;
    private string DarkTileColor;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("manager").GetComponent<GamesManager>();
        puzzleSize = PlayerPrefs.GetInt("size");
        CreateGrid();
        SetGridPosition();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGrid()
    {
        lightTileColor = PlayerPrefs.GetString("LightColor");
        DarkTileColor = PlayerPrefs.GetString("DarkColor");
        string shape = PlayerPrefs.GetString("shape");

        for (int i = 0; i < puzzleSize; i++)
        {
            for (int j = 0; j < puzzleSize; j++)
            {
                GameObject go = Instantiate(tiles, new Vector3(j - 1.5f, i - 1.5f, 0), Quaternion.identity);
                if (i < 1 || i > puzzleSize - 2 )
                {
                    go.GetComponent<TilesColor>().colorID = DarkTileColor;
                }
                else if (i > 0 && i < puzzleSize - 1 && j > 0 && j < puzzleSize - 1)
                {
                    go.GetComponent<TilesColor>().colorID = lightTileColor;
                }
                else
                {
                    go.GetComponent<TilesColor>().colorID = DarkTileColor;
                }

                if(shape == "rounded")
                {
                    go.GetComponent<SpriteRenderer>().sprite = tilesSprite[0];
                }
                else if (shape == "square")
                {
                    go.GetComponent<SpriteRenderer>().sprite = tilesSprite[1];
                }
                else if (shape == "circle")
                {
                    go.GetComponent<SpriteRenderer>().sprite = tilesSprite[2];
                }

                go.transform.SetParent(tilesParent.transform);



                generatedPuzzle.Add(go);
            }
        }

    }

    void SetGridPosition()
    {
        if (puzzleSize == 4)
        {
            tilesParent.transform.position = Vector3.zero;
        }
        else if (puzzleSize == 5)
        {
            tilesParent.transform.position = new Vector3(-0.5f, -0.5f, 0);
        }
        else if (puzzleSize == 6)
        {
            tilesParent.transform.position = new Vector3(-1f, -1, 0);
        }
        else if (puzzleSize == 7)
        {
            tilesParent.transform.position = new Vector3(-1.5f, -1.5f, 0);
        }
        else if (puzzleSize == 8)
        {
            tilesParent.transform.position = new Vector3(-2f, -2, 0);
        }
    }

    public void ApplyNewSettings()
    {
        lightTileColor = PlayerPrefs.GetString("LightColor");
        DarkTileColor = PlayerPrefs.GetString("DarkColor");
        string shape = PlayerPrefs.GetString("shape");
        Debug.Log(lightTileColor);

        Debug.Log(DarkTileColor);

        for (int i = 0; i < generatedPuzzle.Count; i++)
        {
            generatedPuzzle[i].GetComponent<TilesColor>().LoadSetting();
            

            if (shape == "rounded")
            {
                generatedPuzzle[i].GetComponent<SpriteRenderer>().sprite = tilesSprite[0];
            }
            else if (shape == "square")
            {
                generatedPuzzle[i].GetComponent<SpriteRenderer>().sprite = tilesSprite[1];
            }
            else if (shape == "circle")
            {
                generatedPuzzle[i].GetComponent<SpriteRenderer>().sprite = tilesSprite[2];
            }
        }

    }

    IEnumerator ChangeColor()
    {
        
        for (int i = 0; i < generatedPuzzle.Count; i++)
        {
           generatedPuzzle[i].GetComponent<TilesColor>().ChangeColor();
           yield return new WaitForSeconds(0.1f);
            
        }

        gameManager.isPlaying = true;
        gameManager.StartTimer();
       
    }

    public void StartChangeColor()
    {
        StartCoroutine(ChangeColor());
    }

    public void CheckingColor()
    {
        int a = 0;
        for(int i = 0; i < generatedPuzzle.Count; i++)
        {
            if(generatedPuzzle[i].GetComponent<SpriteRenderer>().color == generatedPuzzle[0].GetComponent<SpriteRenderer>().color)
            {
                a++;
            }
        }
        //Debug.Log(a);
        if (a == generatedPuzzle.Count)
        {
            GameUIController gc = GetComponent<GameUIController>();
            //Debug.Log(a);
            gameManager.EndGame();

            int gameScore = puzzleSize * puzzleSize;

            gc.ShowWinningResult(gameScore, 1);
            gameManager.OpenPanel(1);
        }
    }

    public void UndoStep()
    {
        if(stepDone.Count > 0)
        {
            stepDone[stepDone.Count - 1].UndoStep();
            stepDone.Remove(stepDone[stepDone.Count - 1]);
        }
    }

    public void FlipColor()
    {
        for (int i = 0; i < generatedPuzzle.Count; i++)
        {
            generatedPuzzle[i].GetComponent<TilesColor>().reverseColor();
            
        }
    }
}
