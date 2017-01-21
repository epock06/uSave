using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;

//------------------ by ---------------------
//
//Game Designer / Developer : http://www.ogaoo.com
//............╔══╦══╦══╦══╦══╗.................
//............║╔╗║╔═╣╔╗║╔╗║╔╗║.................
//............║╚╝║╚╝║╠╣║╚╝║╚╝║.................
//............╚══╩══╩╝╚╩══╩══╝.................

public class Save : MonoBehaviour
{
	/*
	 * Public
	 */

	public  string[] stockDistance;

	/*
	 * Private
	 */

	private string myPath;

	/*
	* Constructor
	*/

	void Start ()
	{
		myPath = Application.persistentDataPath + "/table.txt";
		GetComponent<TextMesh> ().text = myPath;
		//_____________Mobile_________________
		StartCoroutine (SaveTable ());
		StartCoroutine (LoadTable ());
		//________________________________________________
	}

	void Update ()
	{
		//___________________desktop________________________________
		if (Input.GetKeyDown (KeyCode.S)) {
			StartCoroutine (SaveTable ());
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			StartCoroutine (LoadTable ());
		}
		//___________________________________________________________
	}

	IEnumerator LoadTable ()
	{
		yield return new WaitForSeconds (6f);
		//__________________Mobile_____________________
		GetComponent<TextMesh> ().text = "LOADING" + "\n" + myPath;
		//____________________________________________
		StartCoroutine (myLoad ());
	}

	IEnumerator SaveTable ()
	{
		yield return new WaitForSeconds (2f);
		//_________________Mobile__________________________________________
		GetComponent<TextMesh> ().text = "SAVING" + "\n" + myPath;
		//_________________________________________________________________  
		StartCoroutine (mySave ());
	}

	IEnumerator mySave ()
	{
		yield return new WaitForSeconds (2f);
		//_________________Mobile__________________________________________
		GetComponent<TextMesh> ().text = "RESULT SAVING" + "\n";
		//_________________________________________________________________  
		TextWriter writer;
		string fileName = myPath;
		writer = new StreamWriter (fileName);


		stockDistance [3] = ("------- save ! ------------");//-------------------content modification line 4 ----------



		for (int i = 0; i < stockDistance.Length; i++) {
			writer.WriteLine (stockDistance [i]);//	-----------------------------writing----------------
			//_____________________________________Mobile________________
			GetComponent<TextMesh> ().text += stockDistance [i] + "\n";
			//___________________________________________________________
		}
		writer.Close ();   
	}

	IEnumerator myLoad ()
	{
		yield return new WaitForSeconds (2f);
		//_________________Mobile__________________________________________
		GetComponent<TextMesh> ().text = "RESULT LOADING" + "\n";
		//_________________________________________________________________  
		string fileName = myPath;
		stockDistance = File.ReadAllLines (fileName);//--------------------------loading (table)---------------
		for (int i = 0; i < stockDistance.Length; i++) {
			Debug.Log (stockDistance [i]);//---------------------------------accessing-------------------------
			//_____________________________________Mobile________________
			GetComponent<TextMesh> ().text += stockDistance [i] + "\n";
			//___________________________________________________________
		}
	}
}