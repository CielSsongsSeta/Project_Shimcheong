using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pointer_botjim : MonoBehaviour
{
    public bool bool_isBotjim = false;
    public GameObject images;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Down Event
        Debug.Log("Touch! Botjim!!!!");
    }

    public void Update()
	{
        

	}

    public void OnMouseDown()
	{
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ÀÌ°Ç Touch! Botjim!!!!");
            bool_isBotjim = true;
            if (bool_isBotjim = true)
            {
                images.SetActive(true);
            }
            else
            {
                images.SetActive(false);
                bool_isBotjim = false;
            }
        }
    }
}
