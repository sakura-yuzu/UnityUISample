using UnityEngine;
using UnityEngine.UI;
class BackgroundManager : MonoBehaviour
{
	public Sprite selectedImage;
	public Sprite deselectedImage;
	public GameObject targetObject;

	// public void setData(Sprite _selectedImage, Sprite _deselectedImage, GameObject _targetObject){
	// 	this.selectedImage = _selectedImage;
	// 	this.deselectedImage = _deselectedImage;
	// 	this.targetObject = _targetObject;

	// 	targetObject.GetComponent<Image>().sprite = deselectedImage;
	// }

	public void select(){
		Image image = targetObject.GetComponent<Image>();
		image.sprite = selectedImage;
	}

	public void deselect(){
		Image image = targetObject.GetComponent<Image>();
		image.sprite = deselectedImage;
	}
}