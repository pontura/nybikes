using UnityEngine;
using System.Collections;

public class BikesAnimation : MonoBehaviour
{

    public types type;
    public enum types
    {
        PEOPLE,
        MALE,
        FEMALE
    }
    public Animation boysAnim;
    Animation girlsAnim;

    public GameObject Boys;
    public GameObject Girls;

    public Color boysColor;
    public Color girlsColor;
    public Color peopleColor;

    void Start()
    {
        boysAnim = Boys.GetComponent<Animation>();
        girlsAnim = Girls.GetComponent<Animation>();
        Events.ChangeType += ChangeType;
        ChangeType(types.PEOPLE);
    }
    void OnDestroy()
    {
        Events.ChangeType -= ChangeType;
    }
    void ChangeType(types type)
    {
        this.type = type;
        switch (type)
        {
            case types.PEOPLE:
                SetState(Girls, true);
                SetState(Boys, true);
                ChangeColor(Boys, peopleColor);
                ChangeColor(Girls, peopleColor);
                break;
            case types.MALE:
                ChangeColor(Boys, boysColor);
                SetState(Girls, false);
                SetState(Boys, true);
                break;
            case types.FEMALE:
                ChangeColor(Girls, girlsColor);
                SetState(Girls, true);
                SetState(Boys, false);
                break;
        }
        if(!playAutomatic)
            ChangeTimeline(value);
    }
    void SetState(GameObject go, bool isActive)
    {
        if (isActive)
            go.transform.localPosition = Vector3.zero;
        else
            go.transform.localPosition = new Vector3(100000, 0, 0);
    }
    void ChangeColor(GameObject container, Color color)
    {
        foreach (SpriteRenderer sr in container.GetComponentsInChildren<SpriteRenderer>())
        {
            Color oldColor = sr.color;
            color.a = oldColor.a;
            sr.color = color;
        }
    }
    public float value;
    public void ChangeTimeline(float value)
    {
        this.value = value;
        switch (type)
        {

            case types.MALE:
                boysAnim["bikes"].normalizedTime = value;
                boysAnim.Play();
                boysAnim.Sample();
                boysAnim.Stop();
                break;
            case types.FEMALE:
                girlsAnim["bikes"].normalizedTime = value;
                girlsAnim.Play();
                girlsAnim.Sample();
                girlsAnim.Stop();
                break;
            default:
                boysAnim["bikes"].normalizedTime = value;
                boysAnim.Play();
                boysAnim.Sample();
                boysAnim.Stop();
                girlsAnim["bikes"].normalizedTime = value;
                girlsAnim.Play();
                girlsAnim.Sample();
                girlsAnim.Stop();
                break;
        }
    }
    bool playAutomatic;
    public void AutomaticPlay()
    {
        playAutomatic = true;
        boysAnim.Play();
        girlsAnim.Play();
    }
    public void AutomaticStop()
    {
        playAutomatic = false;
    }
}
