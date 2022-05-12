using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    private GameManager gm;
    void Start(){
        gm = GameManager.GetInstance();
        if(gm.getMouseState()){
            Cursor.lockState = CursorLockMode.None;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void RetryBtnClick(){
        gm.RestartLevel();
    }
    public void QuitBtnClick(){
        gm.QuitGame();
    }
}
