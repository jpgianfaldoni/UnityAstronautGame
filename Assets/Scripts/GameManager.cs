using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager{
    private static GameManager _instance;
    private string[] LevelList = {"Tutorial", "Level1", "Level2", "Level3", "Level4", "Level5"};
    private string StartScene = "StartScene";
    private string IntroScene = "IntroScene";
    private bool seenIntro = false;
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
    public void QuitGame(){
        currLevelIndex = 0;
        SceneManager.LoadScene(StartScene);
    }
    public void NextLevel(){
        // Show intro first time
        if(!seenIntro){
            SceneManager.LoadScene(IntroScene);
            seenIntro = true;
            return;
        }
        currLevelIndex++;
        if(currLevelIndex >= LevelList.Length){
            currLevelIndex = 0;
            SceneManager.LoadScene(VictoryScene);
        } else {
            SceneManager.LoadScene(LevelList[currLevelIndex]);
        }
    }
    public void RestartLevel(){
        SceneManager.LoadScene(LevelList[currLevelIndex]);
    }
}
