1. Launch:

Run bin\Debug\net8.0\puzzles.exe

Or open as a project using puzzles.sln.

The input file "source.txt" should be located next to "puzzles.exe".

2. Possible Settings:

If the approximate number of puzzles that can be assembled from the set is known, it can be set to speed up the search (Set searchable depth).

The maximum from the current file is 67.

The direction "right to left" is set as the default value, and in this case, it works faster.

3. Brief Description:

A linked list is used for structuring, with each node containing a puzzle.

Each time, the next puzzle from the list is used as the starting puzzle.

The algorithm builds the tree using a recursive function. In cases of branching, when multiple options can be placed, an additional alternative branch is created to continue the construction.

To find the longest branch in the tree, a recursive function is also used, which returns the longest sequence.

When the longest variant among the trees is found, the sequence is stored until a longer one is found.

4. Result:
	
	Depth: 1 - 71 68 90
	Depth: 2 - 90 56 57
	Depth: 3 - 57 77 79
	Depth: 4 - 79 43 73
	Depth: 5 - 73 55 64
	Depth: 6 - 64 82 06
	Depth: 7 - 06 40 83
	Depth: 8 - 83 06 41
	Depth: 9 - 41 70 85
	Depth: 10 - 85 10 05
	Depth: 11 - 05 10 41
	Depth: 12 - 41 21 34
	Depth: 13 - 34 32 22
	Depth: 14 - 22 97 24
	Depth: 15 - 24 60 27
	Depth: 16 - 27 97 73
	Depth: 17 - 73 72 69
	Depth: 18 - 69 90 31
	Depth: 19 - 31 56 29
	Depth: 20 - 29 42 00
	Depth: 21 - 00 71 48
	Depth: 22 - 48 83 10
	Depth: 23 - 10 88 65
	Depth: 24 - 65 84 32
	Depth: 25 - 32 27 36
	Depth: 26 - 36 74 93
	Depth: 27 - 93 91 73
	Depth: 28 - 73 09 77
	Depth: 29 - 77 54 16
	Depth: 30 - 16 92 33
	Depth: 31 - 33 14 13
	Depth: 32 - 13 93 40
	Depth: 33 - 40 17 33
	Depth: 34 - 33 79 89
	Depth: 35 - 89 00 62
	Depth: 36 - 62 02 86
	Depth: 37 - 86 14 60
	Depth: 38 - 60 56 76
	Depth: 39 - 76 73 32
	Depth: 40 - 32 46 51
	Depth: 41 - 51 90 81
	Depth: 42 - 81 63 74
	Depth: 43 - 74 92 26
	Depth: 44 - 26 50 24
	Depth: 45 - 24 97 86
	Depth: 46 - 86 87 21
	Depth: 47 - 21 75 11
	Depth: 48 - 11 53 30
	Depth: 49 - 30 38 87
	Depth: 50 - 87 11 96
	Depth: 51 - 96 12 01
	Depth: 52 - 01 31 53
	Depth: 53 - 53 51 19
	Depth: 54 - 19 35 36
	Depth: 55 - 36 87 53
	Depth: 56 - 53 75 05
	Depth: 57 - 05 12 02
	Depth: 58 - 02 21 42
	Depth: 59 - 42 77 11
	Depth: 60 - 11 71 78
	Depth: 61 - 78 11 84
	Depth: 62 - 84 75 95
	Depth: 63 - 95 86 75
	Depth: 64 - 75 88 23
	Depth: 65 - 23 14 17
	Depth: 66 - 17 07 94
	Depth: 67 - 94 25 17

	716890565777794373556482064083064170851005104121343222972460279773726990315629420071488310886584322736749391730977541692331413934017337989006202861460567673324651908163749226502497868721751153303887119612013153511935368753750512022142771171781184759586758823141707942517
