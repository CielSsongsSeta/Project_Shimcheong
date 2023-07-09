using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pointer_soban : MonoBehaviour
{
    public bool bool_isSoban = false;
    public GameObject images;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Down Event
        Debug.Log("Touch! Soban!!!!");
    }

    public void Update()
	{
        

	}

    public void OnMouseDown()
	{
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ÀÌ°Ç Touch! Soban!!!!");
            bool_isSoban = true;
            if (bool_isSoban = true)
            {
                //images.SetActive(true);
                images.SetActive(false);
            }
            else
            {
                images.SetActive(true);
                //images.SetActive(false);
                bool_isSoban = false;
            }
        }
    }
}
