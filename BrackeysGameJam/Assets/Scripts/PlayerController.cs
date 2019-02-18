using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public static PlayerController instance;

    public GameManager gameManager;
    public Transform mainCameraTransform;

    public Rigidbody rb;

    public int walkSpeed;
    public int runSpeed;

    bool rotationOn = true;
    public float lookSensitivity = 5;
    float yaw = 0; //y rotation
    float pitch = 0; //x rotation

    int interactRange = 10;
    LayerMask layerMask;

    //player equip location for prefab
    public GameObject hand;

    public GameObject floor;

    Tool equippedTool = null;
    bool scanInProgress = false;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        layerMask = LayerMask.GetMask("Item");
    }

    // Update is called once per frame
    void FixedUpdate(){
        Move();

        RaycastHit hit;
        if(Physics.Raycast(mainCameraTransform.position, mainCameraTransform.forward, out hit, interactRange, layerMask)) {
            //enable UI
            gameManager.EnableInteractUI();
        }
        else {
            //enable UI
            gameManager.DisableInteractUI();
        }

        if (Input.GetMouseButton(1)) {
            if(equippedTool != null) {
                if (!scanInProgress) {
                    SendScan();
                }
            }
        }
    }

    private void Move() {

        //rotate the camera based on mouse position
        if (rotationOn) {
            RotateCamera();
        }


        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 leftRight = moveX * mainCameraTransform.right;
        leftRight.y = 0;
        Vector3 forwardBack = moveY * mainCameraTransform.forward;
        forwardBack.y = 0;

        Vector3 direction = (leftRight + forwardBack).normalized;

        Vector3 velocity = direction * walkSpeed;

        if(velocity != Vector3.zero) {
            rb.MovePosition(transform.position + velocity * Time.deltaTime);
        }

    }

    //lock the y rotation of the player
    private void LateUpdate() {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    void RotateCamera() {
        pitch += Input.GetAxis("Mouse Y") * lookSensitivity;
        pitch = Mathf.Clamp(pitch, -45, 45);

        //x rotation of camera
        mainCameraTransform.localEulerAngles = new Vector3(-pitch, 0, 0);

        //y rotation of body
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);

    }

    //update center of scan and start coroutine
    public void SendScan() {

        gameManager.UpdateScanLocation(transform.position);
        StartCoroutine(Scan());
    }

    IEnumerator Scan() {
        float maxRadius = 15f;
        Renderer shader = floor.GetComponent<Renderer>();
        float radius = 0.7f;
        float delay = ((ToolObject)equippedTool.itemConfig).scanDelay;
        Color scanColor = ((ToolObject)equippedTool.itemConfig).scanColor;
        

        scanInProgress = true;
        while (radius < maxRadius) {
            yield return new WaitForSeconds(0.01f);
            radius += 0.1f;
            shader.sharedMaterial.SetFloat("_Radius", radius);

            //the closer the radius gets to 10 the darker the scan gets
            float redLevel = scanColor.r * (radius / maxRadius);
            float greenLevel = scanColor.g * (radius / maxRadius);
            float blueLevel = scanColor.b * (radius / maxRadius);

            //the closer the radius gets to max the darker the color gets until it fades to black
            shader.sharedMaterial.SetColor("_Color", new Color(scanColor.r - redLevel, scanColor.g - greenLevel, scanColor.b - blueLevel, 1));
            Debug.Log(new Color((scanColor.r - redLevel) / 255f, (scanColor.g - greenLevel) / 255f, (scanColor.b - blueLevel) / 255f, 1));
        }

        yield return new WaitForSeconds(delay);

        scanInProgress = false;
    }

    public void EquipTool(Tool tool) {
        if(hand.transform.childCount > 0) {
            Destroy(hand.transform.GetChild(0).gameObject);
        }
        Instantiate(GameObject.Find("GameManager").GetComponent<ItemsManager>().GetPrefab(tool.itemConfig.itemId), hand.transform);
        equippedTool = tool;
    }

    public void EquipThrowable(Throwable throwable) {

    }

    public void PlayClip(MusicPlayer mP) {
        GetComponent<AudioSource>().clip = ((MusicPlayerObject)mP.itemConfig).clip;
        GetComponent<AudioSource>().Play();
    }

    public void StopAudio() {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = null;
    }

    public void StopRotation() {
        rotationOn = false;
    }
    public void ResumeRotation() {
        rotationOn = true;
    }

    public void OnTriggerEnter(Collider other) {
        ItemPickUp itemPU = other.GetComponent<ItemPickUp>();
        if (itemPU != null) {
            Debug.Log("Found item");
            itemPU.PickUpItem();
        }
    }
}
