using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
	Dictionary<int, string[]> DialogData;

	void Awake()
	{
		DialogData = new Dictionary<int, string[]>();
		GenerateData();
	}

	void GenerateData()
	{
		DialogData.Add(1000, new string[] { "?이것은 테스트지?","그럼 테스트지 테스트야 테스트군 테스트똻"});
	}

	public string GetTalk(int id, int idx_Dialog)
	{
		return DialogData[id][idx_Dialog];
	}
}
