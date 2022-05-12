using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager{
    private static GameManager _instance;
    private string[] LevelList = {"Tutorial", "Level1", "Level2", "Level3", "Level4", "Level5"};
    private const string StartScene = "StartScene";
    private const string IntroScene = "IntroScene";
    private bool seenIntro = false;
    private const string EndScene = "EndScene";
    private const string VictoryScene = "VictoryScene";
    private static bool shouldMouse = true;
    private static int currLevelIndex = 0;  
    public static GameManager GetInstance(){
        if(_instance == null){
            _instance = new GameManager();
        }
        return _instance;
    }
    public void GameOver(){
        shouldMouse = true;
        SceneManager.LoadScene(EndScene);
    }
    public void QuitGame(){
        shouldMouse = true;
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
        shouldMouse = false;
        if(currLevelIndex > 5){
            shouldMouse = true;
            currLevelIndex = 0;
            SceneManager.LoadScene(VictoryScene);
            return;
        } else {
            SceneManager.LoadScene(LevelList[currLevelIndex]);
            currLevelIndex++;
            return;
        }
    }
    public void RestartLevel(){
        SceneManager.LoadScene(LevelList[currLevelIndex]);
    }

    public bool getMouseState(){
        return GameManager.shouldMouse;
    }
}
