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
        Animator animator;

        // Adicionando uma vari�vel para a dist�ncia de parada
        public float stoppingDistance = 2f;

        bool isHiding = false;

        void Start()
        {
            agent = this.GetComponent<NavMeshAgent>();
            ds = target.GetComponent<PlayerLocomotion>();
            animator = GetComponent<Animator>();

            // Define a dist�ncia de parada do NavMeshAgent
            agent.stoppingDistance = stoppingDistance;
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

        Vector3 wanderTarget = Vector3.zero;
        private void Wander()
        {
            float wanderRadius = 10;
            float wanderDistance = 20;
            float wanderJitter = 1;

            wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                        0,
                                        Random.Range(-1.0f, 1.0f) * wanderJitter);

            wanderTarget.Normalize();
            wanderTarget *= wanderRadius;

            Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
            Vector3 targetWorld = transform.TransformPoint(targetLocal);

            Seek(targetWorld);
        }

        void Hide()
        {
            float dist = Mathf.Infinity;
            Vector3 chosenSpot = Vector3.zero;

            for (int i = 0; i < World.Instance.GetHidingSpots().Length; i++)
            {
                Vector3 hideDir = World.Instance.GetHidingSpots()[i].transform.position - target.transform.position;
                Vector3 hidePos = World.Instance.GetHidingSpots()[i].transform.position + hideDir.normalized * 5;

                if (Vector3.Distance(transform.position, hidePos) < dist)
                {
                    chosenSpot = hidePos;
                    dist = Vector3.Distance(transform.position, hidePos);
                }
            }

            Seek(chosenSpot);
            isHiding = true; // Indica que o NPC est� se escondendo
        }

        void CleverHide()
        {
            float dist = Mathf.Infinity;
            Vector3 chosenSpot = Vector3.zero;
            Vector3 chosenDir = Vector3.zero;
            GameObject chosenGO = World.Instance.GetHidingSpots()[0];

            for (int i = 0; i < World.Instance.GetHidingSpots().Length; i++)
            {
                Vector3 hideDir = World.Instance.GetHidingSpots()[i].transform.position - target.transform.position;
                Vector3 hidePos = World.Instance.GetHidingSpots()[i].transform.position + hideDir.normalized * 10;

                if (Vector3.Distance(transform.position, hidePos) < dist)
                {
                    chosenSpot = hidePos;
                    chosenDir = hideDir;
                    chosenGO = World.Instance.GetHidingSpots()[i];
                    dist = Vector3.Distance(this.transform.position, hidePos);
                }
            }

            Collider hideCol = chosenGO.GetComponent<Collider>();
            Ray backRay = new Ray(chosenSpot, -chosenDir.normalized);
            RaycastHit info;
            float distance = 100.0f;
            hideCol.Raycast(backRay, out info, distance);
            Seek(info.point + chosenDir.normalized * 2);
            isHiding = true; // Indica que o NPC est� se escondendo
        }

        bool CanSeeTarget()
        {
            RaycastHit raycastInfo;
            Vector3 rayToTarget = target.transform.position - this.transform.position;

            if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
            {
                PlayerLocomotion playerLocomotion = raycastInfo.transform.gameObject.GetComponent<PlayerLocomotion>();
                {
                    return true;
                }
            }
            return false;
        }

        bool CanSeeMe()
        {
            Vector3 rayToTarget = this.transform.position - target.transform.position;
            float lookAngle = Vector3.Angle(target.transform.forward, rayToTarget);

            if (lookAngle < 60)
                return true;
            return false;
        }

        bool coolDown = false;
        void BehaviourCooldown()
        {
            coolDown = false;
            isHiding = false; // Reinicia o indicador de se est� se escondendo
        }

        bool TargetInRange()
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) < 20)
                return true;
            return false;
        }

        void SetMoving(bool isMoving)
        {
            animator.SetBool("Moving", isMoving);
        }

        void Update()
        {
            if (!coolDown)
            {
                if (!TargetInRange())
                {
                    SetMoving(true);
                    Wander();
                }
                else if (CanSeeTarget() && CanSeeMe())
                {
                    SetMoving(true);
                    CleverHide();
                    coolDown = true;
                    Invoke("BehaviourCooldown", 5);
                }
                else
                {
                    SetMoving(true);
                    Pursue();
                }

                if (agent.remainingDistance <= agent.stoppingDistance && !isHiding)
                {
                    SetMoving(false);
                }
            }
        }
    }
}
