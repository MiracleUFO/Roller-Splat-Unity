using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    private GroundPiece[] allGroundPieces;

    private GameObject gameOverText;

    public GameObject explosionFx;


    private void Start()
    {
        SetupNewLevel();
        gameOverText = GameObject.Find("GameOver");
        gameOverText.SetActive(false);
    }

    private void SetupNewLevel()
    {
        allGroundPieces = FindObjectsOfType<GroundPiece>();
    }

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetupNewLevel();
    }

    public void CheckComplete()
    {
        bool isFinished = true;

        for (int i = 0; i < allGroundPieces.Length; i++)
        {
            if (allGroundPieces[i].isColored == false)
            {
                isFinished = false;
                break;
            }
        }

        if (isFinished) {
            Instantiate(explosionFx, explosionFx.transform.position, explosionFx.transform.rotation);
            StartCoroutine(NextLevel());
        }
    }

    // While game is active spawn a random target

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(5);

        if (SceneManager.GetActiveScene().buildIndex != 3) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else {
            gameOverText.SetActive(true);
        }
        Destroy(GameObject.Find("Fireworks - Rocket - Blue Rain 2(Clone)"));
    }

}
