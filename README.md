### Description
This is an implementation of https://github.com/davidwhitney/CodeDojos/tree/master/Diamond%20Kata

### Implementation
- The app only accepts a character in the alphabet (upper or lower cased)
- This is a simple implementation of an "alphabet diamond builder"
-- The input is validated to make sure it is a valid character in the alphabet. If invalid, a simple error text is returned.
-- Once validated, the diamond length is computed (Note that the vertical and horizantal length will always be the same)
-- Each line is then built. The character(s) expected in each line is placed in its expected position
-- Once all lines are built, they are joined together using StringBuilder and returned to the console app to be displayed.

### Unit testing
