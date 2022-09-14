using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSwipe : MonoBehaviour
{

	public GameObject Canvas;
	[SerializeField]
	private float swipeDistance = 50.0f;
	private float startTouchX;              // ��ġ ���� ��ġ
	private float endTouchX;                    // ��ġ ���� ��ġ
	private bool isSwipeMode = false;       // ���� Swipe�� �ǰ� �ִ��� üũ
	public GameObject OptionCanvas;
	public GameObject AchieveCanvas;

	private void Update()
	{
		UpdateInput();


	}

	private void UpdateInput()
	{
		// ���� Swipe�� �������̸� ��ġ �Ұ�
		if (isSwipeMode == true) return;

#if UNITY_EDITOR
		// ���콺 ���� ��ư�� ������ �� 1ȸ
		if (Input.GetMouseButtonDown(0))
		{
			// ��ġ ���� ���� (Swipe ���� ����)
			startTouchX = Input.mousePosition.x;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			// ��ġ ���� ���� (Swipe ���� ����)
			endTouchX = Input.mousePosition.x;

			UpdateSwipe();
		}
#endif

#if UNITY_ANDROID
		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				// ��ġ ���� ���� (Swipe ���� ����)
				startTouchX = touch.position.x;
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				// ��ġ ���� ���� (Swipe ���� ����)
				endTouchX = touch.position.x;

				UpdateSwipe();
			}
		}
#endif

#if UNITY_STANDALONE_WIN
		// ���콺 ���� ��ư�� ������ �� 1ȸ
		if (Input.GetMouseButtonDown(0))
		{
			// ��ġ ���� ���� (Swipe ���� ����)
			startTouchX = Input.mousePosition.x;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			// ��ġ ���� ���� (Swipe ���� ����)
			endTouchX = Input.mousePosition.x;

			UpdateSwipe();
		}
#endif
	}

	private void UpdateSwipe()
	{

		// Swipe ����
		bool isLeft = startTouchX < endTouchX ? true : false;
		bool isRight = startTouchX > endTouchX ? true : false;


		// �ʹ� ���� �Ÿ��� �������� ���� Swipe X
		if (Mathf.Abs(startTouchX - endTouchX) < swipeDistance)
		{
			isLeft = false;
			isRight = false;
		}


		if (AchieveCanvas.activeSelf == false && OptionCanvas.activeSelf == false)
		{
			if (startTouchX > Screen.width / 1.25f && isRight == true)
			{
				Canvas.GetComponent<OptionTrigger>().Achieve_Btn();
				Handheld.Vibrate();
			}

			else if (startTouchX < Screen.width / 8f && isLeft == true)
			{
				Canvas.GetComponent<OptionTrigger>().Option_Btn();
				Handheld.Vibrate();
			}
		}

		if (AchieveCanvas.activeSelf == true)
		{
			if (isLeft == true)
			{
				Canvas.GetComponent<OptionTrigger>().AchieveClose_Btn();
				Handheld.Vibrate();
			}
		}

		if (OptionCanvas.activeSelf == true)
		{
			if (isRight == true)
			{
				Canvas.GetComponent<OptionTrigger>().OptionClose_Btn();
				Handheld.Vibrate();
			}
		}


		// �̵� ������ ������ ��

		/*if ((startTouchX < Screen.width / 8f))
        {
			if (isLeft == true && AchieveCanvas.activeSelf == false)
			{
				Canvas.GetComponent<OptionTrigger>().Option_Btn();
			}
			else if (isLeft == true && AchieveCanvas.activeSelf == true)
			{
				Canvas.GetComponent<OptionTrigger>().AchieveClose_Btn();
				
			}
		}
			
			// �̵� ������ �������� ��
		else if ((startTouchX > Screen.width / 1.25f))
		{
			if (isRight == true && OptionCanvas.activeSelf == false)
			{
				Canvas.GetComponent<OptionTrigger>().Achieve_Btn();
			}
			else if (isRight == true && OptionCanvas.activeSelf == true)
			{
				Canvas.GetComponent<OptionTrigger>().OptionClose_Btn();
			}

		}*/
	}
}