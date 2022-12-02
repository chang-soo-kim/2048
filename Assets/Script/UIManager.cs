using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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
	


	public void GameOver()
    {
		image.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

}
