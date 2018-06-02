- [x] Add GameData class
	- [x] assist class for items such as team structure
	- [x] Team structure -> Simplified for current time being
		- [x] string Name
		- [x] int score
	- [x] Use list to hold structures - more powerful and useful
    - Now using Classes to hold sessions and a list inside the class will hold the structures, allowing for theoretically infinite sessions
    - [ ] Get GUI update working
      - [x] Fix wierd session issue (Session 1 loads, session 2 click keeps session 1, session 1 click loads session 2)
        - Was no problem, just log4net config issue
    - [x] Create session Persistence (load/save)
      - Needed to get session display system working
    - [ ] Create session creation interface
- [x] Add networking class
  - [ ] Get networking working to old client
    - Make toggle to switch between old and new client (both cannot run at same time potentially?)
  - [ ] Get networking to new client
- [ ] Get networking class to work correctly with current scoreboard program
- [ ] Get other classes to interact with networking class properly

***Achieve above before working on below***
- [ ] Create match list window
	* Use a scrollable list instead of big window -> easier to view and smaller window required
- [ ] Create Log file generating class

**Ensure any savable data gets stored to %appdata% and not the working directory**