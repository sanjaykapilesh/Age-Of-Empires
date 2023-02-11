using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int attackScore;
    private int playerHealth = 100;
    private int enemyTotalBullets = 100;
    public Text playerScoreText;
    public Text enemyBulletText;

    public GameObject gameOverScreen;
    public GameObject enemyLayer;

    public bool isPlayerAlive = true;

    public IDictionary<string, int> enemyTypes = new Dictionary<string, int>(){
        {"stone", 1},
        {"arrow", 2},
        {"bullet", 5},
        {"cannon", 10},
        {"laser", 50}
    };
    
    [ContextMenu("Reduce Player Score")]
    public void reducePlayerScore(int scoreToReduce){
        playerHealth -= scoreToReduce;
        playerScoreText.text = playerHealth.ToString();

        if(playerHealth <= 0){
            handlePlayerDead();
        }
    }

    [ContextMenu("Reduce Enemy Score")]
    public void reduceEnemyScore(int scoreToReduce){
        enemyTotalBullets -= scoreToReduce;
        enemyBulletText.text = enemyTotalBullets.ToString();
    }

    public void resetGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void handlePlayerDead(){
        isPlayerAlive = false;
        gameOver();
    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
    }
}
