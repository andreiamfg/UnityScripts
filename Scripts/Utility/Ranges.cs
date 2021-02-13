using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntRange
{
	public int Min;
	public int Max;

	public IntRange(int min, int max)
	{
		Min = min;
		Max = max;
	}

	public int GetRandom()
	{
		return Random.Range(Min, Max +1 );
	}
}

[System.Serializable]
public class FloatRange
{
	public float Min;
	public float Max;

	public FloatRange(float min, float max)
	{
		Min = min;
		Max = max;
	}

	public float GetRandom()
	{
		return Random.Range(Min, Max);
	}
}

[System.Serializable]
public class Vector3Range
{
	public Vector3 Min;
	public Vector3 Max;

	public Vector3Range(Vector3 min, Vector3 max)
	{
		Min = min;
		Max = max;
	}

	public Vector3 GetRandom()
	{
		return new Vector3(
			Random.Range(Min.x, Max.x),
			Random.Range(Min.y, Max.y),
			Random.Range(Min.z, Max.z)
		);
	}
}
