using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour {

	public GameObject panelMain;
	public GameObject panelControls;
	public GameObject panelCredits;
	public GameObject panelSettings;
	public GameObject panelCharacterSelection;

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(!panelMain.activeSelf){
				showMain();
			}
		}
	}

	public void showMain (){
		panelMain.SetActive (true);
		panelControls.SetActive (false);
		panelCredits.SetActive (false);
		panelSettings.SetActive (false);
		panelCharacterSelection.SetActive (false);
	}

	public void showControls (){
		panelMain.SetActive (false);
		panelControls.SetActive (true);
		panelCredits.SetActive (false);
		panelSettings.SetActive (false);
		panelCharacterSelection.SetActive (false);
	}

	public void showCredits (){
		panelMain.SetActive (false);
		panelControls.SetActive (false);
		panelCredits.SetActive (true);
		panelSettings.SetActive (false);
		panelCharacterSelection.SetActive (false);
	}

	public void showSettings (){
		panelMain.SetActive (false);
		panelControls.SetActive (false);
		panelCredits.SetActive (false);
		panelSettings.SetActive (true);
		panelCharacterSelection.SetActive (false);
	}

	public void showCharacterSelection (){
		panelMain.SetActive (false);
		panelControls.SetActive (false);
		panelCredits.SetActive (false);
		panelSettings.SetActive (false);
		panelCharacterSelection.SetActive (true);
	}
}