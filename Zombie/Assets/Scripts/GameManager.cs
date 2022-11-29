using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // How many enemies alive i have in the game
    public int enemiesAlive = 0;
    public int round = 0;
    // Spawn the enemies at random locations
    public GameObject[] spawnPoints;
    // The enemy to create
    public GameObject enemyPrefab;

    public TextMeshProUGUI roundText;
    public TextMeshProUGUI roundsSurvived; 
    public GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive == 0)
        {
            round++;
            NextWave(round);
            roundText.text = "Round: " + round.ToString();
        }
    }

    public void NextWave(int round)
    {
        // for create many enemies from 0 to the round current
        for (var x = 0; x < round; x++)
        {
            // Random location
            GameObject spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; ;
            // Instantiate - Create object at run time (Quaternion - with no rotation)
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnpoint.transform.position, Quaternion.identity);

            // Instead of dragging the GameManager in unity
            // Get the enemyManager script
            // And set the GameManager to be current component
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            // Increase the enemies that are alive with the next wave 
            enemiesAlive++;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        // be able to move the mouse out of the game in unity
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);
        roundsSurvived.text = round.ToString();
    }
}
