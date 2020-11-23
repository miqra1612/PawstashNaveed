using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesColor : MonoBehaviour
{
    public string colorID;
    public CircleCollider2D col;
    private Rigidbody2D rb;
    private GamesManager gameManager;
    private PuzzleGenerator puzzleGenerator;
    private SpriteRenderer objectSprite;

    public List<TilesColor> nearbyTiles;

    private string lightTileColor;
    private string DarkTileColor;
    
    private TilesColor tc;

    // Start is called before the first frame update
    void Start()
    {
        objectSprite = gameObject.GetComponent<SpriteRenderer>();
        lightTileColor = PlayerPrefs.GetString("LightColor");
        DarkTileColor = PlayerPrefs.GetString("DarkColor");

        
        col = gameObject.GetComponent<CircleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("manager").GetComponent<GamesManager>();
        puzzleGenerator = GameObject.FindGameObjectWithTag("manager").GetComponent<PuzzleGenerator>();
        tc = gameObject.GetComponent<TilesColor>();

        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSetting()
    {
        lightTileColor = PlayerPrefs.GetString("LightColor");
        DarkTileColor = PlayerPrefs.GetString("DarkColor");
        

        if (colorID == "white")
        {
            colorID = lightTileColor;
        }
        else if (colorID == "black")
        {
            colorID = DarkTileColor;
        }
        else if (colorID == "redL")
        {
            colorID = lightTileColor;
        }
        else if (colorID == "redD")
        {
            colorID = DarkTileColor;
        }

        ChangeColor();
    }

    public void ChangeColor()
    {
        if(colorID == "white")
        {
            objectSprite.color = Color.white;
        }
        else if (colorID == "black")
        {
            objectSprite.color = Color.black;
        }
        else if (colorID == "redL")
        {
            objectSprite.color = Color.red;
        }
        else if (colorID == "redD")
        {
            objectSprite.color = Color.red;
        }
    }

    public void reverseColor()
    {
        if (colorID == lightTileColor)
        {
            colorID = DarkTileColor;
        }
        else if (colorID == DarkTileColor)
        {
            colorID = lightTileColor;
        }

        ChangeColor();
    }

    private void OnMouseDown()
    {
        TapTheTiles();
        
    }

    public void TapTheTiles()
    {
        if (gameManager.isPlaying && gameManager.turn > 0)
        {
            nearbyTiles.Clear();

            if (gameManager.exploder == false)
            {
                col.enabled = true;
            }
            else
            {
                //exploder active code here

                SaveLoadData.instance.playerData.exploder--;
                SaveLoadData.instance.playerData.exploderUsed++;
                gameManager.exploderValue.text = SaveLoadData.instance.playerData.exploder.ToString();
                GameUIController.instance.exploderButton.image.color = Color.black;
                gameManager.exploder = false;
            }


            if (colorID == lightTileColor)
            {

                colorID = DarkTileColor;
            }
            else
            {

                colorID = lightTileColor;
            }



            ChangeColor();
            StartCoroutine(ChangingOtherColor());
            puzzleGenerator.stepDone.Add(tc);

        }
    }

    public void PreClickTiles()
    {
        nearbyTiles.Clear();
        
        col.enabled = true;
       
        if (colorID == lightTileColor)
        {
            colorID = DarkTileColor;
        }
        else
        {
            colorID = lightTileColor;
        }
        
        ChangeColor();
        StartCoroutine(ChangingPreClickColor());
        puzzleGenerator.preClickStep.Add(tc);

    }

    public void SolutionTiles()
    {
        nearbyTiles.Clear();

        col.enabled = true;

        if (colorID == lightTileColor)
        {
            colorID = DarkTileColor;
        }
        else
        {
            colorID = lightTileColor;
        }

        ChangeColor();
        StartCoroutine(ChangingPreClickColor());
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "box")
        {
            //Debug.Log("aa");
            nearbyTiles.Add(collision.GetComponent<TilesColor>());
        }
    }

    IEnumerator ChangingPreClickColor()
    {
        for (int i = 0; i < 4; i++)
        {
            col.radius += 0.3f;
        }

        yield return new WaitForSeconds(0.02f);

        for (int i = 0; i < nearbyTiles.Count; i++)
        {
            nearbyTiles[i].reverseColor();
        }

        nearbyTiles.Clear();
        col.radius = 0;
        col.enabled = false;
        
    }

    IEnumerator ChangingOtherColor()
    {
        for (int i = 0; i < 4; i++)
        {
            col.radius += 0.3f;
        }

        yield return new WaitForSeconds(0.1f);

       
        for (int i = 0; i < nearbyTiles.Count; i++)
        {
            nearbyTiles[i].reverseColor();
        }

        nearbyTiles.Clear();
        col.radius = 0;
        col.enabled = false;

        if(gameManager.isPlaying == true)
        {
           gameManager.TakeOutTurn(1);
        }
        
    }

    public void UndoStep()
    {
        if (gameManager.isPlaying && gameManager.turn > 0)
        {
          

            nearbyTiles.Clear();
            col.enabled = true;

            if (colorID == lightTileColor)
            {

                colorID = DarkTileColor;
            }
            else
            {

                colorID = lightTileColor;
            }

            
            ChangeColor();
            StartCoroutine(ChangingOtherColor());
            
        }
    }

    public void UndoPreclick()
    {
        
            nearbyTiles.Clear();
            col.enabled = true;

            if (colorID == lightTileColor)
            {

                colorID = DarkTileColor;
            }
            else
            {

                colorID = lightTileColor;
            }

            ChangeColor();
            StartCoroutine(ChangingOtherColor());

       
    }
}
