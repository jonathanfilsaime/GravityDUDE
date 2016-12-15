using UnityEngine;
using System.Collections;

/**
 * this class creates the level 
 * places the blocks 
 * places the coins
 * @Author Jonathan Fils-Aime
 */

public class WorldController : MonoBehaviour {
	[HideInInspector]
	public Vector3 flipAxis;
	public int limit;

	GameObject block;
	GameObject coins;
    GameObject triggerZone;

    public Material blockMaterial;
    public Material coinMaterial;

	private Vector3[] blockArrayBottom = new Vector3[]
	{
		new Vector3(1,0),
		new Vector3(2,0),
		new Vector3(3,0),
		new Vector3(4,0),
		new Vector3(5,0),
		new Vector3(6,0),new Vector3(6,1),
		new Vector3(7,0),new Vector3(7,1),new Vector3(7,2),
		new Vector3(8,0),new Vector3(8,1),
		new Vector3(9,0),
		new Vector3(10,0),
		new Vector3(11,0),
		new Vector3(12,0),
		new Vector3(13,0),
		new Vector3(14,0),
		new Vector3(15,0),
		new Vector3(16,0),
		new Vector3(17,0),
		new Vector3(18,0),
		new Vector3(19,0),new Vector3(19,1),
		new Vector3(20,0),new Vector3(20,1),new Vector3(20,2),
		new Vector3(21,0),new Vector3(21,1),
		new Vector3(22,0),
		new Vector3(23,0),
		new Vector3(24,0),
		new Vector3(25,0),
		new Vector3(26,0),
		new Vector3(27,0),
		new Vector3(28,0),
		new Vector3(29,0),
		new Vector3(30,0),
		new Vector3(31,0),
		new Vector3(32,0,100),
		new Vector3(33,0,100),
		new Vector3(34,0,100),
		new Vector3(35,0),
		new Vector3(36,0),
		new Vector3(37,0),
		new Vector3(38,0),
		new Vector3(39,0,100),
		new Vector3(40,0,100),
		new Vector3(41,0,100),
		new Vector3(42,0),
		new Vector3(43,0),
		new Vector3(44,0),
		new Vector3(45,0),
		new Vector3(46,0,100),
		new Vector3(47,0,100),
		new Vector3(48,0,100),
		new Vector3(49,0),
		new Vector3(50,0),
		new Vector3(51,0),
		new Vector3(52,0),new Vector3(52,1),new Vector3(52,2),new Vector3(52,3),
		new Vector3(53,0),
		new Vector3(54,0),
		new Vector3(55,0),
		new Vector3(56,0),
		new Vector3(57,0),
		new Vector3(58,0),
		new Vector3(59,0),
		new Vector3(60,0),
		new Vector3(61,0),
		new Vector3(62,0),new Vector3(62,1),new Vector3(62,2),new Vector3(62,3),
		new Vector3(63,0),
		new Vector3(64,0),
		new Vector3(65,0),
		new Vector3(66,0),
		new Vector3(67,0),
		new Vector3(68,0),
		new Vector3(69,0),
		new Vector3(70,0),
		new Vector3(71,0),
		new Vector3(72,0),new Vector3(72,1),new Vector3(72,2),new Vector3(72,3),
		new Vector3(73,0),
		new Vector3(74,0),
		new Vector3(75,0),
		new Vector3(76,0),
		new Vector3(77,0),
		new Vector3(78,0),
		new Vector3(79,0),
		new Vector3(80,0),
		new Vector3(81,0,100),
		new Vector3(82,0,100),
		new Vector3(83,0,100),
		new Vector3(84,0),
		new Vector3(85,0),
		new Vector3(86,0),
		new Vector3(87,0),
		new Vector3(88,0,100),
		new Vector3(89,0,100),
		new Vector3(90,0,100),
		new Vector3(91,0),
		new Vector3(92,0),
		new Vector3(93,0),
		new Vector3(94,0),
		new Vector3(95,0,100),
		new Vector3(96,0,100),
		new Vector3(97,0,100),
		new Vector3(98,0),
		new Vector3(99,0),
		new Vector3(100,0),

	};

	private Vector3[] blockArrayTop = new Vector3[]
	{
		new Vector3(1,0+6),
		new Vector3(2,0+6),
		new Vector3(3,0+6),
		new Vector3(4,0+6),
		new Vector3(5,0+6),
		new Vector3(6,0+6),
		new Vector3(7,0+6),
		new Vector3(8,0+6),
		new Vector3(9,0+6),
		new Vector3(10,0+6),
		new Vector3(11,0+6),
		new Vector3(12,0+6),
		new Vector3(13,0+6),new Vector3(13,0+5),
		new Vector3(14,0+6),new Vector3(14,0+5),new Vector3(14,0+4),
		new Vector3(15,0+6),new Vector3(15,0+5),
		new Vector3(16,0+6),
		new Vector3(17,0+6),
		new Vector3(18,0+6),
		new Vector3(19,0+6),
		new Vector3(20,0+6),
		new Vector3(21,0+6),
		new Vector3(22,0+6),
		new Vector3(23,0+6),
		new Vector3(24,0+6),
		new Vector3(25,0+6),
		new Vector3(26,0+6),new Vector3(26,0+5),
		new Vector3(27,0+6),new Vector3(27,0+5),new Vector3(27,0+4),
		new Vector3(28,0+6),new Vector3(28,0+5),
		new Vector3(29,0+6,100),
		new Vector3(30,0+6,100),
		new Vector3(31,0+6,100),
		new Vector3(32,0+6),
		new Vector3(33,0+6),
		new Vector3(34,0+6),
		new Vector3(35,0+6),
		new Vector3(36,0+6,100),
		new Vector3(37,0+6,100),
		new Vector3(38,0+6,100),
		new Vector3(39,0+6),
		new Vector3(40,0+6),
		new Vector3(41,0+6),
		new Vector3(42,0+6),
		new Vector3(43,0+6,100),
		new Vector3(44,0+6,100),
		new Vector3(45,0+6,100),
		new Vector3(46,0+6),
		new Vector3(47,0+6),
		new Vector3(48,0+6),
		new Vector3(49,0+6),
		new Vector3(50,0+6),
		new Vector3(51,0+6),
		new Vector3(52,0+6),
		new Vector3(53,0+6),
		new Vector3(54,0+6),
		new Vector3(55,0+6),
		new Vector3(56,0+6),
		new Vector3(57,0+6),new Vector3(57,5),new Vector3(57,4),new Vector3(57,3),
		new Vector3(58,0+6),
		new Vector3(59,0+6),
		new Vector3(60,0+6),
		new Vector3(61,0+6),
		new Vector3(62,0+6),
		new Vector3(63,0+6),
		new Vector3(64,0+6),
		new Vector3(65,0+6),
		new Vector3(66,0+6),
		new Vector3(67,0+6),new Vector3(67,5),new Vector3(67,4),new Vector3(67,3),
		new Vector3(68,0+6),
		new Vector3(69,0+6),
		new Vector3(70,0+6),
		new Vector3(71,0+6),
		new Vector3(72,0+6),
		new Vector3(73,0+6),
		new Vector3(74,0+6),
		new Vector3(75,0+6),new Vector3(75,5),
		new Vector3(76,0+6),new Vector3(76,5),new Vector3(76,4),
		new Vector3(77,0+6),new Vector3(77,5),
		new Vector3(78,0+6,100),
		new Vector3(79,0+6,100),
		new Vector3(80,0+6,100),
		new Vector3(81,0+6),
		new Vector3(82,0+6),
		new Vector3(83,0+6),
		new Vector3(84,0+6),
		new Vector3(85,0+6,100),
		new Vector3(86,0+6,100),
		new Vector3(87,0+6,100),
		new Vector3(88,0+6),
		new Vector3(89,0+6),
		new Vector3(90,0+6),
		new Vector3(91,0+6),
		new Vector3(92,0+6,100),
		new Vector3(93,0+6,100),
		new Vector3(94,0+6,100),
		new Vector3(95,0+6),
		new Vector3(96,0+6),
		new Vector3(97,0+6),
		new Vector3(98,0+6),
		new Vector3(99,0+6),
		new Vector3(100,0+6),
	};



	// Use this for initialization
	void Start () 
	{
		block = GameObject.CreatePrimitive (PrimitiveType.Cube);
        block.GetComponent<MeshRenderer>().material = blockMaterial;

		coins = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		coins.AddComponent<CoinBehavior>();
        coins.GetComponent<MeshRenderer>().material = coinMaterial;
		coins.GetComponent<CapsuleCollider> ().isTrigger = true;

        triggerZone = GameObject.CreatePrimitive(PrimitiveType.Cube);
        triggerZone.transform.localScale = new Vector3(1, 10, 1);
        triggerZone.GetComponent<BoxCollider>().isTrigger = true;
        triggerZone.AddComponent<SpeedZoneBehavior>();
        triggerZone.GetComponent<MeshRenderer>().enabled = false;

		for (int i = 0; i < 10; i++) 
		{
			foreach (Vector3 blocks in blockArrayBottom) 
			{
				place (blocks, i);
				placeCoins (blocks, i);
			}

			foreach (Vector3 blocks in blockArrayTop) 
			{
				place (blocks, i);
			}

            GameObject zone = Instantiate(triggerZone);
            zone.transform.position = new Vector3(blockArrayBottom.Length * i, 0, 0);
		}

		Destroy(block);
		Destroy(coins);
        Destroy(triggerZone);
	}

	public void place(Vector3 blocks, int i)
	{
		if(blocks.z == -1)
		{
			return;
		}

		blocks.x += i * 100;
		GameObject go = Instantiate(block);
		go.transform.position = blocks;
		go.transform.rotation = Quaternion.identity;
		go.transform.SetParent(this.transform);


		if (blocks.x % 2 != 0)
		{
			go.GetComponent<Renderer>().material.color = new Color(0.5f, 0, 0);
			//	go1.GetComponent<Renderer>().material.color = new Color(0.5f, 0, 0);
		}
	}

	public void placeCoins(Vector3 blocks, int i)
	{
		if (blocks.x % 5 == 0) 
		{
			GameObject goCoins = Instantiate(coins);
			blocks.x += i * 100;
			goCoins.transform.position = new Vector3(blocks.x,blocks.y+2,0.25f);
			goCoins.transform.position = new Vector3(blocks.x,blocks.y+2,0.25f);
			goCoins.transform.localScale = new Vector3 (1f, .1f, 1f);
			goCoins.transform.eulerAngles = new Vector3 (90, 0, 0);
			goCoins.transform.SetParent(this.transform);
		} 
		else 
		{
			return;
		}
		
	}


}