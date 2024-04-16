using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Cysharp.Threading.Tasks;
using System;
class TestController : MonoBehaviour
{

	public Canvas selectActionPanel;
	private SelectActionPanel selectActionPanelComponent;
	private CancellationToken systemCancellationToken;

	void Start()
	{
		selectActionPanelComponent = selectActionPanel.GetComponent<SelectActionPanel>();

		selectAction();
	}

	private async void selectAction()
	{
		systemCancellationToken = this.GetCancellationTokenOnDestroy();
		try
		{
			selectActionPanel.enabled = true;
			await selectActionPanelComponent.AwaitAnyButtonClickedAsync(systemCancellationToken);
			selectActionPanel.enabled = false;
		}
		catch (OperationCanceledException ex)
		{
			// https://learn.microsoft.com/ja-jp/dotnet/api/system.operationcanceledexception?view=net-8.0
			// しかし別にException使わないんだけどな
		}
	}
}