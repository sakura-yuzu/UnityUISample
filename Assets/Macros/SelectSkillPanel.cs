using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;
class SelectSkillPanel : ButtonPanel
{
	public override async UniTask<int> AwaitAnyButtonClickedAsync(CancellationToken cancellationToken)
	{
		Debug.Log(linkedCancellationTokenSource);
		return await UniTask.WhenAny(buttons
			.Select(button => button.OnClickAsync(linkedCancellationTokenSource.Token)));
	}
}