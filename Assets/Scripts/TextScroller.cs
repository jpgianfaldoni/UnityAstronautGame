using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScroller : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(0, this.transform.localPosition.y + 1f, 0);
        if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)){
            advanceToFirstLevel();
        }
        if (this.transform.localPosition.y > 1700){
            advanceToFirstLevel();
        }
    }

    void advanceToFirstLevel(){
        gm.NextLevel();
    }
}
