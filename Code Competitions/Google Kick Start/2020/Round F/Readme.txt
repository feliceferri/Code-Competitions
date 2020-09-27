Google Kick Start 2020 Round F

Problem #1  - ATM QUEUE
https://codingcompetitions.withgoogle.com/kickstart/round/000000000019ff48/00000000003f4ed8

* Note: The statement is presented as a regular queue, but this is about sorting, not about queuing, I code it first as a regular queue and pass the first set of tests, but failed at the second one because Time Exceeding Limit.

The idea basically is create a data structure where you can save the Original place in the line, and also compute the time it has to cycle through the line Math.Ceiling(Amount to withdraw / max allowed to be withrowed)
Then Sort the data by Number of Cycles and the by Original Place in the line.
And that's it.

O(N Log N) | O(N)   *Because of Sorting


Problem #2 - METAL HARVESTING https://codingcompetitions.withgoogle.com/kickstart/round/000000000019ff48/00000000003f4b8b

As in Problem #1, the code needs to calculate cycles Math.Ceiling(Harvesting Time/Max Robot Harvest Time) in order to pass Test Case 2

O(N Log N) | O(N)   *Because of Sorting
