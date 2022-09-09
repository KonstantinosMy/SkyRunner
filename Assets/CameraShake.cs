using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount;
	public float decreaseFactor;
	public bool canShake;
	Vector3 originalPos;

	public Image redImage;
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (canShake)
        {
			if (shakeDuration > 0)
			{
				camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

				shakeDuration -= Time.deltaTime * decreaseFactor;
			}
			else
			{
				shakeDuration = 0f;
				camTransform.localPosition = originalPos;
				canShake = false;
				redImage.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
			}
		}
	}

    private void Start()
    {
		canShake = false;
	}
    public void shakeTheCamera()
    {
		canShake = true;
		
    }
}