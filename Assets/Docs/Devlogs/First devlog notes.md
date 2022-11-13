Funny because there actually is a first devlog and it's not anything like this :)

- Hi, I’m Trent
- I am going to make a game before December 16th
- I've started to notice one very essential aspect of creating games that seems to be missing across the board in devlog series and other gamedev content is the process of design
	- There has been a recent wave of open world survival RPG projects-
	- You don’t need to spend much time explaining why the player should have an inventory screen, be able to fight enemy camps for loot, have a stamina bar, because these are all staples in a well-established genre
	- Because of this, a novice dev can spend more time worrying about how to implement these mechanics and represent that progress in a video rather than fretting over the why
	- Obviosuly nothing wrong with this. If as a dev you’re mainly interested in developing skills while documenting the journey, these seemingly ambitious projects are a near perfect fit
	- However that these types of videos seem to be starting to oughtweigh devlogs that are concerned with the why- the design behind the games

- And so, my own aspiration is to create a few devlogs to document my full journey of making this game- starting with the idea. I think it is important to get into the minutiae of mechanics that we usually take for granted like inventory systems and physics. If I can develop an understanding of why certain interactions are near standard across countless titles, then maybe I can ask questions to break those standards and create something unexpectedly fun.

- Here’s the situation:
	- I want to create and publish a game before my co-op work term is over
	- I work as a QA/junior dev full time, so I am restricted to evenings and weekends to make progress

- The plan:
	- The final product will be a desktop experience built in Unity
	- No major features will be implemented and declared finished without writing specification in a design document

- I’ve put in a few hours of work at this point and I’m ready to show off my progress- Here is my game so far
	- (Default Unity project)
	- Hold on, where is the game?
	- (Obsidian) It’s over here!
	- (Trello) and here!
	- I have a habit of making games straight from the brain. Now that I have experience being on a team in school and work, I see the value in excessive documentation
	- Programming is fun, but this time I am more interested in designing the game- And so, for this project I will be creating formal-ish documents to lay out the mechanics and world of this game. I’m basically trying to make a game without actually making it.
	- My hope is that this process will make the implementation side of things easier- separating the thinking from the doing should stop me from getting whatever the programmer’s equivalent of writer’s block is

- So what is the game that I’m designing?
	- The primary idea behind this game goes back to what I mentioned about questioning well-established staple mechanics- namely, items and inventory
	- You can pick just about any game that has an inventory system, and at a high level the design is almost always the same
		- “Items” are an a simplification of a physical object that you can carry
			- What these items do vary wildly between games, but here’ we’re focussing on how they exist in inventory space
		- “Inventory” is an abstract space that can store items
			- This inventory space has some limitation such as size, weight, or quantity
		- In many games, items can exist in the game world physical space as well as the abstract inventory space that the player sees as UI
			- Minecraft, Terraria, Factorio, Diablo, to name a few
		- As I learned during the GMTK 2018 jam, some very interesting ideas can come by taking away things from well-established ideas. In that jam, I removed gravity from the platformer genre, and ended up with a fun little puzzle movement game.
		- For this game, I want to remove one aspect from the familiar inventory system: limitation
		- What if you had a bottomless bag- an inventory that could store infinite items?
	- Removing a limited capacity brings up some interesting side effects
		- Will the bag infinitely stretch to fit items?
		- Will the weight of growing items infinitely hinder the player’s movement?
		- This creates an interesting opportunity to allow the player to constantly make decisions: Carrying more items provides more utility but lowers mobility, traveling lightly increases mobility but lowers utility
	- What kind of game would you need to put lots of things in a bag?
		- My current idea is a game about stealing things- getting to a job site, using items you take in to navigate around, grab valuables, and navigate out.