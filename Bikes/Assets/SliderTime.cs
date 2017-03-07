using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderTime : MonoBehaviour {

    public types type;
    public enum types
    {
        MANUAL,
        AUTOMATIC
    }
    public UI ui;
    public Text timeField;
    public int secs;
    public Slider slider;
    public BikesAnimation bikesAnim;
    float min = 10;
    float max =200;
    public Sprite playButton;
    public Sprite pauseButton;
    public Image buttonImage;

    void Start () {
        secs = 500;
		Invoke("SwitchMode", 0.1f);
    }
	public void SwitchMode()
    {
        if (type == types.AUTOMATIC)
        {
            type = types.MANUAL;
            buttonImage.sprite = playButton;
            bikesAnim.AutomaticStop();
        }
        else
        {
            bikesAnim.ChangeTimeline(slider.value);
            type = types.AUTOMATIC;
            buttonImage.sprite = pauseButton;
            bikesAnim.AutomaticPlay();
        }
    }
	void Update ()
    {
        switch(type)
        {
            case types.MANUAL: Manual(); break;
            case types.AUTOMATIC: Automatic(); break;
        }
    }
    void Manual()
    {
        float _sec = (float)(slider.value * 86400);
        int new_secs = (int)(_sec);
        if (secs == new_secs) return;
        secs = new_secs;
        bikesAnim.ChangeTimeline(slider.value);
        SetPeople(_sec);        
    }
    void Automatic()
    {
        float num = ui.bikesAnim.boysAnim["bikes"].normalizedTime;
        num -= Mathf.Floor(num);
        slider.value = num;
        float _sec = (float)(slider.value * 86400);

        int new_secs = (int)(_sec);
        if (secs == new_secs) return;
        secs = new_secs;

        SetPeople(_sec);
    }
    void SetPeople(float _sec)
    {
        float totalPeople = (_sec / 3600);

        if (totalPeople > 12)
            totalPeople = 24 - totalPeople;
        totalPeople += (max * totalPeople);
        int tp = (int)(totalPeople) + (int)min;
        ui.SetTotalPeople(tp * 2);

		string hora = "";
		if (secs < 43200)
			hora = FloatToTime (secs) + " AM";
		else {
			if (secs > 46800)
				secs -= 43200;			
			hora = FloatToTime (secs) + " PM";
		}
		timeField.text = "Tuesday, March 21 2017, " + hora + ", NEW YORK CITY";
    }
    public string FloatToTime(int counter)
    {
        int hours = counter / 3600;
        int minutes = (counter % 3600) / 60;
        
        return string.Format("{0:00}:{1:00}", hours, minutes);
    
    }
}
