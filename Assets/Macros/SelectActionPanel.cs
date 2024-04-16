using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
class SelectActionPanel : ButtonPanel
{
	// public Canvas selectTargetPanel;
	public Canvas selectSkillPanel;
	private SelectSkillPanel selectSkillPanelComponent;
	public override async UniTask<int> AwaitAnyButtonClickedAsync(CancellationToken cancellationToken)
	{
		selectSkillPanelComponent = selectSkillPanel.GetComponent<SelectSkillPanel>();
		int index = await UniTask.WhenAny(buttons
			.Select(button => button.OnClickAsync(cancellationToken)));
		cancellable = false;
		switch (index)
		{
			case 0:
				// await selectActionPanelComponent.AwaitAnyButtonClickOrCancelAsync(cancellationToken);
				break;
			case 1:
				selectSkillPanel.enabled = true;
				index = await selectSkillPanelComponent.AwaitAnyButtonClickOrCancelAsync(cancellationToken);
				break;
				// case 2:
				// 	// await selectActionPanelComponent.AwaitAnyButtonClickOrCancelAsync(cancellationToken);
				// 	break;
		}
		Debug.Log($"index: {index}");
		return index;
	}
}