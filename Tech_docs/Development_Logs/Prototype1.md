# Gameplay Prototype 1

## Plan
This prototype is designed to study the gameplay.

### Tasks
- [ ] Modify the camera to be the fixed top-down view.  
- [ ] Develop the weapon system
- [ ] Develop the action system
- [ ] Develop the skill system
- [ ] Develop the enemy system

## Camera Control
The camera will always follow the player and presents a top-down view.

## Weapon System

- Weapon picking up
- Weapon firing
- Weapon switching
- Weapon aiming

## Action System

## Skill System
- Reflection
- 

## Enemy



## Learn Unity

### Prefabs
Prefabs are templates with most properties and structures established to facilitate development. In addition, changing the prefab itself will change all the instances of the prefab.
If we want to make one instance different from the other instance, we can either **unpack the prefab** for this specific instance or make a **variation of the prefab**.
### Variation of prefabs
#TODO

### Update vs LateUpdate vs FixedUpdate
**LateUpdate** is only excited after all the other updates are executed. Camera control functions are usually placed in the **LateUpdate** function since the camera control logic always depends on the end location and direction of the player character.

### Communication between scripts
As long as the script is in the asset, the other scripts can access the script. To access the instance of one script we can use the following code.

```c#
// Script A
class A
{
	public float A_property;
}


// Script B
class B
{
	public A a;
	void Start()
	{
		// Three methods to get the instance of class A.
		a = GameObject.GetComponent<A>();
		a = GameObject.Find("ObjectName").GetComponent<A>();
		a = GameObject.FindGameObjectWithTag("Tag").GetComponent<A>();
	}
}
```

### New Input System

