using System.Collections;
using UnityEngine;

[System.Serializable]
public class GameStateCtrl : MonoBehaviour
{
    private GameObject gameController;
    void Awake()
    {
        gameController = GameObject.Find("GameController");
    }

    public void Start()
    {
    }
   
    // Update is called once per frame
    void Update()
    {
        InputHandler.Instance.ExecuteCommand();

        if (Input.GetKeyDown("q"))
        {
            //When a key is pressed down it see if it was the escape key if it was it will execute the code
            Application.Quit(); // Quits the game
        }
    }
}