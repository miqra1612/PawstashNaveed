using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesColor : MonoBehaviour
{
    public string colorID;
    public CircleCollider2D col;
    private Rigidbody2D rb;
    private GamesManager gameManager;

    public List<TilesColor> nearbyTiles;

    private string lightTileColor;
    private string DarkTileColor;
    private string vibration;
    // Start is called before the first frame update
    void Start()
    {
        lightTileColor = PlayerPrefs.GetString("LightColor");
        DarkTileColor = PlayerPrefs.GetString("DarkColor");
        vibration = PlayerPrefs.GetString("vibrate");


        col = gameObject.GetComponent<CircleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("manager").GetComponent<GamesManager>();

        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        else if (colorID == "red")
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
            col.enabled = true;

            if (colorID == lightTileColor)
            {
               
                colorID = DarkTileColor;
            }
            else
            {
              
                colorID = lightTileColor;
            }

            if(vibration == "true")
            {
                Handheld.Vibrate();
            }

            ChangeColor();
            StartCoroutine(ChangingOtherColor());

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
}
