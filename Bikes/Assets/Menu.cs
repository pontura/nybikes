using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject section1;
    public GameObject section2;
    public GameObject section3;
    private Animation anim;
    public GameObject closeButton;

    void Start () {
        anim = GetComponent<Animation>();
    }
    public void Open()
    {
        closeButton.SetActive(true);
        anim.Play("on");
    }
    public void Close()
    {
        closeButton.SetActive(false);
        anim.Play("off");
    }
	public void Select(int id)
    {
        section1.SetActive(false);
        section2.SetActive(false);
        section3.SetActive(false);

        switch (id)
        {
            case 1: section1.SetActive(true); break;
            case 2: section2.SetActive(true); break;
            case 3: section3.SetActive(true); break;
        }
    }
}
