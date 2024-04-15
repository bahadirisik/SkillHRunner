using UnityEngine;

public class Magnet : CollectableBoosts
{
	public override void Intreact(Transform player)
	{
		base.Intreact(player);
		player.GetComponent<PlayerBoost>().ToggleMagnet(true);
		gameObject.SetActive(false);
	}
}
