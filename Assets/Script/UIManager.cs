using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Action Create;
	private UIManager() { }
	private static UIManager _instance = null; //static���� �̱��� Ŭ���� ���� ����
	public static UIManager Instance //������Ƽ ����
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<UIManager>();

				if (_instance == null)
				{
					_instance = new GameObject().AddComponent<UIManager>();
				}
			}
			return _instance;// �ν��Ͻ��� ���� null�� �ƴ϶�� SingletonClass ������Ʈ�� ã�� _instance�� �Ҵ��մϴ�.
		}
	}
    [SerializeField]
	public Image image;
	[SerializeField]
	public TextMeshProUGUI Goldtxt;
	[SerializeField]
	public TextMeshProUGUI enemycounttxt;
	[SerializeField]
	public TextMeshProUGUI WaveCounttxt;
	[SerializeField]
	public Button CreateButton;
	[SerializeField]
	public Button RemoveButton;

    
	//public void On_Click_Create()
 //   {
	//	if(GameController.Instance.Gold >= 10 && !GameController.Instance.isBattle)
 //       {
	//		Create();
	//		GameController.Instance.Gold -= 10;
	//	}
 //   }
	//public void On_Click_Remove()
	//{
 //       if (GameController.Instance.removeCude != null && GameController.Instance.Gold >= 100)
 //       {
	//		GameController.Instance.Gold -= 100;
	//		Destroy(GameController.Instance.removeCude);
 //       }
	//}
	public void On_Click_Battle()
	{
		if (!GameController.Instance.isBattle)
		{
			GameController.Instance.CreateEnemy();
			GameController.Instance.isBattle = true;
			++GameController.Instance.Wave;
		}
	}


	public void GameOver()
    {
		image.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

}
