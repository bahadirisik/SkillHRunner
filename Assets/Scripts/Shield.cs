using UnityEngine;

public class Shield : CollectableBoosts
{
	public override void Intreact(Transform player)
	{
		base.Intreact(player);
		player.GetComponent<PlayerBoost>().ToggleShield(true);
		gameObject.SetActive(false);
	}
}
