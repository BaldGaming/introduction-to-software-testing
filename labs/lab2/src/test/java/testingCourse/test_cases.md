Case 1: "It works".
--- Scenario 1 --- (adding a positive valid amount to a non-existing amount)
EXISTS - 5 NIS
INPUT - 10 USD
EXPECTED OUTPUT - 5 NIS, 10 USD
<!-- 
--- Scenario 2 --- (adding a positive valid amount to an existing amount)
EXISTS - 10 USD, 5 NIS
INPUT - 10 USD
EXPECTED OUTPUT - 20 USD, 5 NIS -->

---Scenario 3 --- (adding a zero)
EXISTS - 10 USD, 5 NIS
INPUT - 0 USD
EXPECTED OUTPUT - 10 USD, 5 NIS

--- Scenario 4 --- (subtracting a valid amount to a non-existing amount)
EXISTS - 5 NIS
INPUT - (-10) USD
EXPECTED OUTPUT - 5 NIS, (-10) USD

<!-- --- Scenario 5 --- (subtracting a valid amount to an existing amount)
EXISTS - 10 USD, 5 NIS
INPUT - (-10) USD
EXPECTED OUTPUT - 5 NIS -->

--- Scenario 6 --- (subtracting a zero)
EXISTS - 10 USD, 5 NIS
INPUT - (-0) USD
EXPECTED OUTPUT - 10 USD, 5 NIS


Case 2: "It doesn't work".
--- Scenario 1 --- (adding Null)
EXISTS - 10 USD
INPUT - Null
EXPECTED OUTPUT - ERROR (of some sort)

--- Scenario 2 --- (subtracting Null)
EXISTS - 10 USD
INPUT - Null
EXPECTED OUTPUT - ERROR (of some sort)

--- Scenario 3 --- (adding a non-integer)
EXISTS - 10 USD
INPUT - 1.5 USD
EXPECTED OUTPUT - ERROR (of some sort)

--- Scenario 4 --- (subtracting a non-integer)
EXISTS - 10 USD
INPUT - (-1.5) USD
EXPECTED OUTPUT - ERROR (of some sort)