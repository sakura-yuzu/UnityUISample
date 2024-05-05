using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/**
*
* 
*/
class ButtonWithValue : MonoBehaviour, ISelectHandler, IDeselectHandler
{
	public string value;
	public GameObject ToggleGroup;
	// public Image backgroundImage;
	// public Sprite selectedImage;
	// public Sprite deselectedImage;
	public BackgroundManager backgroundManager;
	// private ManagerContainer managerContainer;
	// private SoundManager soundManager;

	// public ButtonWithValue(ManagerContainer _managerContainer){
		// managerContainer = _managerContainer;
		// soundManager = managerContainer.soundManager;
	// }

	public void OnSelect(BaseEventData e){
		// backgroundManager.select();
		// backgroundImage = selectedImage;
		// soundManager.Play();
	}

	public void OnDeselect(BaseEventData e){
		// backgroundManager.deselect();
		// backgroundImage = deselectedImage;
	}
}