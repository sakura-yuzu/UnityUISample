using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class MapController : MonoBehaviour
{
	public GameObject firstDisplayedMap;
	private GameObject displayedMap;
	public GameObject[] maps;
	private int visibleMapIndex;
	private float pre_vert_r = 0.0f;
	RectTransform rectTransform;
	void Awake()
	{
		// FPSがなぜか1000とか出てたので固定する
		// Vsync Count を 0にすることにより、FPS を固定できるようになる
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
	}
	// Start is called before the first frame update
	void Start()
	{
		displayedMap = firstDisplayedMap;
		visibleMapIndex = 1;
	}

	// Update is called once per frame
	void Update()
	{
		// 右スティック上入力
		float vert_r = Input.GetAxis("RightStick_V");
		if ((vert_r < 0 && pre_vert_r == 0.0f))
		{
			expansion();
		}
		// 右スティック下入力
		if ((vert_r > 0 && pre_vert_r == 0.0f))
		{
			reduction();
		}
		pre_vert_r = vert_r;
	}

	// 拡大
	private async UniTask expansion()
	{
		if (visibleMapIndex < 1)
		{
			return;
		}

		visibleMapIndex--;
		GameObject nextMap = maps[visibleMapIndex];
		nextMap.SetActive(true);
		nextMap.GetComponent<RectTransform>().localScale = new Vector3(1, 1);

		rectTransform = displayedMap.GetComponent<RectTransform>();
		await rectTransform.DOScale(
				new Vector3(4f, 4f),     // 終了時点のScale
				0.3f                        // アニメーション時間
		).AsyncWaitForCompletion();

		displayedMap.SetActive(false);
		displayedMap = nextMap;
	}

	// 縮小
	private async UniTask reduction()
	{
		if (visibleMapIndex > 1)
		{
			return;
		}

		visibleMapIndex++;
		GameObject nextMap = maps[visibleMapIndex];
		nextMap.GetComponent<RectTransform>().localScale = new Vector3(1, 1);

		rectTransform = displayedMap.GetComponent<RectTransform>();
		await rectTransform.DOScale(
				new Vector3(0.25f, 0.25f),     // 終了時点のScale
				0.3f                        // アニメーション時間
		).AsyncWaitForCompletion();

		nextMap.SetActive(true);
		displayedMap.SetActive(false);
		displayedMap = nextMap;
	}
}
