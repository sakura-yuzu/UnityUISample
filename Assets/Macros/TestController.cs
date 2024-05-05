using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Cysharp.Threading.Tasks;
using System;
class TestController : MonoBehaviour
{

	public GameObject selectActionPanel;
	public GameObject selectSkillPanel;
	public GameObject selectItemPanel;
	public GameObject selectTargetEnemyPanel;
	public GameObject selectTargetAllyPanel;
	// public GameObject selectActionPanel;
	private SelectActionPanel selectActionPanelComponent;
	private SelectSkillPanel selectSkillPanelComponent;
	private CancellationToken systemCancellationToken;

	void Start()
	{
		// selectActionPanelComponent = selectActionPanel.GetComponent<SelectActionPanel>();
		// selectSkillPanelComponent = selectSkillPanel.GetComponent<SelectSkillPanel>();

		// selectAction();
	}

	public void receiveAction(){
		Debug.Log("レシーブ");
		string action = selectActionPanel.GetComponent<ToggleGroupInherit>().getValue();
		string skill = selectSkillPanel.GetComponent<ToggleGroupInherit>()?.getValue();
		string item = selectItemPanel.GetComponent<ToggleGroupInherit>()?.getValue();
		string enemy = selectTargetEnemyPanel.GetComponent<ToggleGroupInherit>()?.getValue();
		string ally = selectTargetAllyPanel.GetComponent<ToggleGroupInherit>()?.getValue();
		Debug.Log("action: " + action);
		Debug.Log("skill: " + skill);
		Debug.Log("item: " + item);
		Debug.Log("enemy: " + enemy);
		Debug.Log("ally: " + ally);
	}
}