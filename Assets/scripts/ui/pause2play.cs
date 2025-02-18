using UnityEngine;

public class pause2play : MonoBehaviour {
	[SerializeField] GameObject playText;
	
	void OnDisable(){
		playText.SetActive(true);
	}

	void OnEnable(){
		playText.SetActive(false);
	}
	
}
