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

    public List<TilesColor> nearbyTiles;

    private string lightTileColor;
    private string DarkTileColor;
    
    private TilesColor tc;

    // Start is called before the first frame update
    void Start()
    {
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
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (colorID == "black")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else if (colorID == "redL")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (colorID == "redD")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
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
        if (gameManager.isPlaying && gameManager.turn > 0)
        {
            nearbyTiles.Clear();
            if(gameManager.exploder == false)
            {
                col.enabled = true;
            }
            else
            {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "box")
        {
            //Debug.Log("aa");
            nearbyTiles.Add(collision.GetComponent<TilesColor>());
        }
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
        gameManager.TakeOutTurn(1);
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
}
