using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isInBox;
    private GameManager gm;
 
    void Update(){
        // if(isInBox){
        //     Debug.Log("Found in box!");
        // } else {
        //     Debug.Log("Not in box!");
        // }
    }
    
    void OnTriggerStay(Collider other){
        if(other.CompareTag("Player")){
            isInBox = true;
            gm.NextLevel();
        }
    }
    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            isInBox = false;
        }
    }
    void Start()
    {
        gm = GameManager.GetInstance();
    }
}
