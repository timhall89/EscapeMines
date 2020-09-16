## Escape Mines
#### A turtle must escape from a minefield!!
The program will ask for a filename then read the settings from the file.

the file should contain the:
- Size of the playing board.
- The locations of mines on the board.
- The location of the exit.
- The starting position of the turtle and it's starting direction.
- 1 or more sequences of moves.

the possible moves are:
- Move: which moves the turtle to the adjacent cell in the direction it is currently facing.
- RotateRight: which rotates the turtle 90 degress to the right.
- RotateLeft: which rotates the turtle 90 degrees to the right.

the program will execut each one of the sequences of moves and output one of the following results:
- Success: The turtle has found the exit point.
- MineHit: The turtle has unfotunately hit a mine.
- OffBoard: The turlte has sadly fallen off the board.
- StillInDanger: Nothing has happeneded to the turtle, but it is still in danger.

For example a settings file with the following contents ...

	4 5
	1,1 1,3 3,3
	2 4
	1 0 N
	R M L M M
	L L M M L M
	M R M M R M M L M M

... will output the following to console ...

	=========================
	Playing on bord of size:
		- 4 x 5

	Mines are located at:
		- (1, 1)
		- (1, 3)
		- (3, 3)

	Exit is located at:
		- (2, 4)

	=========================
	Playing game number 1

	Turtle starting position:
		- (1, 0)
		- Direction: North

	Game actions:
		- RotateRight
		- Move
		- RotateLeft
		- Move
		- Move

	Result:
		- [MineHit] The turtle has unfotunately hit a mine.

	=========================
	Playing game number 2

	Turtle starting position:
		- (1, 0)
		- Direction: North

	Game actions:
		- RotateLeft
		- RotateLeft
		- Move
		- Move
		- RotateLeft
		- Move

	Result:
		- [StillInDanger] Nothing has happeneded to the turtle, but it is still in danger.

	=========================
	Playing game number 3

	Turtle starting position:
		- (1, 0)
		- Direction: North

	Game actions:
		- Move
		- RotateRight
		- Move
		- Move
		- RotateRight
		- Move
		- Move
		- RotateLeft
		- Move
		- Move

	Result:
		- [Success] The turtle has found the exit point.

`