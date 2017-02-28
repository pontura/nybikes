using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    public Slider zoomSlider;
    public MainCameraController mainCameraController;
    public Text CyclingField;
    public Text PeopleQtyField;
    public BikesAnimation bikesAnim;

	void Start () {
	
	}
	void Update () {
        CheckZoomValue();
    }

    private float lastZoomSliderValue;
    void CheckZoomValue()
    {
        if (zoomSlider.value == lastZoomSliderValue) return;
        lastZoomSliderValue = zoomSlider.value;
        mainCameraController.SetNewZoomValue(lastZoomSliderValue);
    }
    public void SwitchPeople()
    {
        switch (bikesAnim.type)
        {
            case BikesAnimation.types.PEOPLE:
                CyclingField.text = "MEN";
                Events.ChangeType(BikesAnimation.types.MALE);
                break;
            case BikesAnimation.types.MALE:
				CyclingField.text = "WOMEN";
                Events.ChangeType(BikesAnimation.types.FEMALE);
                break;
            case BikesAnimation.types.FEMALE:
                CyclingField.text = "PEOPLE";
                Events.ChangeType(BikesAnimation.types.PEOPLE);
                break;
        }
        SetTotalPeople(totalPeople);
    }
    public int totalPeople;
    public void SetTotalPeople(int total)
    {
        totalPeople = total;
        float totalToField = total;
        switch (bikesAnim.type)
        {
            case BikesAnimation.types.MALE:
                totalToField = (float)totalPeople / 1.5f;
                break;
            case BikesAnimation.types.FEMALE:
                totalToField = (float)totalPeople / 2f;
                break;
        }
        PeopleQtyField.text = ((int)totalToField).ToString();
    }
}
