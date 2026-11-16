Case 1: "addMoney()".
--- Scenario 1 --- (adding a positive valid amount to a non-existing amount)
EXISTS - 10 USD, 5 CHF
INPUT - 7 NIS
EXPECTED OUTPUT - 10 USD, 5 CHF, 7 NIS

--- Scenario 2 --- (adding a positive valid amount to an existing amount)
EXISTS - 10 USD, 5 CHF
INPUT - 15 USD
EXPECTED OUTPUT - 25 USD, 5 CHF

--- Scenario 3 --- (adding a zero amount)
EXISTS - 10 USD, 5 CHF
INPUT - 0 USD
EXPECTED OUTPUT - 10 USD, 5 CHF

--- Scenario 4 --- (adding a negative amount that cancels out an existing currency)
EXISTS - 10 USD, 5 CHF
INPUT - (-5) CHF
EXPECTED OUTPUT - 10 USD


Case 2: "contains()".
--- Scenario 1 --- (bag contains an existing currency with the exact amount)
EXISTS - 10 USD, 5 CHF
INPUT - 10 USD
EXPECTED OUTPUT - true

--- Scenario 2 --- (bag contains the currency but the amount is different)
EXISTS - 10 USD, 5 CHF
INPUT - 15 USD
EXPECTED OUTPUT - false

--- Scenario 3 --- (bag does not contain the requested currency at all)
EXISTS - 10 USD, 5 CHF
INPUT - 7 NIS
EXPECTED OUTPUT - false (Exception Caught)

--- Scenario 4 --- (bag does not contain a zero amount of an existing currency)
EXISTS - 10 USD, 5 CHF
INPUT - 0 USD
EXPECTED OUTPUT - false