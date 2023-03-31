﻿using System;
using System.Collections.Generic;
using NSubstitute;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Plugins.Unify.Core.Builders.DependencyBuilder
{
    public class UnifyDependencyBuilder<TDependency> : IDependencyBuilder<TDependency> where TDependency : class
    {
        // The dependencies dictionary that this builder will register the dependencies to
        private readonly Dictionary<UnifyDependency, object> _dependencies;

        // Needed for asserting whether register was called before the builder is disposed.
        private bool _registerWasCalled = false;
        
        // Dependency variables
        private TDependency _instance;
        private string _id;
        private readonly bool _dependencyIsInterface;

        private Type _typeConcrete;

        /// <summary>
        /// The UnifyDependencyBuilder builds a dependency using the builder pattern.
        /// It's builder chain must be ended with a call to Register(), at which point
        /// the dependency will be registered into the passed container.
        /// </summary>
        /// <param name="dependencies">The dependency dictionary of the container in which this dependency should be registered.</param>
        public UnifyDependencyBuilder(Dictionary<UnifyDependency, object> dependencies)
        {
            _dependencies = dependencies;
            _dependencyIsInterface = typeof(TDependency).IsInterface;
        }
        
        public IDependencyBuilder<TDependency> FromComponentOnGameObject(GameObject gameObject, string name = default)
        {
            AssertInstanceIsNull("FromComponentOnGameObject");

            if (_dependencyIsInterface)
                _instance = gameObject.GetComponent(_typeConcrete) as TDependency;
            else 
                _instance = gameObject.GetComponent(typeof(TDependency)) as TDependency;
            
            if (_instance == null)
                throw new Exception(
                    $"Component with type {typeof(TDependency)} resulted in a null object when added as a component. Are you sure you are registering a component type dependency?");
            return this;
        }

        public IDependencyBuilder<TDependency> FromComponentOn<TComponent>(TComponent component, string name = default) where TComponent : Component
        {
            AssertInstanceIsNull($"FromComponentOn<{typeof(TComponent)}>");

            if (_dependencyIsInterface)
                _instance = component.GetComponent(_typeConcrete) as TDependency;
            else 
                _instance = component.GetComponent(typeof(TDependency)) as TDependency;
            
            if (_instance == null)
                throw new Exception(
                    $"Component with type {typeof(TDependency)} resulted in a null object when added as a component. Are you sure you are registering a component type dependency?");
            return this;
        }

        #region Instance Creation
        public IDependencyBuilder<TDependency> FromComponentOnNewGameObject(string name = default)
        {
            AssertInstanceIsNull("FromComponentOnNewGameObject");

            if (_dependencyIsInterface)
                _instance = new GameObject(name).AddComponent(_typeConcrete) as TDependency;
            else 
                _instance = new GameObject(name).AddComponent(typeof(TDependency)) as TDependency;
            
            if (_instance == null)
                throw new Exception(
                    $"Component with type {typeof(TDependency)} resulted in a null object when added as a component. Are you sure you are registering a component type dependency?");
            return this;
        }

        public IDependencyBuilder<TDependency> FromPrefab(GameObject gameObjectWithDependencyAttached)
        {
            AssertInstanceIsNull("FromPrefab");

            _instance = Object.Instantiate(gameObjectWithDependencyAttached).GetComponent<TDependency>();
            if (_instance == null)
                throw new Exception(
                    $"Query with prefab resource path for type {typeof(TDependency)} resulted in a null object. Are you sure this prefab has that component attached?");
            return this;
        }

        public IDependencyBuilder<TDependency> FromInstance(TDependency instance)
        {
            AssertInstanceIsNull("FromInstance");
            _instance = instance;
            return this;
        }

        public IDependencyBuilder<TDependency> FromSubstitute()
        {
            AssertInstanceIsNull("FromSubstitute");
            _instance = Substitute.For<TDependency>();
            return this;
        }
        #endregion

        public IDependencyBuilder<TDependency> WithId(string id)
        {
            _id = id;
            return this;
        }

        public void Register()
        {
            _registerWasCalled = true;
            
            if (_instance == null)
                throw new Exception("Missing an instance: A dependency builder received an attempt to Register before an instance was bound.");
            
            var dependency = new UnifyDependency(typeof(TDependency), _id);
            if (_dependencies.ContainsKey(dependency))
                throw new Exception($"Already contains a similar dependency: {dependency}");
            _dependencies[dependency] = _instance;
        }

        public void Dispose()
        {
            if (!_registerWasCalled)
                throw new Exception("Missing a call to Register: A dependency builder fell out of scope before an attempt to Register it was made!");
        }
        
        
        private void AssertInstanceIsNull(string callerName)
        {
            if (_instance != null)
                throw new Exception(
                    $"Called {callerName} when an instance already exists in this DefineDependency chain.");
        }

        public IDependencyBuilder<TDependency> AsInterfaceTo<TConcrete>()
        {
            if (!_dependencyIsInterface)
                throw new Exception($"Called AsInterFaceTo<{typeof(TConcrete)}> but {typeof(TDependency)} is not an interface");
            _typeConcrete = typeof(TConcrete);
            return this;
        }

        public IDependencyBuilder<TDependency> FromPrefabResource(Object prefab)
        {
            AssertInstanceIsNull("FromPrefabResource");

            _instance = (Object.Instantiate(prefab) as GameObject)?.GetComponent<TDependency>();
            if (_instance == null)
                throw new Exception(
                    $"Query with prefab resource path for type {typeof(TDependency)} resulted in a null object. Are you sure this prefab has that component attached?");
            return this;
        }
    }
}