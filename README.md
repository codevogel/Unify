# Unify
A dependency injection framework for Unity. Currently work in progress, all rights reserved.

This readme needs work.
Check out the [Example Scripts](https://github.com/kemmel-dev/Unify/tree/main/Assets/Scripts/Unify/Example) for now!

## What is Dependency Injection? (~5min)
In Game Development, often, a script might depend on the behaviors of other scripts. For example, a concrete implementation `Guard` might need a concrete implementation of `IGuardManager` to find nearby colleagues, so it can alert them of a nearby enemy. The `Guard` thus *depends* on `GuardManager`. 

To resolve this dependency on the `GuardManager` in the `Guard` class there are generally two approaches in Unity:
- find a reference in the guard itself
	- i.e. in the `Awake()` function you might call Unity's `GameObject.Find()` or `gameObject.GetComponent<Foo>`
- *inject* this *dependency* into `Guard`, passing the reference to the concrete implementation of `GuardManager` to an instance of Guard.
	- This can be achieved by various methods, such as *method injection* or *constructor injection*.
	- i.e. `Guard guard = new Guard(IGuardManager guardManager) { this.guardManager = guardManager; } `

The second approach follows the **single-responsibility principle (RSP)** more closely: The `Guard` class no longer needs to worry about resolving it's own dependency, so all the code in the `Guard` class can simply be related to it's behaviour.
Another class then has the responsibility to define the **dependency** of the type `GuardManager` , and another class can **inject** it into the `Guard` upon creation: This is an example of **dependency injection**, a design pattern in which an object or function receives other objects or functions that it depends on (instead of resolving them manually in the dependee). This principle is also reffered to as **Inversion of Control (IOC)**.

A **DI framework** is a codebase that can help you automate the process of dependency injection, and can introduce a more streamlined workflow for developing your game, centralizing the 'needs' that your game has. It can also be very handy during testing: when writing unit tests, you may need to test a class that has multiple dependencies, some of which need to be mocked, and some of which need specific concrete implementations. A dependency injection framework can make it easier to set up these specific tests, and can allow you to re-use the setup process for certain tests. **Unify** is such a framework for Unity. In this assignment you'll take it upon yourself to try to make use of Unify to apply these principles yourself.

<newpage>

## Exploring the project (~20 min)
1. Clone or fork the project from https://github.com/kemmel-dev/Unify
2. Open the 'Example Scene'.
3. Check out the objects in the hierarchy of this scene:
	1. Note the `FooBehaviour` that is attached as a component to a game object in the hierarchy. It extends from `UnifyBehaviour`
	2. There are four installers: The `RootInstaller` and three `ExampleInstaller`s. Verify that:
		1. the `Example Installer` has the `FooBehaviour` linked from the object in the hierarchy, and has a `string` value that is set in the inspector.
		2. the `Example Installer From Prefab With Factory` has the `BarFactoryBehaviourPrefab` selected from `Resources/Prefabs`
		3. the `Example Installer With Interfaces` has no dependencies shown in the inspector.
		4. the `RootInstaller` has a list with references to all three `ExampleInstallers` above.
4. Start the scene. **You can click on any of the Behaviour objects to see the relevant GUI-button for that object drawn in it's `OnGUI` method.** Double-click on the debug log message to see the relevant code that the message triggered from. 
	1. Testing simple behaviours
		1. Call DoSomething() on the `FooBehaviourThatAlreadyExistsInHierarchy` and verify that the behaviour does something on the relevant gameobject.
		2. Call DoSomething() on the `FooBehaviourFromCode` and verify that the behaviour does something on the relevant newly created gameobject.
	2. Testing behaviours with dependencies
		1. Call DoSomething() on the `BarBehaviourWithDependency` and verify that:
			1. BarBehaviour prints out the string that is shown in the Example Installer inspector.
			2. BarBehaviour calls `DoSomething()` on `FooBehaviourFromCode`
			3. BarBehaviour calls `DoSomething()` on `FooBehaviourThatAlreadyExistsInHierarchy`
		2. Change the string inspector value for the `BarBehaviourWithDependency` and again call `DoSomething()` on it.
			1. Verify that the debug log now outputs a different string dependency - allowing for test value changes in playmode.
	3. Testing behaviours with dependencies through interfaces
		1. Verify that the `BazBehaviour` executes a method `DoSomethingOnAnInterface` implemented from the `IBaz` interface.
		2. Verify that the `QuxBehaviour` executed that same method on the same `BazBehaviour`, now referenced through `IBaz`.
	4. Testing behaviours with factories that create other behaviours in runtime.
		1. Verify that the `BarFactoryBehaviourPrefab(Clone)` can instantiate new `BarBehaviours` (remember to also verify that these instantiated BarBehaviours have their dependencies resolved!)
		2. Verify that it can also spawn new `BarBehaviours` with some custom code running before the `BarBehaviours` Start function executes.
		3. Finally, verify that it can also spawn new `BarBehaviour`s that all have unique values for their `string` dependencies.
5. Dive into the Installer code!
	1. Open the `ExampleInstaller` and try to understand how the dependencies are defined and then registered.
		1. It defines a dependency of type `string` from the instance that is assigned in the inspector.
		2. It also defines a dependency on a `BarBehaviour` that is created in code.
		3. It defines two dependencies of the same type, `FooBehaviour`, each with their own unique string `id` to be able to differentiate between the two. 
	2. Open the `ExampleInstallerWithInterfaces` and try to understand how the instance of  `BazBehaviour` is now referenced through the interface `IBaz`, meaning that if other classes rely on `IBaz` they will receive that concrete implementation of `BazBehaviour`
	3. Open the `ExampleInstallerFromPrefabWithFactory`  and try to understand:
		1. How a `BarFactoryBehaviour` relies on an instance of the prefab at `Prefabs/BarFactoryBehaviourPrefab`.
		2. How we create a new instance of a non-monobehaviour class `BarBehaviourFactory` that will be used in the `BarFactoryBehaviour`.
6. Understanding Factories
	1. Open the `BarBehaviourFactory` and try to understand how:
		1. We manually resolve the dependencies for the object that is created by this factory using `ResolveFromContainer<>`
		2. How we can add a custom override for the default factory method using the `[FactoryOverride(id)]` attribute.
	2. Now open the `BarFactoryBehaviour` and try to understand how we use the above factory to:
		1. Create an instance of `BarBehaviour` in the `CreateAnInstanceOfBar()` method.
		2. Create an instance of `BarBehaviour` after which we immediately execute some custom code using the `CreateAnInstanceOfBarWithSomeCustomLogicBeforeItsStartFunction()` method.
		3. Create a new `DependencyOverride` object which then passes the objects that need to be passed to the method marked with `[FactoryOverride(id)]` so that we can alter (part of the required) dependencies during runtime.
7. Understanding tests
	1. Open the `Foo` and `FooMono` classes in `UsedInExampleTests`
	2. Open the `FooMonoTest` and try to understand how:
		1. In the `FooMonoTestInstaller`...
			1. An automocking substitute (using `NSubstitute`) for an implementation of the `IFoo`  that `FooMono` is defined.
			2. An instance for `FooMono` is created and registered as a dependency.
		2. In the `FooMonoTest`...
			1. We add the `SubInstaller` for this test
			2. We perform a Unit Test on `FooMono`.

## Fiddle! (~40-60 min) 

In this assignment, we will create a factory behaviour that instantiates characters that can wield different types of guns.

Creating the guns:
1. Create a new scene and add a `RootInstaller` by adding the component to an empty gameobject.
2. Create an interface `IGun` that has a method `Shoot`
3. Create a `PewGun : IGun` and a `PopGun : IGun`, which `Debug.Log()` 'pew' and 'pop' in the `Shoot()` method respectively.

Creating the character:

4. Create a `Character : UnifyBehaviour`, which has a dependency on: `IGun gun` and a `Vector3 spawnPosition`. (To add new behaviour scripts easily, you can use `Assets > Create > Unify > Behaviour`). Mark the injection method with `[Inject]`
5. Create a method in `Character` called `Attack()` which calls `gun.Shoot()`, and call this method in the update method when a key is pressed. Also set the transform.position to the spawn position in the `Start()` method.
6. Create a new gameobject and add the `Character` script to it.

Trying out the guns: 

7. Define a dependency of type `IGun` in the new `MonoInstaller` and register it to a concrete implementation `PewGun`. Also define a dependeny of type `Vector3`, and assign a custom value to it through the inspector.
8. Observe whether the character can shoot the PewGun.
9. Change, in the dependency definition of `IGun`, the concrete implementation of `PewGun` to `PopGun`.
10. Observe whether the character can shoot the PopGun.

Creating a factory:

11. Remove the Character from the hierarchy.
12. Create a `CharacterFactory` which instantiates objects of type `Character` and a `CharacterFactoryBehaviour` which depends on a `CharacterFactory`. A template can be created with `Assets > Create > Unify > Behaviour Factory`  
13. Throw a `NotImplementedException` in the default override, then add a new factory method using `[FactoryOverride(id: "WithGun")]` that takes in a the `Character` and a `string gunId`, then manually resolve the `IGun` dependency using `gunId`.
14. Implement an Update method in the `CharacterFactoryBehaviour` that on mouse down left creates a character wielding a `pewGun`, and on mouse right creates a character wielding a `popGun` by calling `_factory.Create(name, new DependencyOverride(...))`

Trying out the factory:

15. In the installer, alter the dependency definition that registers `IGun` to `PopGun` to be defined by an id `popGun`, and add another definition that registers `IGun` to `PewGun` with the id `pewGun`.
16. Observe whether the corresponding characters are created and whether they shoot the right guns.

Writing a test:

17. Finally, create a test for the `Character` behaviour that tests whether the `Character.Attack` method calls the `Shoot` method on a substitute for `IGun`. Again, use `Assets > Create > Unify > Test` to create a template for your test script.
