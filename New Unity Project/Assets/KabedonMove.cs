using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabedonMove : MonoBehaviour {

	GameManager gameManager;
	RectTransform rect;
	public Animator anim;
	public GameObject particle;

	void Start () {
		gameManager = GameManager.Instance;
		rect = GetComponent<RectTransform> ();
	}

	void Update () {
		if (!gameManager.startFlag) {
			Instantiate (particle, new Vector3 (transform.position.x, transform.position.y, -50f), Quaternion.identity);
			Destroy (gameObject);
		}
		// 1P側の攻撃
		if (gameManager.attack1P) {
			rect.anchoredPosition = new Vector2 (rect.anchoredPosition.x, rect.anchoredPosition.y + gameManager.speed);
		}
		// 2P側の攻撃
		//else {
		//	rect.anchoredPosition = new Vector2 (rect.anchoredPosition.x - gameManager.speed, rect.anchoredPosition.y);
		//}
	}

	/// <summary>
	/// 衝突判定
	/// </summary>
	void OnTriggerEnter2D (Collider2D other){
		gameManager.rhyzhmButtonList
            .RemoveAt (gameManager.rhyzhmPrefabList.IndexOf (gameObject));
		gameManager.rhyzhmPrefabList.Remove (gameObject);
		Destroy (gameObject);
	}

	public void LeadIcon (){
		anim.SetBool ("LeadIcon", true);
	}

	void OnDestroy() {
		gameManager.LeadIconDecide ();
		if (!gameManager.startFlag) {
			gameManager.rhyzhmButtonList.Clear ();
			gameManager.rhyzhmPrefabList.Clear ();
		}
	}
}
