using UnityEngine;
using System.Collections;

public class ScreenShake : Singleton<ScreenShake> 
{

	Camera _camera ;
	internal  float shake = 0;
	float shakeAmount = 0.2f;
	float decreaseFactor = 1.0f;

	void Start()
	{
		_camera = Camera.main; 
	} 

	void Update() 
	{
		if (shake > 0) 
		{
			_camera.transform.localPosition = Random.insideUnitSphere * shakeAmount;
			_camera.transform.localPosition = new Vector3(_camera.transform.localPosition.x,_camera.transform.localPosition.y, -15.1f);

			shake -= Time.deltaTime * decreaseFactor;
		} 
		else 
		{
			shake = 0.0f;
			_camera.transform.localPosition = new Vector3(0,0,-15.1f);
		}
	}
}
