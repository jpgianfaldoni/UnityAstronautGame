using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private GameManager gm;
    void Start(){
        gm = GameManager.GetInstance();
    }
    public void BtnClick(){
        gm.NextLevel();
    }
}
