using UnityEngine;

public class Magnet : CollectableBoosts
{
	public override void Intreact(Transform player)
	{
		base.Intreact(player);
		//player.GetComponent<PlayerBoost>().ToggleMagnet(true);
		PlayerBoost.Instance.ToggleMagnet(true);
		gameObject.SetActive(false);
	}
}
