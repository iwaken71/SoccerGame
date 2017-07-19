using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
	Camera mainCamera;

	[SerializeField] GameObject leftWall,rightWall;

	void Awake ()
	{
		mainCamera = Camera.main;

	}

	// Use this for initialization
	void Start ()
	{
		leftWall.transform.position = getScreenTopLeft();
		rightWall.transform.position = getScreenBottomRight();

		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private Vector3 getScreenTopLeft ()
	{
		// 画面の左上を取得
		Vector3 topLeft = mainCamera.ScreenToWorldPoint (Vector3.zero);
		// 上下反転させる
		topLeft.Scale (new Vector3 (1f, -1f, 0));
		return topLeft;
	}

	private Vector3 getScreenBottomRight ()
	{
		// 画面の右下を取得
		Vector3 bottomRight = mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0.0f));
		// 上下反転させる
		bottomRight.Scale (new Vector3 (1f, -1f, 0));
		return bottomRight;
	}
}
