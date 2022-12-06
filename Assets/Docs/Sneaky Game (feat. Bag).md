# Introduction

This is a stealth game?

# Gameplay
The order of importance for the player in the game’s loops are as follows:
* Navigate levels avoiding attention and collecting


## The Bag
The core mechanic of the game is the magical bottomless bag. Gameplay areas contain items which can be picked up by the player, and stored in the bag with an infinite inventory space. As the bag is filled, certain properties of the bag will change.

![](https://lh4.googleusercontent.com/6XrIGBaYOKYazruJGSkX0oX7lwTqHArgLI2_dPOWSpw3_njfSA80sNTOG0Nfl-BC5Nx98A9R88pVMOoGoiwkqS3np_-jGIg12ud05Ne1AeIfqPIbhlyo5hQQUb4VFCok7QWs7lYctAXmd1OCmnoifVJ6JO86Pj2RUtvIG3imktepCa-2BMFbgJ7WoA)

As the bag is filled with items:
* Bag visually increases in size
* Player acceleration is reduced
	* Max speed increased?
* Bag swing has more startup time
* Bag swing has more impact
* Landing from a high fall creates more noise

>[!note]
>The goal is to create constant, interesting decision opportunities for the player. Traveling lightly will increase stealth and mobility but also limit utility options and potential payout for a job (extra valuables are also items). Gathering every item will provide maximum utility but effect movement and stealth, as well as clutter the bag's user interface making it difficult to navigate.

### Inside the bag
The bag, infinite as it is, holds a pocket universe. The interface for the bag is a physical space separate from the main gameplay area. The player can enter the bag and visit this space where they will find any items they previously stored in the bag. The bag interior has walls that stretch horizontally as more space is needed to store items.

As the player moves around, the items stored in the bag will shuffle position randomly.

While in the bag, the player is hidden, and cannot be detected by enemies. Some may become suspicious of the bag, and decide to move the bag. This is noticeable from inside the bag as footsteps are audible and the interior shuffles around in response.


## Items
The environments of the main gameplay areas will contain physical item objects. These objects can be picked up by the player, and stored in the bag. All items take up physical size, and have a mass stat to reflect their size. On collision with terrain, items will make noise based on current speed and mass.

Notable types of items include:
* Utility/mobility items
    * Ropes which can be tied to connect items
    * Ladders 
* Simple physics objects
    * Can be used as audio distraction or weaponry
* Treasures
    * Valuables which once taken out of a level contribute towards the score/overall progression

## Progress

### Failure
If the player is caught on a job site, the consequence is losing all materials currently carried in the bag. The scenes transition from the current level to a police station where they are released after some implied period of time. The bag is returned to the player empty, and the player can leave the station and return to the world map.

# Space, Time, and the World

The game has 3 primary spatial contexts:
* 2D user interface for navigating between primary game scenes
* 2D world map serving as a transition between main gameplay sections and contextualizing the world environments 
* 2D platforming space of main gameplay areas

## User Interface
* Basic menu to transition from application launch to get in game
* Transition from level end?
    * Maybe world map
* Low priority

## World Map
A world map styled after modern digital city maps with UI indications of different visitable locations.


## Main Gameplay Areas
The topology of the main game is a 2D plane, like traditional 2D platformers. The player’s view is the main camera, a cropped view of the environment constrained to the extents of that environment.
![](https://lh5.googleusercontent.com/bMyfCaDOxOCK3CqTF0YmkBewPVyep-QtxAQ42lZnYp0g43aQBVhdcJo7dLekCWlPiMaSw29hJLH3RQK7UC-y3ux8pvqDRKNzIhnEBM9ZSe8BAXHiFWbiYHXpkQ1hxOGRx77HyVCKMMs8ilhbiVjOgQrZRyOXfcq2sHzXom32UbP9QyNmEhZMwVGK6A)
1. The full loaded scene; a section of the game’s world, a level navigable by the player character
2. The camera’s cropped view focussing on the player character, constrained by the level’s bounds.
3. The act of the player crossing the level’s bounds, beyond the camera’s view, is contextualized as leaving the area and switching to the world map

### The Stache
One of the visitable areas on the world map, central in location and always accessible. Serves as a sort of hub/playground for the player. Items placed in this area persist permanently, and so can be useful as a storage facility for objects carried after exiting job sites.

### Job Sites
The rest of the visitable areas on the world map are the job sites, 

