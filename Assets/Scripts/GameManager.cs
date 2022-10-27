using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int score;
    public bool isGameRunning;
    public GameObject titleScreen;
    public DifficultyButton difficultyButtonScript;
    public int gameDifficulty;


    public GameObject[] helloLetters;
    public GameObject[] computerLetters;
    public GameObject[] squirrelLetters;
    public GameObject[] easySolution;
    public GameObject[] regularSolution;
    public GameObject[] hardSolution;

    // Start is called before the first frame update
    void Start()
    {

}

// Update is called once per frame
void Update()
    {

    }

    IEnumerator SpawnTarget(int difficulty)
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(spawnRate);
   
            int hello = Random.Range(0, helloLetters.Length);
            int computer = Random.Range(0, computerLetters.Length);
            int squirrel = Random.Range(0, squirrelLetters.Length);


            if (difficulty == 1) {
                Instantiate(helloLetters[hello]);
            } else if (difficulty == 2)
            {
                Instantiate(computerLetters[computer]);
            } else
            {
                Instantiate(squirrelLetters[squirrel]);
            }
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameRunning = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameRunning = true;
        StartCoroutine(SpawnTarget(difficulty));
        scoreText.gameObject.SetActive(true);
        score = 0;
        spawnRate /= difficulty;
        gameDifficulty = difficulty;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }

    public void RecieveLetter(int numberForWord)
    {
        if (gameDifficulty == 1)
        {
            if (numberForWord == 7)
            {
                easySolution[0].SetActive(true);

            }
            if (numberForWord == 4 && easySolution[0].activeSelf)
            {
                easySolution[1].SetActive(true);

            }
            if (numberForWord == 11 && easySolution[2].activeSelf)
            {
                easySolution[3].SetActive(true);

            }
            if (numberForWord == 11 && easySolution[1].activeSelf)
            {
                easySolution[2].SetActive(true);

            }
            if (numberForWord == 14 && easySolution[3].activeSelf)
            {
                easySolution[4].SetActive(true);

            }

        } else if (gameDifficulty == 2)
        {
            if (numberForWord == 2)
            {
                regularSolution[0].SetActive(true);

            }
            if (numberForWord == 14 && regularSolution[0].activeSelf)
            {
                regularSolution[1].SetActive(true);

            }
            if (numberForWord == 12 && regularSolution[1].activeSelf)
            {
                regularSolution[2].SetActive(true);

            }
            if (numberForWord == 15 && regularSolution[2].activeSelf)
            {
                regularSolution[3].SetActive(true);

            }
            if (numberForWord == 20 && regularSolution[3].activeSelf)
            {
                regularSolution[4].SetActive(true);

            }
            if (numberForWord == 19 && regularSolution[4].activeSelf)
            {
                regularSolution[5].SetActive(true);

            }
            if (numberForWord == 4 && regularSolution[5].activeSelf)
            {
                regularSolution[6].SetActive(true);

            }
            if (numberForWord == 17 && regularSolution[6].activeSelf)
            {
                regularSolution[7].SetActive(true);

            }
            if (numberForWord == 22 && regularSolution[7].activeSelf)
            {
                regularSolution[8].SetActive(true);

            }

        } else
            {
                if (numberForWord == 18)
                {
                hardSolution[0].SetActive(true);

                }
                if (numberForWord == 16 && hardSolution[0].activeSelf)
                {
                hardSolution[1].SetActive(true);

                }
                if (numberForWord == 20 && hardSolution[1].activeSelf)
                {
                hardSolution[2].SetActive(true);

                }
                if (numberForWord == 8 && hardSolution[2].activeSelf)
                {
                hardSolution[3].SetActive(true);

                }
                if (numberForWord == 17 && hardSolution[4].activeSelf)
                {
                hardSolution[5].SetActive(true);

                }
                if (numberForWord == 17 && hardSolution[3].activeSelf)
                {
                hardSolution[4].SetActive(true);

                }
                if (numberForWord == 4 && hardSolution[5].activeSelf)
                {
                hardSolution[6].SetActive(true);

                }
            if (numberForWord == 11 && hardSolution[5].activeSelf)
            {
                hardSolution[7].SetActive(true);

            }
        }

    }

}



