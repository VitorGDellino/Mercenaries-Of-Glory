using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerInfo : MonoBehaviour{
    public x360_GamePadMenu inputMenu;
    public GameObject panelInfo;
	public GameObject current;
    public GameObject currentSelect;

    void Start(){
        inputMenu = this.GetComponent<x360_GamePadMenu>();
    }
    void Update(){
        if(inputMenu.GetBack()){
            this.showMain();
        }     
    }

	private void showMain (){
		panelInfo.SetActive (true);
        currentSelect.SetActive(true);
		current.SetActive (false);
	}
}