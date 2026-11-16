Case: "debit()".
--- Scenario 1 --- (subtracting a valid positive amount from a non-empty balance)
EXISTS - 11.99
INPUT - 4.55
EXPECTED OUTPUT - 7.44

--- Scenario 2 --- (subtracting an amount greater than the existing balance)
EXISTS - 11.99
INPUT - 15.00
EXPECTED OUTPUT - ERROR (ArgumentOutOfRangeException)

--- Scenario 3 --- (subtracting a negative amount)
EXISTS - 11.99
INPUT - (-5.00)
EXPECTED OUTPUT - ERROR (ArgumentOutOfRangeException)

--- Scenario 4 --- (subtracting zero from a non-empty balance)
EXISTS - 1.28
INPUT - 0.00
EXPECTED OUTPUT - 1.28

--- Scenario 5 --- (attempting to debit a frozen account)
EXISTS - 10.50 (Frozen = True)
INPUT - 5.10
EXPECTED OUTPUT - ERROR (Exception: "Account frozen")
