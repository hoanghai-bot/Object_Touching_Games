using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] obj;
    public GameObject titleScreen;

    public float spawnRate = 1.0f;
    private int score;
    

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI overgameText;

    public bool isGameActive = true;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
    }

    public void StartGame(int temp)
    {
        spawnRate /= temp;
        isGameActive = true;
        StartCoroutine(SpawnObj());
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);
    }

    IEnumerator SpawnObj()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            var random = Random.Range(0,obj.Length);
            Instantiate(obj[random]);
            //UpdateScore(5);
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        overgameText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
