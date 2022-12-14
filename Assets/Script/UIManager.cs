using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	private UIManager() { }
	private static UIManager _instance = null; //static으로 싱글톤 클래스 유일 선언
	public static UIManager Instance //프로퍼티 선언
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
			return _instance;// 인스턴스의 값이 null이 아니라면 SingletonClass 오브젝트를 찾아 _instance에 할당합니다.
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
	public Button RemoveButton;
	[SerializeField]
	public Button BattleButton;


    public void on_click_remove()
    {
        if (GameController.Instance.removeCude != null && GameController.Instance.Gold >= 100)
        {
			GameController.Instance.Gold -= 100;
            Destroy(GameController.Instance.removeCude);
        }
    }
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
