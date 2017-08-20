using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCube : MonoBehaviour
{
    public float force;
    public float radius;
    public float effectsRadius;

    public GameObject explosion;

    private void OnMouseDown()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collided in colliders)
        {
            Rigidbody collidedRigidBody = collided.GetComponent<Rigidbody>();

            if (collidedRigidBody != null)
            {
                collidedRigidBody.AddExplosionForce(force, transform.position, radius, .5f, ForceMode.Impulse);
            }
        }

        ParticleSystem[] particleSystems = explosion.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < particleSystems.Length; i++) {
            ParticleSystem.ShapeModule shapeModule = particleSystems[i].shape;
            shapeModule.radius = effectsRadius;
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
