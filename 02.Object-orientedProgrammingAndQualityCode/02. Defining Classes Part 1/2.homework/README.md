Create your own simple Console Game
1. Define a class Hero that holds information about your character: name, health, level, mana, strength, 
	agility, intelligence, primaryAttribute (as an enumeration, one of the previous 3), isBlocking, isDead, 
	class (Sorcerer, Fighter, Tank), Weapon (class) and Armor(class).
2. Define a class Weapon which holds the following information: type (enumeration – Sword, Hammer, Staff, etc. ), 
	class (common, rare, mythical), damage.
3. Define a class Armor which holds the following information: damageBlock, type (cask, shield etc), 
	class (same as above).
4. Define several constructors for each class. Validate some of the properties. Use constants where necessary –
	don’t leave magical numbers in the code.
5. Define methods for each hero: Attack(Hero heroToAttack), TakeDamage(int damage), Block(). Attack should be clear. 
	TakeDamage should reduce the health of the Hero but take into consideration the Armor (damageBlock). 
	Block should trigger the isBlocking member. Whenever isBlocking is active the damageBlock is doubled. 
	If isBlocking is activated, the attack for the next turn is decreased by 30% (after that it is restored). 
	Hint: You should think which method should check this condition.
6. Each method should display an update in the console of the current action and all changes after that. 
	E.g. Attack() should display a message “Hero1 attacking Hero2. Hero2 has taken 30 damage …”. 
	Hint: You can override the ToString() method to help you with the current state.
7. Test your application: Create 3 heroes, one from each class with the corresponding values, Armor and Weapon. 
	Make a battle between them with repeated operations of attacking and blocking (in a while loop) and display 
	who wins. To make it more interesting you can decide randomly which hero attacks, which hero is attacked and 
	which hero blocks. Also, use Thread.Sleep() or UserInput between steps so that it is clear what is happening.
