using System;
using ECS.Components.Events;
using ECS.Components.Reference;
using Leopotam.Ecs;
using UnityEngine;

namespace Physics
{
    public class PlayerCollisionChecker : MonoBehaviour
    {
        private EntityReference _entityReference;
        
        public void Init(EntityReference reference)
        {
            _entityReference = reference;
        }
        private void OnCollisionEnter(Collision collision)
        {
            _entityReference.entity.Get<OnCollisionEnter>().other = collision.collider;
        }
    }
}
