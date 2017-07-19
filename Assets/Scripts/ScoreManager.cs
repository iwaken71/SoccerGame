using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

public class ScoreManager : MonoBehaviour {


	public static ScoreManager Instance = null;

	public IntReactiveProperty Score {get; private set;}

	[SerializeField]
	TextMeshProUGUI scoreLabel;





	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
			Init();
		} else {
			Destroy(this.gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		ResetScore();

	}

	void Init(){
		Score = new IntReactiveProperty(0);
		Score.Subscribe(s => {
			scoreLabel.text = s.ToString();
		}).AddTo(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ResetScore(){
		Score.Value = 0;
	}


	public void AddScore(){
		Score.Value += 1;
	}


}
