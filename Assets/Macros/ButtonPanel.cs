using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Threading;
using Cysharp.Threading.Tasks;
abstract class ButtonPanel : MonoBehaviour
{
	public Button[] buttons;

	public bool cancellable = true;
	public EventSystem eventSystem;
	public GameObject firstSelectedButton;
	private CancellationToken playerCancellationToken;
	protected CancellationTokenSource linkedCancellationTokenSource;
	public abstract UniTask<int> AwaitAnyButtonClickedAsync(CancellationToken cancellationToken);
	public async UniTask<int> AwaitAnyButtonClickOrCancelAsync(CancellationToken systemCancellationToken)
	{
		playerCancellationToken = new CancellationTokenSource().Token;
		linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource (systemCancellationToken, playerCancellationToken);

		eventSystem.SetSelectedGameObject(firstSelectedButton);

		return await AwaitAnyButtonClickedAsync(linkedCancellationTokenSource.Token);
	}
	void Update()
	{
		if (cancellable && (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel")))
		{
			Debug.Log("キャンセル");
			Debug.Log("[" + this.GetType().FullName + "] " + System.Reflection.MethodBase.GetCurrentMethod().Name);
			Debug.Log(linkedCancellationTokenSource);
			linkedCancellationTokenSource?.Cancel();
			linkedCancellationTokenSource = null;
		}

		// https://hakonebox.hatenablog.com/entry/2018/04/15/125152
		float dph = Input.GetAxis ("D_Pad_H");
		float dpv = Input.GetAxis ("D_Pad_V");
		if(( dph != 0 ) || ( dpv != 0 )){
				Debug.Log ("D Pad:"+dph+","+dpv );
		}
	}
}