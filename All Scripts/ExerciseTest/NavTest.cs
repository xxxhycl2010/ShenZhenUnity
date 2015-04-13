using UnityEngine;
using System.Collections;

public class NavTest : MonoBehaviour {

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                Debug.Log(hit.point);
                Vector3 point = hit.point;
                transform.LookAt(new Vector3(point.x, transform.position.y, point.z));
                agent.SetDestination(point);
            }
        }
    }
	
}
