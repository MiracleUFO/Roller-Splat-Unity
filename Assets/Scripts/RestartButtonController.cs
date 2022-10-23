using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtonController : MonoBehaviour
{
    private Button button;
    private GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
      gameOverText = GameObject.Find("GameOver");
      button = GetComponent<Button>();
      button.onClick.AddListener(RestartGame);
    }

    /* When a button is clicked, remove GameOverText and allow ball to move
    */
    void RestartGame()
    {
      gameOverText.SetActive(false);
    }

}
