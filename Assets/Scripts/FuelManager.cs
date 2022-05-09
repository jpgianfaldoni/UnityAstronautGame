using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FuelManager : MonoBehaviour
{
    
    public int fuel;
    public int startFuel = 1000;
    public Text fuelText;

    public void Start(){
        this.fuel = this.startFuel;
        this.fuelText.text = this.fuel.ToString();
    }

    // No mention of amount, implies 1;
    public void useFuel(){
        this.useFuel(1);
    }

    // Spend amount of fuel
    public void useFuel(int amt){
        if(this.fuel > amt){
            this.fuel-= amt;
        } else if(this.fuel > 0) {
            this.fuel = 0;
        } else {
            return;
        }
        this.fuelText.text = this.fuel.ToString();
    }
}
