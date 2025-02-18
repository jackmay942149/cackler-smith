using UnityEngine;

public class DisablePlay : MonoBehaviour {
	[SerializeField] float timer;
	float timeEnabled;
	
	void OnEnable(){
		timeEnabled = Time.time;
	}

	void Update(){
		if (Time.time > timeEnabled + timer){
			gameObject.SetActive(false);
		}
	}
}
