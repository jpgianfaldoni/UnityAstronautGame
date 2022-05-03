using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public int fuel;
    public int startFuel = 1000;
    public Text fuelText;

    public void Start(){
        this.fuel = this.startFuel;
        this.fuelText.text = this.fuel.ToString();
    }

    public void useFuel(){
        if(this.fuel > 0){
            this.fuel--;
            this.fuelText.text = this.fuel.ToString();
        }
    }

    
    private void GameOver(){
    }


}
