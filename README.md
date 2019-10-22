# BigNumberCalculator
Big Number Calculator
1. Add DB file: Add a DB file in App_Data folder inside 'BigNumberCalculator' project and name it BigData.mdf
    Git do not allow to add DB(.mdf) file. 

2. Setup multiple Start Project: We have frontend (React) and backend (dot net core 2.2). Both applications are required to run.
    Right click on solution folder, go to property. 
    Select startup project under common properties. 
    Select Multiple startup projects.
    Set Start action for projects 'BigNumberCalculator' and 'BigNumberCalculator.UI
    Click Apply

3. To run test cases use test explorer. There are 90 test cases, which cover following logics for sum.
- Both numbers are positive
- Both numbers are negative
- one number is larger positive and other smaller negative
- one number is larger negative and other smaller positive
- Both numbers are positive with decimal point
- Both numbers are negative with decimal point
- one number is larger positive and other smaller negative with decimal point
- one number is larger negative and other smaller positive with decimal point
- sum of fractional parts of two numbers
- sum of integral parts of two numbers
- sum of integral parts of two numbers with carry
- convertion of 9's complement

4. I used 9's complement to subtract number.https://www.youtube.com/watch?v=UVh9T2_w_PQ

5. Calculation is not done by single function or complex algorithm. There is no complex function. Calculation logics are distributed in different classes, namely TwoPositiveNumberService, TwoNegativeNumberService and OnePositiveOneNegativeNumberService. Factory pattern is used to simplify the calculation. 

6. To connect DB and services I used repository layer with ef core and code first approch is used. Fluent API is used to increase readability

7. To add some calculation in the db load this URL miltiple times. '/api/addition/get'. This will insert some dummy data.

8. React with redux is used in front end.
