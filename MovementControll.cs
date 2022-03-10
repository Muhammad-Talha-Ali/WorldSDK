using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Wrld;
using Wrld.Common.Maths;
using Wrld.Space;
using Wrld.Space.Positioners;
public class MovementControll : MonoBehaviour
{
    public List<GameObject> enemies;
    GameObject[] enem;
    GameObject selectedEnemy;
    public float Flyspeed = 5 , upSpeed = 5;
    public float YawVal = 100;
    float distance, shortestdist, searchrange;
    float Yaw;
    public LatLong targetPosition = new LatLong(37.802, -122.406);
    public GeographicTransform coordinateFrame;
    // Start is called before the first frame update

    void OnEnable()
    {
        Api.Instance.CameraApi.MoveTo(targetPosition, distanceFromInterest: 1700, headingDegrees: 0, tiltDegrees: 45);
       // coordinateFrame.SetPosition(targetPosition);
    }
    void Start()
    {
         enemies = GameObject.FindGameObjectsWithTag("enemy").ToList();
        
    }

    // Update is called once per frame
    void Update()
    {   //find and face the closest enemy
        /* if(enem.Length >0)
         for(int i = 0; i < enem.Length; i++)
         {
             distance = Vector3.Distance(enem[i].transform.position, transform.position);
             if (distance < 10f)
             {
                 selectedEnemy = enem[i];
                 transform.LookAt(selectedEnemy.transform);
             }
         }*/
        if (enemies.Count > 0)
        {   foreach (GameObject item in enemies)
            {
                distance = Vector3.Distance(item.transform.position, transform.position);
                if (distance < searchrange)
                {
                    
                    transform.LookAt(selectedEnemy.transform);
                    if (distance < shortestdist)
                    {
                        shortestdist = distance;
                        selectedEnemy = item;
                    }
                }
            }
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += vertical * transform.forward * Flyspeed * Time.deltaTime + transform.forward *0.5f* Flyspeed * Time.deltaTime;

        

        Yaw += horizontal * YawVal * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(vertical)) * Mathf.Sign(vertical);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontal)) * -Mathf.Sign(horizontal);

        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);

        if (Input.GetButton("Up"))
        {
            transform.position += new Vector3(0, 1, 0) * upSpeed*Time.deltaTime;
        }
        if (Input.GetButton("Down"))
        {
            transform.position += new Vector3(0, 1, 0) * -upSpeed * Time.deltaTime;
        }
    }
}
