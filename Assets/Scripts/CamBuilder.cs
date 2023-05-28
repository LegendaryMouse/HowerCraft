using UnityEngine;

public class CamBuilder : MonoBehaviour
{
    public GameObject[] blocks;

    GameObject block;
    public GameObject core;


    public float sens = 1.5f;
    public float speed = 30f;

    private Transform tr;
    private Vector3 qtr;
    private float rotX;
    private float rotY;

    public bool upDownLock;
    public bool leftRightLock;

    float ws;
    float ad;

    int i = 0;


    public void CubeChance()
    {
        block = blocks[i];
        i++;
        if (i >= blocks.Length)
            i = 0;
    }

    void Awake()
    {
        tr = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            CubeChance();



        ad = Input.GetAxis("Horizontal");
        ws = Input.GetAxis("Vertical");

        transform.Translate(ad * Time.deltaTime * speed, 0, ws * Time.deltaTime * speed);

        rotX += Input.GetAxis("Mouse X");
        rotY += Input.GetAxis("Mouse Y");
        if (upDownLock)
            rotY = 0;
        if (leftRightLock)
            rotX = 0;

        qtr = new Vector3((-rotY * sens * 0.001f * Screen.width), rotX * sens * 0.001f * Screen.height, 0f);
        tr.rotation = Quaternion.Euler(qtr);



        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Vector3 targetPosition = hit.point + hit.normal.normalized * 0.5f;
                targetPosition = new Vector3(Mathf.RoundToInt(targetPosition.x),
                                             Mathf.RoundToInt(targetPosition.y),
                                             Mathf.RoundToInt(targetPosition.z));
                //Vector3 rotationVector = new(0, Mathf.Round(transform.eulerAngles.y / 90f) * 90f, Mathf.Round(transform.eulerAngles.z / 90f) * 90f);
                //Vector3 blockDirection = Quaternion.Euler(rotationVector) * Vector3.forward;
                //Quaternion rotation = Quaternion.LookRotation(blockDirection, hit.normal);
                Quaternion rotation = new(0, 0, 0, 0);
                GameObject placedBlock = Instantiate(block, targetPosition, rotation);

                placedBlock.GetComponent<ConfigurableJoint>().connectedBody = core.GetComponent<Rigidbody>();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f) && !(hit.collider.name == "Reactor"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}

