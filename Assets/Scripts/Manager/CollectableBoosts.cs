using UnityEngine;

public abstract class CollectableBoosts : MonoBehaviour, IIntreactable
{
	public virtual void Intreact(Transform player)
	{
		AudioManager.Instance.Play("Boost");
	}
}
