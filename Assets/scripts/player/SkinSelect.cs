using UnityEngine;

public class SkinSelect : MonoBehaviour {
	[SerializeField] Sprite[] skins = new Sprite[4];
	SpriteRenderer sr;

	void Start(){
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = skins[PlayerPrefs.GetInt("CharSelect")];
	}
}
