# BigNumberCalculator
Big Number Calculator
1. Add DB file: Add a DB file in App_Data folder inside 'BigNumberCalculator' project and name it BigData.mdf
    Git do not allow us to add DB(.mdf) file. 

2. Setup multiple Start Project: We have frontend (React) and backend (dot net core 2.2). Both applications are required to run.
    Right click on solution folder, go to property. 
    Select startup project under common properties. 
    Select Multiple startup projects.
    Set Start action for projects 'BigNumberCalculator' and 'BigNumberCalculator.UI
    Click Apply

3. To run test cases use test explorer.
