### Description
This is an implementation of https://github.com/davidwhitney/CodeDojos/tree/master/Diamond%20Kata

### Implementation
* The app only accepts a character in the alphabet (upper or lower cased)
* This is a simple implementation of an "alphabet diamond builder"
  * The input is validated to make sure it is a valid character in the alphabet. If invalid, a simple error text is returned.
  * Once validated, the diamond length is computed (Note that the vertical and horizantal length will always be the same)
  * Each line is then built. The character(s) expected in each line is placed in its expected position. The rest are filled with a space.
  * Once all lines are built, they are joined together and returned to the console app to be displayed.

### Unit testing
* TestCaseSource was used to hold the different test case scenarios for valid inputs and other properties that will aid the unit test (Contains only upper cased input)
* The combination of the below test cases/scenarios should ensure that the structure and the characters in the diamond will be correct.

The following unit tests were added:
* Invalid scenarios - invalid input
* Diamond length tests
* Character count tests
* Character position tests

##### Diamond length tests
Given that the diamond's vertical and horizontal length will be the same regardless of the input, tests/test cases were added to make sure that the diamond's structure is correct. <br />
Sample input: C <br />
Expected output: <br />

        A
       B B
      C   C
       B B
        A
  
    
The vertical length (5) is asserted as well as the line's length (5).

There are 2 test methods written, both getting the test cases from the TestCaseSource. The difference is that the 2nd method only converts the input to a lower case character. 

##### Character count tests
Regardless of the input, the diamond will always have one character at both end lines (top and bottom) once the newline and spacers are removed. And the rest of the lines will always have 2, once the newline and spacers are moved.
As with the example above, the end lines (index 0 and 4) will always have 1 character (A). The rest (index 1 to 3) will always have 2.

As with the above, there are 2 test methods written, both getting the test cases from the TestCaseSource. The difference is that the 2nd method only converts the input to a lower case character. 

##### Character position tests
Originally I tried to do this test by comparing the actual result to the expected output. But this made the test case source a bit cumbersome and a little hard to maintain and read. So I opted to write the tests by asserting that the expected character is in its correct position(s) in the line.
Given the same example above, the following were asserted
* The top and bottom lines (index 0 and 4) will always contain the first character (A) in the middle (position 2).
* The middle line (index 2) will always contain the given character (C) in the first and last positions of the line.
* For the other lines in the diamond, the assertion is that the next expected character (in the example B) will be in line index 1 and line index 3 at positions 1 and 3. The same checks are done for the next character if needed. 

So given a different example, character D is provided, the following are asserted:
 * The top and bottom lines (index 0 and 6) should always contain the first character (A) in the middle (position 3).
 * The middle line (index 3) should always contain the given character (D) in the first and last positions of the line.
 * Character B will be at line index 1 and 5 at positions 2 and 4.
 * Character C will be at line index 2 and 4 at positions 1 and 5.

As with the others, there are 2 test methods written, both getting the test cases from the TestCaseSource. The difference is that the 2nd method only converts the input to a lower case character. 
