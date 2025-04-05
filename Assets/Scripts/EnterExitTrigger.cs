using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class EnterExitTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent triggerEnter;
    [SerializeField] private UnityEvent triggerExit;

	[SerializeField] private bool checkTag;
	[SerializeField] private string tagToCheck;

	private void Awake()
	{
		Collider attachedCollider = GetComponent<Collider>();

		if (attachedCollider != null)
		{
			attachedCollider.isTrigger = true;
		}
		else
		{
			Debug.LogError("EnterExitTrigger script cannot find any Collider component on gameObject.name = " + gameObject.name);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("OnTriggerEnter() in EnterExitTrigger.cs in gameObject.name = " + gameObject.name + " - entering object = " + other.gameObject.name);

		if (checkTag && tagToCheck != other.gameObject.tag)
		{
			return;
		}

		triggerEnter.Invoke();
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log("OnTriggerExit() in EnterExitTrigger.cs in gameObject.name = " + gameObject.name + " - exiting object = " + other.gameObject.name);

		if (checkTag && tagToCheck != other.gameObject.tag)
		{
			return;
		}

		triggerExit.Invoke();
	}
}
