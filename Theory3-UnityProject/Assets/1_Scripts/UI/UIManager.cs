using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CMF
{
	//This script is used in the showcase scene to control the controller selection/settings menu;
	public class UIManager : MonoBehaviour {

		//The menu is shown/hidden using this key;
		public KeyCode menuKey = KeyCode.C;

		//Reference to game object containing the demo menu UI;
		public GameObject demoMenuObject;

		void Start () {
			//Hide menu;
			SetMenuEnabled(false);
		}
		
		// Update is called once per frame
		void Update () {

			//Hide/show demo menu;
			if(Input.GetKeyDown(menuKey))
			{
				SetMenuEnabled(!demoMenuObject.activeSelf);
			}

			//If scene was built as a Windows executable, also hide/show demo menu when 'Escape' is pressed;
			#if UNITY_STANDALONE_WIN
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				SetMenuEnabled(!demoMenuObject.activeSelf);
			}
			#endif

			//If left mouse button is pressed and the menu is hidden, lock cursor;
			if(Input.GetMouseButtonDown(0) && !demoMenuObject.activeSelf)
				Cursor.lockState = CursorLockMode.Locked;
		}

		//Reload scene;
		public void RestartScene()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		//Quit game;
		public void QuitGame()
		{
			Application.Quit();
		}	

		//Hide/show menu;
		public void SetMenuEnabled(bool _isEnabled)
		{
			demoMenuObject.SetActive(_isEnabled);
			if(_isEnabled)
				Cursor.lockState = CursorLockMode.None;
			else
				Cursor.lockState = CursorLockMode.Locked;
		}
	}
}
