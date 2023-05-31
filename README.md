# First Person Player Controller For Unity
Assets folder contains all of the scripts, audios, animations, models, particles for player. I tried to use MVC and State Machine patterns for my player script. All the audios and animations are placeholders. You can change it any time for usage.
Animations and models are from https://www.mixamo.com/
All audios are from https://freesound.org/.

![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/1348cb08-15a8-4203-a215-44c01fdc6cc2)
Above picture shows that all the components that my character has. Player contains all of the component classes. It allows other classes to reach all of the scripts.

##Player Controller
In player controller, there are regular classes to handle specified actions.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/e839513a-40ee-4ac9-a098-f6a4670611f0)

BaseController class is a generic class for inherit other classes.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/a7a9f337-7896-42d4-b8ec-182bad839792)

Base controller send player variable to all controllers.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/68ecf3d7-cbc6-4ee8-84bf-d9c3814ba2cb)

In construction, I assign this parameter to Runner variable. It allows all scripts can reach player variables. For example, in “HandleMovement” class you need to assign some variables like speed. We can create these variables in same script but it prevents customization and seperate all the variables. It is easier to alter variables from one source like “PlayerModel” component.
##Player Model
PlayerModel stands for to contain all of the data like speed, health, sounds etc.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/4a52b013-7298-4ed1-93ac-ffae7edc74c4)

All of the other objects can reach these variables. Anyone who is a designer can change the values whatever they want from model script. To make this model more easier to reach spesific fields like movement variables or health variables, I create serializable regular C# classes. For example, “Stamina” class looks like this.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/528a0ba6-8878-4e06-928a-9f9105c9b7a8)

##Player View
Player view contains all of the view scripts for ground detection and interaction detection.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/971bf0bf-0aba-452a-bc65-e065a3b50174)

View is a base class like “BaseController” class. Player view contains all specified classes. GroundView stands for detecting ground with raycast. Whenever the raycast return nothing, it changes a variable in PlayerModel named “isOnGround”. Whenever the isOnGround variable is changed, it changes the state of player to fallState.
##Input Handler
Input handler stands for detection of inputs. In project, new input systems are used. When player send any input, it detects and assign variables. These leads to specified actions and change the state of player.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/56f88255-67d7-4e1a-b98d-c21ede1bc68e)

##State Manager
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/fc4d563b-558b-4d63-9108-2ac4f4102c8c)

“StateManager” is a script to manage state of player. “CurrentState” variable contain the script of a specified state like Idle or Walk. 
State machine is based on ScriptableObject because it easier and creates cleaner script for StateManager.
In the list named “States” all of the scriptable objects for states. When the game starts it assign the private dictionary variable named _statesByTypes. Key values are the type of classes, and the values of these keys are corresponding type of scriptable objects from States. For example, while dictionary’s first elements is assigning, the key value is type of IdleState and the value is IdleState scriptable object from States list.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/6801ae38-ab19-4034-afc3-164fe27674cf)

In SetState, we send a type variable as a parameter. While the new state is assigning, the “Exit()” method of changed state. Then we assign the new state and execute the “Enter()” function.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/fb75537f-27fc-4f28-b91c-0bc18b98bf88)

Below picture show us, we are executing functions what we want to execute. It makes the game more optimized. We can do it with booleans of course, but it allow us to have more control on state and it easier to manage it.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/d92bffcf-64a6-4f4e-8767-e39a5f76acd4)

Below script is a base script for all of the states. Runner is assigned to player, it allow us to reach every classes.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/214bf03a-d2c0-413e-8543-5a0fe969cdca)

Below script is the IdleState. When we change the state, I want to run specific animation and sounds for it. So, I execute them for once in “Enter()” function.
CaptureInput stands for detecting inputs. When specific input is triggered, it detects it and execute specific action for it.
![image](https://github.com/Bolzac/FPS_Shooter/assets/70448242/37953e69-5371-4230-8b21-26a39198ff11)

In update, script is calling specific functions. I want the player can detect interaction while is on idle state, it can.
