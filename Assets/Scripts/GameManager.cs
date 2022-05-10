using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager{
    private static GameManager _instance;
    private string[] SceneList = {"BaseGameScene", "Level1", "Level2", "Level3", "Level4", "Level5"};
    private string StartScene = "StartScene";
    private string EndScene = "EndScene";
    private string VictoryScene = "VictoryScene";
    private static int currLevelIndex = 0;  
    public static GameManager GetInstance(){
        if(_instance == null){
            _instance = new GameManager();
        }
        return _instance;
    }
    public void GameOver(){
        SceneManager.LoadScene(EndScene);
    }
    public void NextLevel(){
        currLevelIndex++;
        if(currLevelIndex > SceneList.Length){
            currLevelIndex = 0;
            SceneManager.LoadScene(VictoryScene);
        } else {
            SceneManager.LoadScene(SceneList[currLevelIndex]);
        }
    }
    public void RestartLevel(){
        SceneManager.LoadScene(SceneList[currLevelIndex]);
    }
}
