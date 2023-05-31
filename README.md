# First Person Player Controller For Unity
Assets folder contains all of the scripts, audios, animations, models, particles for player. I tried to use MVC and State Machine patterns for my player script. All the audios and animations are placeholders. You can change it any time for usage.
Animations and models are from https://www.mixamo.com/
All audios are from https://freesound.org/.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/f2b8a6f4-1814-4688-833b-3ca708c48dcc)

Above picture shows that all the components that my character has. Player contains all of the component classes. It allows other classes to reach all of the scripts.
##Player Controller
In player controller, there are regular classes to handle specified actions.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/db395e62-bbcb-4ae7-a190-9210f6715201)

BaseController class is a generic class for inherit other classes.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/243b96cd-e0ca-443b-a314-f6f238e4b767)

Base controller send player variable to all controllers.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/b25ea670-5133-4665-a45b-1feb414048cd)

In construction, I assign this parameter to Runner variable. It allows all scripts can reach player variables. For example, in “HandleMovement” class you need to assign some variables like speed. We can create these variables in same script but it prevents customization and seperate all the variables. It is easier to alter variables from one source like “PlayerModel” component.
##Player Model
PlayerModel stands for to contain all of the data like speed, health, sounds etc.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/e80a7d8c-6e17-457b-908c-d8688127d389)

All of the other objects can reach these variables. Anyone who is a designer can change the values whatever they want from model script. To make this model more easier to reach spesific fields like movement variables or health variables, I create serializable regular C# classes. For example, “Stamina” class looks like this.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/7f7c828e-09e6-44db-a83e-7ec2042bf625)

##Player View
Player view contains all of the view scripts for ground detection and interaction detection.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/63012924-7468-4a28-b2c3-b8a655b77618)

View is a base class like “BaseController” class. Player view contains all specified classes. GroundView stands for detecting ground with raycast. Whenever the raycast return nothing, it changes a variable in PlayerModel named “isOnGround”. Whenever the isOnGround variable is changed, it changes the state of player to fallState.
##Input Handler
Input handler stands for detection of inputs. In project, new input systems are used. When player send any input, it detects and assign variables. These leads to specified actions and change the state of player.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/10cb0666-2750-4005-a306-69b342055f6d)

##State Manager

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/08923bf1-8e71-43ae-8a4c-cae298c8be28)

“StateManager” is a script to manage state of player. “CurrentState” variable contain the script of a specified state like Idle or Walk. 
State machine is based on ScriptableObject because it easier and creates cleaner script for StateManager.
In the list named “States” all of the scriptable objects for states. When the game starts it assign the private dictionary variable named _statesByTypes. Key values are the type of classes, and the values of these keys are corresponding type of scriptable objects from States. For example, while dictionary’s first elements is assigning, the key value is type of IdleState and the value is IdleState scriptable object from States list.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/e36ed815-9185-448e-a577-244f9a86db9b)

In SetState, we send a type variable as a parameter. While the new state is assigning, the “Exit()” method of changed state. Then we assign the new state and execute the “Enter()” function.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/fc106bf5-6124-4f54-bc85-c54588bda773)

Below picture show us, we are executing functions what we want to execute. It makes the game more optimized. We can do it with booleans of course, but it allow us to have more control on state and it easier to manage it.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/f9789ba7-b9fb-4782-8ad8-dd77eb2ee60b)

Below script is a base script for all of the states. Runner is assigned to player, it allow us to reach every classes.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/b9d3a8ed-935e-474a-be02-44faa734dfd8)

Below script is the IdleState. When we change the state, I want to run specific animation and sounds for it. So, I execute them for once in “Enter()” function.
CaptureInput stands for detecting inputs. When specific input is triggered, it detects it and execute specific action for it.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/2d6758b5-4014-425b-8401-3d7241a444e1)

In update, script is calling specific functions. I want the player can detect interaction while is on idle state, it can.

For downloading the package
https://drive.google.com/file/d/15M-Co8Z5Lv5XpVX5LnK5GVj-E9IH4oKd/view?usp=sharing
