using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour{
    public x360_GamePadMenu inputMenu;

    public GameObject panelMain;
	public GameObject panelControls;
	public GameObject panelCredits;
	public GameObject panelSettings;
	public GameObject panelCharacterSelection;

    public GameObject selectedPlay;
    public GameObject selectedSettings;
    public GameObject selectedControllers;
    public GameObject selectedQuit;
    

    void Start(){
        inputMenu = this.GetComponent<x360_GamePadMenu>();
    }

    void Update(){
        if(inputMenu.GetSubmit()){
            this.Submit();
        }

        if(inputMenu.GetLeft()){
            this.Prev();
        }
        
        if(inputMenu.GetRight()){
            this.Next();
        }
        
    }

    private void Submit(){
        if(selectedPlay.activeSelf){
            this.showCharacterSelection();
        }else if(selectedControllers.activeSelf){
            this.showControls();
        }else if(selectedSettings.activeSelf){
            this.showSettings();
        }else if(selectedQuit.activeSelf){
            this.QuitGame();
        }
    }

    private void Next(){
        if(selectedPlay.activeSelf){
            selectedPlay.SetActive(false);
            selectedControllers.SetActive(true);
        }else if(selectedControllers.activeSelf){
            selectedControllers.SetActive(false);
            selectedSettings.SetActive(true);
        }else if(selectedSettings.activeSelf){
            selectedSettings.SetActive(false);
            selectedQuit.SetActive(true);
        }else if(selectedQuit.activeSelf){
            selectedQuit.SetActive(false);
            selectedPlay.SetActive(true);
        }
    }

    private void Prev(){
        if(selectedPlay.activeSelf){
            selectedPlay.SetActive(false);
            selectedQuit.SetActive(true);
        }else if(selectedControllers.activeSelf){
            selectedControllers.SetActive(false);
            selectedPlay.SetActive(true);
        }else if(selectedSettings.activeSelf){
            selectedSettings.SetActive(false);
            selectedControllers.SetActive(true);
        }else if(selectedQuit.activeSelf){
            selectedQuit.SetActive(false);
            selectedSettings.SetActive(true);
        }
    }

    private void QuitGame(){
		Application.Quit();
	}

	private void showControls (){
		panelMain.SetActive (false);
		panelControls.SetActive (true);
		panelCredits.SetActive (false);
		panelSettings.SetActive (false);
		panelCharacterSelection.SetActive (false);
	}

	private void showCredits (){
		panelMain.SetActive (false);
		panelControls.SetActive (false);
		panelCredits.SetActive (true);
		panelSettings.SetActive (false);
		panelCharacterSelection.SetActive (false);
	}

	private void showSettings (){
		panelMain.SetActive (false);
		panelControls.SetActive (false);
		panelCredits.SetActive (false);
		panelSettings.SetActive (true);
		panelCharacterSelection.SetActive (false);
	}

	private void showCharacterSelection (){
		panelMain.SetActive (false);
		panelControls.SetActive (false);
		panelCredits.SetActive (false);
		panelSettings.SetActive (false);
		panelCharacterSelection.SetActive (true);
	}

}