#core
# Stealth Systems
These are the systems which contribute towards the player's use of stealth
## Noise System
All interactions that make noise can be heard by listeners. Noises can be heard auditorily by the player with varying sound effects based on what interaction is causing the noise. Noises are also represented visually as a circle emanating outwards from its central point. This circle has a radius based on the perceived volume of the noise. Listeners within this radius will hear the noise and can react.
In addition to a radius representing the range a noise can be perceived, noises also have a **severity** floating point value ranging from 0 to 1, with 1 being high severity. Listeners will be able to use this value in consideration for their reaction to perceiving a noise.
![[Pasted image 20221217135948.png]]
In this image:
1. An object is thrown by the player and collides with the environment at speed
2. A noise is played, and a visible radius emanates from the point of impact
3. A listener within the radius of the noise perceives the noise and is able to react
### Noise makers
These are sources of noise:
- Any #item colliding with terrain, with volume varying based on speed
- The [[Player Character]] taking steps, with volume varying on amount of items in bag
- The player landing from the air, with volume varying on amount of items in bag
- Other characters taking steps
- Other characters landing from the air
### Noise listeners
These are able to perceive noise when within a radius of a playing noise and react according to their implementation
- Guards
## Enemy patrols
Enemy characters exist within levels and have a specified path which they regularly patrol.