using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager> {

	/// <summary>
	/// タイトル画面のゲームスタート用ボタンのプレハブ
	/// </summary>
	public Button startButton;

	/// <summary>
	/// ゲームがスタートした際のフラグ
	/// </summary>
	public bool startFlag = false;

	/// <summary>
	/// 1Pが攻撃する際のフェイズ
	/// </summary>
	public bool attack1P = true;

	/// <summary>
	/// アイコン？の移動スピード
	/// </summary>
	public float speed = 10f;

	/// <summary>
	/// 攻守交替用のタイマー
	/// </summary>
	float attackChangeTimer;

	/// <summary>
	/// MoveCameraのコンポーネント
	/// </summary>
	//MoveCamera moveCamera;

	/// <summary>
	/// アイコン？配置用のプレハブ
	/// 0=Up1P, 1=Middle1P, 2=Bottom1P, 3=Up2P, 4=Middle2P, 5=Bottom2P
	/// </summary>
	GameObject[] railPrefab = new GameObject[6];

	/// <summary>
	/// アイコン？生成用のプレハブ
	/// 0=Up, 1=Middle, 2=Bottom
	/// </summary>
	public GameObject[] railIcon = new GameObject[3];

	/// <summary>
	/// リザルト画面のプレハブ
	/// </summary>
	GameObject resultPanel;

	/// <summary>
	/// リザルト画面のボタンのプレハブ
	/// </summary>
	Button playMoreButton, toTitleButton;

	/// <summary>
	/// タイマー配置用プレハブ
	/// </summary>
	//public GameObject meterPOP1, meterPOP2;

	/// <summary>
	/// タイマー生成用プレハブ
	/// </summary>
	//public GameObject meter;

	//PlayerCtrl[] playerctrl = new PlayerCtrl[2];

	/// <summary>
	/// NImage
	/// 0=1P, 1=2P
	/// </summary>
	Image[] nImg = new Image[2];
	/// <summary>
	/// Y1PImage
	/// </summary>
	Image[] imgY1P = new Image[14];
	/// <summary>
	/// XB1PImage
	/// </summary>
	Image[] imgXB1P = new Image[14];
	/// <summary>
	/// a1PImage
	/// </summary>
	Image[] imgA1P = new Image[14];
	/// <summary>
	/// Y2PImage
	/// </summary>
	Image[] imgY2P = new Image[14];
	/// <summary>
	/// XB2PImage
	/// </summary>
	Image[] imgXB2P = new Image[14];
	/// <summary>
	/// A2PImage
	/// </summary>
	Image[] imgA2P = new Image[14];

	/// <summary>
	/// プレイヤー判別用
	/// </summary>
	//[SerializeField, Range(1,2)]
	public int playerNum = 1;

    /// <summary>
    /// 壁ドンの順番を管理するリスト
    /// int: 1=上段, 2=中段, 3=下段<br>
    /// </summary>
    public List<int> rhyzhmButtonList = new List<int>();
    /// <summary>
    /// 壁ドンの順番を管理するリスト
    /// int: 1=上段, 2=中段, 3=下段<br>
    /// </summary>
    public List<GameObject> rhyzhmPrefabList = new List<GameObject>();

    void Start(){
		DontDestroyOnLoad (this);
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.sceneUnloaded += OnSceneUnloaded;
		OnSceneLoaded (SceneManager.GetActiveScene (), LoadSceneMode.Single);

        RhythmAttack1P();
    }

	void Update(){
		// GameSceneの時のみ動作
		//if (SceneManager.GetActiveScene ().name == "Game") {
			if (startFlag) {
				// 1P側の攻撃
				//if (attack1P) {
					//RhythmAttack1P ();
				//}
				// 2P側の攻撃
				//else {
					//RhythmAttack2P ();
				//}
				// AttackChange ();
			}
		//}
		// TitleSceneの時のみ動作
		//else if (SceneManager.GetActiveScene ().name == "Title") {

		//}
	}

	/// <summary>
	/// シーン移動時に呼ばれる処理
	/// </summary>
	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		//switch (scene.name) {
		//case "Title":
		//	startButton = GameObject.Find ("StartPanel").GetComponent<Button> ();
		//	startButton.onClick.AddListener (() => SceneMove ("Game"));
		//	startButton.onClick.AddListener (() => GameStart ());
		//	//AudioController.Play( "title" );

		//	break;
		//case "Game": // TODO:無駄多すぎ、時間あれば修正　DontDestroyいらなかった
			Application.targetFrameRate = 60;
			railPrefab [0] = GameObject.Find ("RailUp1P");
			railPrefab [1] = GameObject.Find ("RailMiddle1P");
			railPrefab [2] = GameObject.Find ("RailBottom1P");
            railPrefab [3] = GameObject.Find ("BallAppear");
			//railPrefab [3] = GameObject.Find ("RailUp2P");
			//railPrefab [4] = GameObject.Find ("RailMiddle2P");
			//railPrefab [5] = GameObject.Find ("RailBottom2P");
			//resultPanel = GameObject.Find ("ResultPanel");
			//playMoreButton = resultPanel.transform.Find ("PlayMoreButton").GetComponent<Button> ();
			//playMoreButton.onClick.AddListener (() => SceneMove ("Game"));
			//toTitleButton = resultPanel.transform.Find ("ToTitleButton").GetComponent<Button> ();
			//toTitleButton.onClick.AddListener (() => SceneMove ("Title"));
			rhyzhmButtonList = new List<int> ();
			rhyzhmPrefabList = new List<GameObject> ();
			//moveCamera = Camera.main.GetComponent<MoveCamera> ();
			//playerctrl [0] = GameObject.Find ("Character1P").GetComponent<PlayerCtrl> ();
			//playerctrl [1] = GameObject.Find ("Character2P").GetComponent<PlayerCtrl> ();
			//meterPOP1 = GameObject.Find ("MeterPOP1");
			//meterPOP2 = GameObject.Find ("MeterPOP2");
			//nImg [0] = GameObject.Find ("neutral1P").GetComponent<Image> ();
			//nImg [1] = GameObject.Find ("neutral2P").GetComponent<Image> ();
			////for (int i = 0; i >= 14; i++) {
			//imgY1P[0] = GameObject.Find ("Y1P0").GetComponent<Image> ();
			//imgY1P[1] = GameObject.Find ("Y1P1").GetComponent<Image> ();
			//imgY1P[2] = GameObject.Find ("Y1P2").GetComponent<Image> ();
			//imgY1P[3] = GameObject.Find ("Y1P3").GetComponent<Image> ();
			//imgY1P[4] = GameObject.Find ("Y1P4").GetComponent<Image> ();
			//imgY1P[5] = GameObject.Find ("Y1P5").GetComponent<Image> ();
			//imgY1P[6] = GameObject.Find ("Y1P6").GetComponent<Image> ();
			//imgY1P[7] = GameObject.Find ("Y1P7").GetComponent<Image> ();
			//imgY1P[8] = GameObject.Find ("Y1P8").GetComponent<Image> ();
			//imgY1P[9] = GameObject.Find ("Y1P9").GetComponent<Image> ();
			//imgY1P[10] = GameObject.Find ("Y1P10").GetComponent<Image> ();
			//imgY1P[11] = GameObject.Find ("Y1P11").GetComponent<Image> ();
			//imgY1P[12] = GameObject.Find ("Y1P12").GetComponent<Image> ();
			//imgY1P[13] = GameObject.Find ("Y1P13").GetComponent<Image> ();

			//imgXB1P[0] = GameObject.Find ("XB1P0").GetComponent<Image> ();
			//imgXB1P[1] = GameObject.Find ("XB1P1").GetComponent<Image> ();
			//imgXB1P[2] = GameObject.Find ("XB1P2").GetComponent<Image> ();
			//imgXB1P[3] = GameObject.Find ("XB1P3").GetComponent<Image> ();
			//imgXB1P[4] = GameObject.Find ("XB1P4").GetComponent<Image> ();
			//imgXB1P[5] = GameObject.Find ("XB1P5").GetComponent<Image> ();
			//imgXB1P[6] = GameObject.Find ("XB1P6").GetComponent<Image> ();
			//imgXB1P[7] = GameObject.Find ("XB1P7").GetComponent<Image> ();
			//imgXB1P[8] = GameObject.Find ("XB1P8").GetComponent<Image> ();
			//imgXB1P[9] = GameObject.Find ("XB1P9").GetComponent<Image> ();
			//imgXB1P[10] = GameObject.Find ("XB1P10").GetComponent<Image> ();
			//imgXB1P[11] = GameObject.Find ("XB1P11").GetComponent<Image> ();
			//imgXB1P[12] = GameObject.Find ("XB1P12").GetComponent<Image> ();
			//imgXB1P[13] = GameObject.Find ("XB1P13").GetComponent<Image> ();

			//imgA1P[0] = GameObject.Find ("A1P0").GetComponent<Image> ();
			//imgA1P[1] = GameObject.Find ("A1P1").GetComponent<Image> ();
			//imgA1P[2] = GameObject.Find ("A1P2").GetComponent<Image> ();
			//imgA1P[3] = GameObject.Find ("A1P3").GetComponent<Image> ();
			//imgA1P[4] = GameObject.Find ("A1P4").GetComponent<Image> ();
			//imgA1P[5] = GameObject.Find ("A1P5").GetComponent<Image> ();
			//imgA1P[6] = GameObject.Find ("A1P6").GetComponent<Image> ();
			//imgA1P[7] = GameObject.Find ("A1P7").GetComponent<Image> ();
			//imgA1P[8] = GameObject.Find ("A1P8").GetComponent<Image> ();
			//imgA1P[9] = GameObject.Find ("A1P9").GetComponent<Image> ();
			//imgA1P[10] = GameObject.Find ("A1P10").GetComponent<Image> ();
			//imgA1P[11] = GameObject.Find ("A1P11").GetComponent<Image> ();
			//imgA1P[12] = GameObject.Find ("A1P12").GetComponent<Image> ();
			//imgA1P[13] = GameObject.Find ("A1P13").GetComponent<Image> ();

			//imgY2P[0] = GameObject.Find ("Y2P0").GetComponent<Image> ();
			//imgY2P[1] = GameObject.Find ("Y2P1").GetComponent<Image> ();
			//imgY2P[2] = GameObject.Find ("Y2P2").GetComponent<Image> ();
			//imgY2P[3] = GameObject.Find ("Y2P3").GetComponent<Image> ();
			//imgY2P[4] = GameObject.Find ("Y2P4").GetComponent<Image> ();
			//imgY2P[5] = GameObject.Find ("Y2P5").GetComponent<Image> ();
			//imgY2P[6] = GameObject.Find ("Y2P6").GetComponent<Image> ();
			//imgY2P[7] = GameObject.Find ("Y2P7").GetComponent<Image> ();
			//imgY2P[8] = GameObject.Find ("Y2P8").GetComponent<Image> ();
			//imgY2P[9] = GameObject.Find ("Y2P9").GetComponent<Image> ();
			//imgY2P[10] = GameObject.Find ("Y2P10").GetComponent<Image> ();
			//imgY2P[11] = GameObject.Find ("Y2P11").GetComponent<Image> ();
			//imgY2P[12] = GameObject.Find ("Y2P12").GetComponent<Image> ();
			//imgY2P[13] = GameObject.Find ("Y2P13").GetComponent<Image> ();

			//imgXB2P[0] = GameObject.Find ("XB2P0").GetComponent<Image> ();
			//imgXB2P[1] = GameObject.Find ("XB2P1").GetComponent<Image> ();
			//imgXB2P[2] = GameObject.Find ("XB2P2").GetComponent<Image> ();
			//imgXB2P[3] = GameObject.Find ("XB2P3").GetComponent<Image> ();
			//imgXB2P[4] = GameObject.Find ("XB2P4").GetComponent<Image> ();
			//imgXB2P[5] = GameObject.Find ("XB2P5").GetComponent<Image> ();
			//imgXB2P[6] = GameObject.Find ("XB2P6").GetComponent<Image> ();
			//imgXB2P[7] = GameObject.Find ("XB2P7").GetComponent<Image> ();
			//imgXB2P[8] = GameObject.Find ("XB2P8").GetComponent<Image> ();
			//imgXB2P[9] = GameObject.Find ("XB2P9").GetComponent<Image> ();
			//imgXB2P[10] = GameObject.Find ("XB2P10").GetComponent<Image> ();
			//imgXB2P[11] = GameObject.Find ("XB2P11").GetComponent<Image> ();
			//imgXB2P[12] = GameObject.Find ("XB2P12").GetComponent<Image> ();
			//imgXB2P[13] = GameObject.Find ("XB2P13").GetComponent<Image> ();

			//imgA2P[0] = GameObject.Find ("A2P0").GetComponent<Image> ();
			//imgA2P[1] = GameObject.Find ("A2P1").GetComponent<Image> ();
			//imgA2P[2] = GameObject.Find ("A2P2").GetComponent<Image> ();
			//imgA2P[3] = GameObject.Find ("A2P3").GetComponent<Image> ();
			//imgA2P[4] = GameObject.Find ("A2P4").GetComponent<Image> ();
			//imgA2P[5] = GameObject.Find ("A2P5").GetComponent<Image> ();
			//imgA2P[6] = GameObject.Find ("A2P6").GetComponent<Image> ();
			//imgA2P[7] = GameObject.Find ("A2P7").GetComponent<Image> ();
			//imgA2P[8] = GameObject.Find ("A2P8").GetComponent<Image> ();
			//imgA2P[9] = GameObject.Find ("A2P9").GetComponent<Image> ();
			//imgA2P[10] = GameObject.Find ("A2P10").GetComponent<Image> ();
			//imgA2P[11] = GameObject.Find ("A2P11").GetComponent<Image> ();
			//imgA2P[12] = GameObject.Find ("A2P12").GetComponent<Image> ();
			//imgA2P[13] = GameObject.Find ("A2P13").GetComponent<Image> ();
			////}

		//	break;
		//default:
		//	break;
		//}
	}

	/// <summary>
	/// 他のシーン移動時に呼ばれる処理
	/// </summary>
	void OnSceneUnloaded(Scene scene){
		switch (scene.name) {
		case "Title":
			startButton = null;

			break;
		case "Game":
			// 色々初期化
			startFlag = false;
			attack1P = true;
			for(int i=0; i >= 5; i++){
				railPrefab[i] = null;
			}
			resultPanel = null;
			playMoreButton = null;
			toTitleButton = null;
			//moveCamera = null;
			//meterPOP1 = null;
			//meterPOP2 = null;
			break;
		default:
			break;
		}
	}

	/// <summary>
	/// シーン移動用
	/// </summary>
	/// <param name="value">Value.</param>
	public void SceneMove (string value) {
		SceneManager.LoadScene (value);
	}

	/// <summary>
	/// ゲーム開始用
	/// </summary>
	public void GameStart () {
		//AudioController.Play( "startclick" );
	}

	/// <summary>
	/// リズム部分の処理(1P)
	/// </summary>
	public void RhythmAttack1P () {
        // TODO:もっとまとめたい

        // 1Pの壁ドン(上)
        if (Input.GetButtonDown("Horizontal"))
        {
            RhythmAttackMethod(1, 1);
        }
        // 1Pの壁ドン(中)
        //if (Input.GetButtonDown("Middle_1P")) {
        RhythmAttackMethod (2, 2);
		//}
		// 1Pの壁ドン(下)
		//if (Input.GetButtonDown("Bottom_1P")) {
			RhythmAttackMethod (3, 3);
        //}

        RhythmAttackMethod(4, 4);

        if (!rhyzhmButtonList.Any ()) return;

		//// 2Pの壁ドン(上)
		//if (Input.GetButtonDown("Up_2P")) {
		//	RhythmDefenceMethod (1, 4);
		//}
		//// 2Pの壁ドン(中)
		//if (Input.GetButtonDown("Middle_2P")) {
		//	RhythmDefenceMethod (2, 5);
		//}
		//// 2Pの壁ドン(下)
		//if (Input.GetButtonDown("Bottom_2P")) {
		//	RhythmDefenceMethod (3, 6);
		//}
	}

	/// <summary>
	/// リズム部分の攻撃用
	/// </summary>
	public void RhythmAttackMethod (int value, int value2) {
		GameObject tmpObj;
		rhyzhmButtonList.Add (value);

		//StartCoroutine (MotionChange (value2));
		tmpObj = Instantiate (railIcon[value - 1], railPrefab[value2 - 1].transform);
		rhyzhmPrefabList.Add (tmpObj);
		switch (value) {
		case 1:
			//moveCamera.ShekeCameraRolling ();
			//AudioController.Play( "kabedon1" );
			break;
		case 2:
			//moveCamera.ShekeCameraPitching ();
			//AudioController.Play( "kabedon3" );
			break;
		case 3:
			//moveCamera.ShekeCamera ();
			//AudioController.Play( "kabedon2" );
			break;
		default:
			break;
		}
		LeadIconDecide ();
	}
	/// <summary>
	/// リズム部分の守備？用
	/// </summary>
	public void RhythmDefenceMethod (int value, int value2) {
		// リストの一番上が一致していたら削除
		if (rhyzhmButtonList [0].Equals (value)) {

			//StartCoroutine (MotionChange (value2));
			rhyzhmButtonList.RemoveAt (0);
			Destroy (rhyzhmPrefabList [0]);
			rhyzhmPrefabList.RemoveAt (0);
			switch (value) {
			case 1:
				//moveCamera.ShekeCameraRolling ();
				//AudioController.Play( "kabedon1" );
				break;
			case 2:
				//moveCamera.ShekeCameraPitching ();
				//AudioController.Play( "kabedon3" );
				break;
			case 3:
				//moveCamera.ShekeCamera ();
				//AudioController.Play( "kabedon2" );
				break;
			default:
				break;
			}
			LeadIconDecide ();
		}
		// 違ったらペナルティ
		else {
			if (value2 <= 3) {
				//playerctrl [0].DamageMine (3);
			} else {
				//playerctrl [1].DamageMine (3);
			}
		}
	}

	/// <summary>
	/// キャラクターのモーション用
	/// </summary>
	//IEnumerator MotionChange (int value) {
	//	if (value <= 3) {
	//		nImg[0].enabled = false;
	//	} else {
	//		nImg[1].enabled = false;
	//	}

	//	// TODO:ゴリ押しプログラム
	//	switch (value) {
	//	case 1:
	//		for (int i = 0; i <= 13; i+=2) {
	//			imgY1P [i].enabled = true;
	//			if (!i.Equals (0)) {
	//				imgY1P [i - 2].enabled = false;
	//			}

	//			yield return new WaitForSeconds (0.0001f);
	//		}
	//		//imgY1P [13].enabled = false;
	//		imgY1P [12].enabled = false;
	//		break;
	//	case 2:
	//		for (int i = 0; i <= 13; i+=2) {
	//			imgXB1P [i].enabled = true;
	//			if (!i.Equals (0)) {
	//				imgXB1P [i - 2].enabled = false;
	//			}

	//			yield return new WaitForSeconds (0.0001f);
	//		}
	//		//imgXB1P [13].enabled = false;
	//		imgXB1P [12].enabled = false;
	//		break;
	//	case 3:
	//		for (int i = 0; i <= 13; i+=2) {
	//			imgA1P [i].enabled = true;
	//			if (!i.Equals (0)) {
	//				imgA1P [i - 2].enabled = false;
	//			}

	//			yield return new WaitForSeconds (0.0001f);
	//		}
	//		//imgA1P [13].enabled = false;
	//		imgA1P [12].enabled = false;
	//		break;
	//	case 4:
	//		for (int i = 0; i <= 13; i+=2) {
	//			imgY2P [i].enabled = true;
	//			if (!i.Equals (0)) {
	//				imgY2P [i - 2].enabled = false;
	//			}

	//			yield return new WaitForSeconds (0.0001f);
	//		}
	//		//imgY2P [13].enabled = false;
	//		imgY2P [12].enabled = false;
	//		break;
	//	case 5:
	//		for (int i = 0; i <= 13; i+=2) {
	//			imgXB2P [i].enabled = true;
	//			if (!i.Equals (0)) {
	//				imgXB2P [i - 2].enabled = false;
	//			}

	//			yield return new WaitForSeconds (0.0001f);
	//		}
	//		//imgXB2P [13].enabled = false;
	//		imgXB2P [12].enabled = false;
	//		break;
	//	case 6:
	//		for (int i = 0; i <= 13; i+=2) {
	//			imgA2P [i].enabled = true;
	//			if (!i.Equals (0)) {
	//				imgA2P [i - 2].enabled = false;
	//			}

	//			yield return new WaitForSeconds (0.0001f);
	//		}
	//		//imgA2P [13].enabled = false;
	//		imgA2P [12].enabled = false;
	//		break;
	//	default:
	//		break;
	//	}

	//	if (value <= 3) {
	//		nImg[0].enabled = true;
	//	} else {
	//		nImg[1].enabled = true;
	//	}
	//}

	/// <summary>
	/// 一番先頭のアイコンの周りにサークルを表示する
	/// </summary>
	public void LeadIconDecide () {
		if (!rhyzhmPrefabList.Any ()) return;

		rhyzhmPrefabList [0].GetComponent<KabedonMove> ().LeadIcon ();
	}

	/// <summary>
	/// リザルト画面の可視化
	/// </summary>
	public void ResultOn () {
		startFlag = false;
		resultPanel.transform.localScale = Vector3.one;
	}

	/// <summary>
	/// リザルト画面の勝敗判定
	/// </summary>
	public void ResultWinner (bool value) {
		Text winnerText = resultPanel.transform.Find ("WinnerText").GetComponent<Text> ();
		//AudioController.Stop( "mainbgm" );
		//AudioController.Play( "gameset" );
		//AudioController.Play( "result" );
		// 1Pの勝利
		if (!value) {
			winnerText.text = "1Pの勝利！";
		}
		// 2Pの勝利
		else {
			winnerText.text = "2Pの勝利！";
		}
	}

	/// <summary>
	/// 攻守交替処理
	/// </summary>
	public void AttackChange () {
		startFlag = false;
		//AudioController.Play( "trunchange" );
		StartCoroutine (AttackChangeMethod ());
		/*
		attackChangeTimer += Time.deltaTime;

		// 5秒毎に攻守切り替え
		if (attackChangeTimer >= 5f) {
			if (attack1P) {
				attack1P = false;
			} else {
				attack1P = true;
			}
			startFlag = false;
			attackChangeTimer = 0;
			StartCoroutine (AttackChangeMethod ());
		}
		*/
	}

	/// <summary>
	/// 攻守交替時の休憩用
	/// </summary>
	IEnumerator AttackChangeMethod () {
		yield return new WaitForSeconds (.4f);
		if (attack1P) {
			attack1P = false;
			//moveCamera.MoveCameraRigthtChange ();
		} else {
			attack1P = true;
			//moveCamera.MoveCameraLeftChange ();
		}
		yield return new WaitForSeconds (.4f);
		//AudioController.Play( "my_turn" );
		startFlag = true;
		if (attack1P) {
			//Instantiate (GameManager.Instance.meter, meterPOP1.transform);
		} else {
			//Instantiate (GameManager.Instance.meter, meterPOP2.transform);
		}
	}
}