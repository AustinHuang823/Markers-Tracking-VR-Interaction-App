using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

        private float movementX;
        private float movementY;

	private Rigidbody rb;
	private int count;

	//Color part of Player
	public Color BaseColor = new Color(1.0f, 1.0f, 1.0f);
    public Color rainbow1 = Color.red;
    public Color rainbow2 = Color.yellow;
    public Color rainbow3 = Color.green;
    public Color rainbow4 = Color.cyan;
    public Color rainbow5 = Color.blue;
    public Color rainbow6 = Color.magenta;    
	public Color newcolor = new Color(0.0f, 0.0f, 1.0f);
    public float duration = 1.0f;
    public float timer = 0f;

	//scale part
    private Vector3 scaleChange, positionChange;
	


	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		SetCountText ();

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);

		//scale part
		scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
        positionChange = new Vector3(0.0f, 0.05f, 0.0f);
	}


	IEnumerator ScaleCoroutine()
    {
        this.transform.localScale += scaleChange;
		this.transform.position += positionChange;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        this.transform.localScale -= scaleChange;
		this.transform.position -= positionChange;
    }


	void FixedUpdate ()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

		rb.AddForce (movement * speed);

		//color changing part
		timer += Time.deltaTime;
		if ((timer % 6)<1) { 
		GetComponent<Renderer>().material.SetColor("_BaseColor", rainbow1);
		}else if (timer % 6 < 2)
		{
		GetComponent<Renderer>().material.SetColor("_BaseColor", rainbow2);
		}
		else if (timer % 6 < 3)
		{
			GetComponent<Renderer>().material.SetColor("_BaseColor", rainbow3);
		}
		else if (timer % 6 < 4)
		{
			GetComponent<Renderer>().material.SetColor("_BaseColor", rainbow4);
		}
		else if (timer % 6 < 5)
		{
			GetComponent<Renderer>().material.SetColor("_BaseColor", rainbow5);
		}
		else 
		{
			GetComponent<Renderer>().material.SetColor("_BaseColor", rainbow6);
		}
		newcolor = GetComponent<Renderer>().material.GetColor("_BaseColor");
	}


	void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("PickUp"))
		{
			// other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();

			StartCoroutine(ScaleCoroutine());
		}
	}

    void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();

        	movementX = v.x;
        	movementY = v.y;
        }

    void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 20) 
		{
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
		}
	}
}