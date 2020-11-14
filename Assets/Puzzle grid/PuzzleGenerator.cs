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
    int a;
    int b;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("manager").GetComponent<GamesManager>();
        puzzleSize = PlayerPrefs.GetInt("size");
        SaveLoadData.instance.playerData.puzzleSize = puzzleSize;

        string Continue = SaveLoadData.instance.playerData.continueGame;
        a = SaveLoadData.instance.playerData.patternID;

        if (Continue == "true")
        {
            CreateGridForContinueGame();
        }
        else
        {
            
            //b = Random.Range(1, puzzleSize);
            CreateGrid();
        }
        
        SetGridPosition();

       

        if (SaveLoadData.instance.playerData.patternID > 9)
        {
            SaveLoadData.instance.playerData.patternID = 0;
        }
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

                RandomizePatern(i,j,go);

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

    void CreateGridForContinueGame()
    {
        string shape = PlayerPrefs.GetString("shape");
        puzzleSize = SaveLoadData.instance.playerData.puzzleSize;

        for (int i = 0; i < puzzleSize; i++)
        {
            for (int j = 0; j < puzzleSize; j++)
            {
                GameObject go = Instantiate(tiles, new Vector3(j - 1.5f, i - 1.5f, 0), Quaternion.identity);
                go.GetComponent<TilesColor>().colorID = DarkTileColor;
                go.transform.SetParent(tilesParent.transform);
                generatedPuzzle.Add(go);
            }
        }

        for (int i = 0; i < generatedPuzzle.Count; i++)
        {
            generatedPuzzle[i].GetComponent<TilesColor>().colorID = SaveLoadData.instance.playerData.tilesColor[i];
            
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
        //Debug.Log(lightTileColor);

        //Debug.Log(DarkTileColor);

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
        yield return null;

        for (int i = 0; i < generatedPuzzle.Count; i++)
        {
           generatedPuzzle[i].GetComponent<TilesColor>().ChangeColor();
          
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
            SaveLoadData.instance.playerData.patternID++;
            Debug.Log("nilai patternID: " + SaveLoadData.instance.playerData.patternID);
        }
    }

    public void UndoStep()
    {
        if(stepDone.Count > 0)
        {
            stepDone[stepDone.Count - 1].UndoStep();
            stepDone.Remove(stepDone[stepDone.Count - 1]);
            gameManager.undoAmount++;
        }
    }

    public void FlipColor()
    {
        for (int i = 0; i < generatedPuzzle.Count; i++)
        {
            generatedPuzzle[i].GetComponent<TilesColor>().reverseColor();
            
        }

        gameManager.turn--;
    }

    public void FlipVertical()
    {
        bool grid1 = false;
        bool grid2 = false;
        bool grid3 = false;
        bool grid4 = false;

        if(puzzleSize == 4 || puzzleSize == 5)
        {
            grid1 = true;
            grid2 = true;
        }
        else if (puzzleSize == 6 || puzzleSize == 7)
        {
            grid1 = true;
            grid2 = true;
            grid3 = true;
        }
        else
        {
            grid1 = true;
            grid2 = true;
            grid3 = true;
            grid4 = true;
        }


        if(grid1 == true)
        {
            //first grid
            VerticalGridFlip(0, 1);
        }
        
        if(grid2 == true)
        {
            //second grid
            VerticalGridFlip(1, 2);
        }
        
        if(grid3 == true)
        {
            //third grid
            VerticalGridFlip(2, 3);
        }
        
        if(grid4 == true)
        {
            //fourth grid
            VerticalGridFlip(3, 4);
        }

        gameManager.turn--;
    }

    void VerticalGridFlip(int beginMultiplier, int endMultiplier)
    {
        for (int i = puzzleSize * beginMultiplier; i < puzzleSize * endMultiplier; i++)
        {
            string temp = generatedPuzzle[i].GetComponent<TilesColor>().colorID;
            //Debug.Log("Warna awal grid 1 tile: " + i + " " + temp);
            //first row
            generatedPuzzle[i].GetComponent<TilesColor>().colorID = generatedPuzzle[generatedPuzzle.Count - (i + 1)].GetComponent<TilesColor>().colorID;
            //second row
            generatedPuzzle[generatedPuzzle.Count - (i + 1)].GetComponent<TilesColor>().colorID = temp;
            //change first row
            generatedPuzzle[i].GetComponent<TilesColor>().ChangeColor();
            //change second row
            generatedPuzzle[generatedPuzzle.Count - (i + 1)].GetComponent<TilesColor>().ChangeColor();
        }
    }

    public void FlipHorizontal()
    {

        HorizontalGridFlip();
        gameManager.turn--;

        //first grid
        /*for (int i = 0; i < 2; i++)
        {
            string temp = generatedPuzzle[i].GetComponent<TilesColor>().colorID;
            Debug.Log("Warna awal grid 1 tile: " + i + " " + temp);
            //first row
            generatedPuzzle[i].GetComponent<TilesColor>().colorID = generatedPuzzle[5 - (i + 1)].GetComponent<TilesColor>().colorID;
            //second row
            generatedPuzzle[5 - (i + 1)].GetComponent<TilesColor>().colorID = temp;
            //change first row
            generatedPuzzle[i].GetComponent<TilesColor>().ChangeColor();
            //change second row
            generatedPuzzle[5 - (i + 1)].GetComponent<TilesColor>().ChangeColor();
        }

        //second grid
        for (int i = 0; i < 2; i++)
        {
            string temp = generatedPuzzle[i + 5].GetComponent<TilesColor>().colorID;
            Debug.Log("Warna awal grid 2 tile: " + i + " " + temp);
            //first row
            generatedPuzzle[i+5].GetComponent<TilesColor>().colorID = generatedPuzzle[5*2 - (i + 1)].GetComponent<TilesColor>().colorID;
            //second row
            generatedPuzzle[5 * 2 - (i + 1)].GetComponent<TilesColor>().colorID = temp;
            //change first row
            generatedPuzzle[i + 5].GetComponent<TilesColor>().ChangeColor();
            //change second row
            generatedPuzzle[5 * 2 - (i + 1)].GetComponent<TilesColor>().ChangeColor();
        }

        //second grid
        for (int i = 0; i < 2; i++)
        {
            string temp = generatedPuzzle[i + (5*2)].GetComponent<TilesColor>().colorID;
            Debug.Log("Warna awal grid 3 tile: " + i + " " + temp);
            //first row
            generatedPuzzle[i + (5 * 2)].GetComponent<TilesColor>().colorID = generatedPuzzle[5 * 3 - (i + 1)].GetComponent<TilesColor>().colorID;
            //second row
            generatedPuzzle[5 * 3 - (i + 1)].GetComponent<TilesColor>().colorID = temp;
            //change first row
            generatedPuzzle[i + (5 * 2)].GetComponent<TilesColor>().ChangeColor();
            //change second row
            generatedPuzzle[5 * 3 - (i + 1)].GetComponent<TilesColor>().ChangeColor();
        }*/
    }

    void HorizontalGridFlip()
    {
        int horizontalTiles = 0;
        int tilesMultiPlierBegin = 0;
        int tilesMultiplierEnd = 0;

        if (puzzleSize == 4 || puzzleSize == 5)
        {
            horizontalTiles = 2;
        }
        else if (puzzleSize == 6 || puzzleSize == 7)
        {
            horizontalTiles = 3;
        }
        else if (puzzleSize == 8)
        {
            horizontalTiles = 4;
        }

        int nilaiTileAwal = 0;
        int nilaiTileAkhir = 0;

        for (int i = 0; i < puzzleSize; i++)
        {
            tilesMultiPlierBegin = i;
            //Debug.Log("nilai tile multi begin: " + tilesMultiPlierBegin);
            tilesMultiplierEnd = i + 1;
            for(int j = 0; j < horizontalTiles; j++)
            {
                string temp = generatedPuzzle[j + (puzzleSize * tilesMultiPlierBegin)].GetComponent<TilesColor>().colorID;
                //Debug.Log("Warna awal grid horizontal tile: " + j + " " + temp);
                //first row
                generatedPuzzle[j + (puzzleSize * tilesMultiPlierBegin)].GetComponent<TilesColor>().colorID = generatedPuzzle[(puzzleSize * tilesMultiplierEnd) - (j + 1)].GetComponent<TilesColor>().colorID;
                //second row
                generatedPuzzle[(puzzleSize * tilesMultiplierEnd) - (j + 1)].GetComponent<TilesColor>().colorID = temp;
                //change first row
                generatedPuzzle[j + (puzzleSize * tilesMultiPlierBegin)].GetComponent<TilesColor>().ChangeColor();
                //change second row
                generatedPuzzle[(puzzleSize * tilesMultiplierEnd) - (j + 1)].GetComponent<TilesColor>().ChangeColor();
                
                /*
                 nilaiTileAwal = j + (puzzleSize * tilesMultiPlierBegin);
                nilaiTileAkhir = (puzzleSize * tilesMultiplierEnd) - (j + 1);

                Debug.Log("nilai tile awal: " + nilaiTileAwal);
                Debug.Log("nilai tile akhir: " + nilaiTileAkhir);
                
                */
                
            }
            
        }
    }

    //this part for randomize pattern

    /*
     basic pattern
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
         */


    void TilesPatern(int i, int j,int tileMin,int tileMax, GameObject go)
    {
        if (i < tileMin || i > puzzleSize - tileMax)
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
    }



    void RandomizePatern(int i, int j, GameObject go)
    {
        

        if(a == 0)
        {
            //this is basic patern
            TilesPatern(i, j, 1, 2, go);
            Debug.Log("basic");
        }
        else if (a == 1)
        {
            //this is random patern
            
            TilesPatern(i+1, j, 1, 0, go);
            Debug.Log("patern 1");
        }
        else if (a == 2)
        {
            //this is random patern

            TilesPatern(i, j+1, 0, 1, go);
            Debug.Log("patern 2");
        }
        else if (a == 3)
        {
            //this is random patern

            TilesPatern(i, j, 2, 2, go);
            Debug.Log("patern 3");
        }
        else if (a == 4)
        {
            //this is random patern

            TilesPatern(i + 1, j+1, 1, 0, go);
            Debug.Log("patern 4");
        }
        else if (a == 5)
        {
            //this is random patern

            TilesPatern(i, j + 2, 0, 1, go);
            Debug.Log("patern 5");
        }
        else if (a == 6)
        {
            //this is random patern

            TilesPatern(i + 2, j, 1, 0, go);
            Debug.Log("patern 6");
        }
        else if (a == 7)
        {
            //this is random patern

            TilesPatern(i+2, j + 2, 0, 1, go);
            Debug.Log("patern 7");
        }
        else if (a == 8)
        {
            //this is random patern

            TilesPatern(i + 1, j+2, 1, 0, go);
            Debug.Log("patern 8");
        }
        else if (a == 9)
        {
            //this is random patern

            TilesPatern(i+2, j + 1, 0, 1, go);
            Debug.Log("patern 9");
        }
    }
}
