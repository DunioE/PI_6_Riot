using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SG
{
    public class Persegue : MonoBehaviour
    {
        NavMeshAgent agent;
        public GameObject target;
        PlayerLocomotion ds;

        void Start()
        {
            agent = this.GetComponent<NavMeshAgent>();
            ds = target.GetComponent<PlayerLocomotion>();
        }

        void Seek(Vector3 location)
        {
            agent.SetDestination(location);
        }

        void Flee(Vector3 location)
        {
            Vector3 fleeVector = location - this.transform.position;
            agent.SetDestination(this.transform.position - fleeVector);
        }

        void Pursue()
        {
            Vector3 targetDir = target.transform.position - this.transform.position;

            float relativeHeading = Vector3.Angle(this.transform.forward, this.transform.TransformVector(target.transform.forward));
            float toTarget = Vector3.Angle(this.transform.forward, this.transform.TransformVector(targetDir));

            if ((toTarget > 90 && relativeHeading < 20) || ds.GetMovementSpeed() < 0.01f)
            {
                Seek(target.transform.position);
                    return;
            }

            float lookAhead = targetDir.magnitude / (agent.speed + ds.GetMovementSpeed());
            Seek(target.transform.position + target.transform.forward * lookAhead);
        }

        private void Evade()
        {
            Vector3 targetDir = target.transform.position - this.transform.position;
            float lookAhead = targetDir.magnitude / (agent.speed + ds.GetMovementSpeed());
            Flee(target.transform.position + target.transform.forward * lookAhead);
        }

        void Update()
        {
            Evade();
        }
    }
}
