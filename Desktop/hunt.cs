using UnityEngine;
using System.Collections;

 class hunt : MonoBehaviour {

	public Transform player;
	public GameObject RFwalk1;
	public GameObject RBwalk1;
	public GameObject LFwalk1;
	public GameObject LBwalk1;
	
	public Transform explosion;
	
	public GameObject exp1;
	public GameObject exp2;
	public GameObject exp3;
	public GameObject exp4;
	public GameObject exp5;
	public GameObject exp6;
	
	public GameObject RedEnemy;
	
	public float health= 100;

	public const float SPEED = 1.6f;
	public const float ZONE = 1.0f;
		
	public GameObject killCounter;


	
	
	public void minusOne(float amount)
	{
		health -= amount;
		if(health <= 0){
			KillCounter deathToll = killCounter.gameObject.GetComponent<KillCounter>();
			deathToll.plusOne();
			Destroy (RedEnemy);
		}
		
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(player != null){
			
		}
		
		Vector3 current = transform.position;
		if ( (player.position.y - transform.position.y) > ZONE){
			
			current.y += SPEED * Time.deltaTime;
			transform.position = current;
			rigidbody.velocity = Vector3.zero;
			
			RFwalk1.animation.Play ();
			RBwalk1.animation.Play ();
			LFwalk1.animation.Play ();
			LBwalk1.animation.Play ();
		}
		if ( (player.position.x - transform.position.x) > ZONE){
			
			current.x += SPEED * Time.deltaTime;
			transform.position = current;
			rigidbody.velocity = Vector3.zero;
			
			RFwalk1.animation.Play ();
			RBwalk1.animation.Play ();
			LFwalk1.animation.Play ();
			LBwalk1.animation.Play ();
		}
		
		if ( (player.position.y - transform.position.y) < -ZONE){
			
			current.y -= SPEED * Time.deltaTime;
			transform.position = current;
			rigidbody.velocity = Vector3.zero;
			
			RFwalk1.animation.Play ();
			RBwalk1.animation.Play ();
			LFwalk1.animation.Play ();
			LBwalk1.animation.Play ();
		}
		
	
		if ( (player.position.x - transform.position.x) < -ZONE){
			
			current.x -= SPEED * Time.deltaTime;
			transform.position = current;
			rigidbody.velocity = Vector3.zero;
			
			RFwalk1.animation.Play ();
			RBwalk1.animation.Play ();
			LFwalk1.animation.Play ();
			LBwalk1.animation.Play ();
		}
		
		current.z= 0.5f;
		transform.position = current;
		
		Vector3 delta = player.transform.position - this.transform.position;
		
		//delta = delta - transform.position;
		
		float angle = Mathf.Atan2(delta.y,delta.x)*Mathf.Rad2Deg;
		
		transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
		
		
	}
	
	
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.name == "player"){  
			
	
			
			Destroy (this.gameObject);
			var exp = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
			player minus1 = collision.gameObject.GetComponent<player>();
			minus1.minusOne(10f);
			
		}
		if(	collision.gameObject.name == "Shot(Clone)"||collision.gameObject.name == "ShotBlue(Clone)"||collision.gameObject.name == "ShotPurple(Clone)") {
			
			
			var exp = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
			
			Destroy (this.gameObject);
	} 

}
}