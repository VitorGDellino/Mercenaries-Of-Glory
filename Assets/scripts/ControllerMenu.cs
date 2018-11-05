using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerMenu : MonoBehaviour{
    public x360_GamePadMenu inputMenu;
    public GameObject panelMain;
	public GameObject panelControls;
	public GameObject panelCredits;
	public GameObject panelSettings;
	public GameObject panelCharacterSelection;

    void Start(){
        inputMenu = this.GetComponent<x360_GamePadMenu>();
    }
    void Update(){
        if(inputMenu.GetBack()){
            this.showMain();
        }     
    }

	private void showMain (){
		panelMain.SetActive (true);
		panelControls.SetActive (false);
		panelCredits.SetActive (false);
		panelSettings.SetActive (false);
		panelCharacterSelection.SetActive (false);
	}
}