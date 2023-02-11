using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class LogicManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int attackScore;
    private int playerHealth = 100;
    private int enemyTotalBullets = 100;
    public Text playerScoreText;
    public Text enemyBulletText;
    private int gameLevel = 1;

    public GameObject gameOverScreen;
    public GameObject gameWinScreen;
    public GameObject enemyLayerLevel1;
    public GameObject enemyLayerLevel2;
    public GameObject spawnLayer1;
    public GameObject spawnLayer2;

    public bool isPlayerAlive = true;

    public IDictionary<string, int> enemyTypes = new Dictionary<string, int>(){
        {"stone", 1},
        {"arrow", 2},
        {"bullet", 5},
        {"cannon", 10},
        {"laser", 50}
    };
    
    public int spriteWidth = 500;
    public int spriteHeight = 500;
    public Color spriteColor = Color.white;

    public Texture2D LoadTexture(string FilePath) {
 
     // Load a PNG or JPG file from disk to a Texture2D
     // Returns null if load fails
 
     Texture2D Tex2D;
     byte[] FileData;
 
     if (File.Exists(FilePath)){
       FileData = File.ReadAllBytes(FilePath);
       Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
       if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
         return Tex2D;                 // If data = readable -> return texture
     }  
     return null;                     // Return null if load failed
   }

    public void changeGameLevel(){
        enemyLayerLevel1.SetActive(false);
        enemyLayerLevel2.SetActive(true);

        spawnLayer1.SetActive(false);
        spawnLayer2.SetActive(true);
    }

    [ContextMenu("Reduce Player Score")]
    public void reducePlayerScore(){
        int scoreToReduce;
        if(gameLevel == 1){
            scoreToReduce = 2;
        }else if(gameLevel ==  2){
            scoreToReduce = 5;
        } else {
            scoreToReduce = 10;
        }

        playerHealth -= scoreToReduce;

        playerScoreText.text = playerHealth.ToString();

        if(playerHealth <= 0){
            handlePlayerDead();
        }
    }

    [ContextMenu("Reduce Enemy Score")]
    public void reduceEnemyScore(int scoreToReduce){
        enemyTotalBullets -= scoreToReduce;
        
        if(gameLevel == 3){
            gameWinScreen.SetActive(true);
            isPlayerAlive = false;
        }

        if(enemyTotalBullets <= 0){
            changeGameLevel();
            enemyTotalBullets = 100;
            gameLevel+=1;
        } 
        

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
