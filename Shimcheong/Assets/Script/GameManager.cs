using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 하나씩 추가하자
    public bool bool_isAction;
    public GameObject scanObject;
    public Text dialogText;
    public DialogManager dialogManager;
    public int dialogIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action(GameObject scan_obj)
	{
        if (bool_isAction) // exit action
		{
            bool_isAction = false;
		}
		else
		{
            bool_isAction = true;
            scanObject = scan_obj;
            objdata obj_Data = scanObject.GetComponent<objdata>();
            Dialog(obj_Data.id, obj_Data.bool_isNPC);

        }
	}

    void Dialog(int id, bool bool_isNPC)
	{
        string dialogData = dialogManager.GetTalk(id, dialogIndex);

        if(bool_isNPC)
		{
            dialogText.text = dialogData;

        }

		else
		{
            dialogText.text = dialogData;
        }

    }
}
