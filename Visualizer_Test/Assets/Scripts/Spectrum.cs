using UnityEngine;
using System.Collections;

public class Spectrum : MonoBehaviour {

	public GameObject cubePrefab;
	public int numberOfObjects;
	public GameObject[] cubes;
	public int spectrumScale = 400;
	public float cubeSpacing = 2.0f;

	// Use this for initialization
	void Start () 
	{
		cubes = new GameObject[numberOfObjects];

		for (int i = 0; i < numberOfObjects; i++) 
		{
			cubes[i] = Instantiate (cubePrefab, new Vector3 (i * cubeSpacing, 0, 0), Quaternion.identity) as GameObject;
		}


	}


	
	// Update is called once per frame
	void Update () 
	{
		float[] samples = new float[1024]; 
		AudioListener.GetSpectrumData (samples, 0, FFTWindow.Hamming);

		for (int i = 0; i < numberOfObjects; i++) 
		{
			Vector3 previousScale = cubes[i].gameObject.transform.localScale;
			previousScale.y = Mathf.Lerp (previousScale.y, samples[i] * spectrumScale, Time.deltaTime);
			cubes[i].transform.localScale = previousScale;
		}
	}
}
