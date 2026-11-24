Case: "getRecipes() / getRecipeFull()".
--- Scenario 1 --- (verifying recipe array length, contents, and recipeFull sync after adding a recipe)
EXISTS - Empty CoffeeMaker (3 empty slots, recipeFull = [false, false, false])
INPUT - addRecipe(r1) ("Coffee"), then getRecipes() and getRecipeFull()
EXPECTED OUTPUT - addRecipe returns true; recipeArray length = 3; array contains r1 and not r2; recipeFull is true only at r1's index and false elsewhere

Case: "deleteRecipe()".
--- Scenario 1 --- (deleting an existing recipe from the CoffeeMaker)
EXISTS - r1 ("Coffee") added to the CoffeeMaker
INPUT - r1
EXPECTED OUTPUT - true

--- Scenario 2 --- (attempting to delete a null recipe)
EXISTS - CoffeeMaker after deleting r1
INPUT - null
EXPECTED OUTPUT - false

Case: "editRecipe()".
--- Scenario 1 --- (attempting to edit an existing recipe into a recipe name that already exists)
EXISTS - r1 ("Coffee") and r2 ("Mocha") in the CoffeeMaker
INPUT - oldRecipe = r1, newRecipe = r2
EXPECTED OUTPUT - false (r1 / "Coffee" is restored and still in the CoffeeMaker)

Case: "makeCoffee()".
--- Scenario 1 --- (attempting to purchase a beverage when inventory lacks enough coffee)
EXISTS - Default inventory (15 of each ingredient) and r5 added to the CoffeeMaker (r5 amtCoffee > 15)
INPUT - r5, amtPaid = 100
EXPECTED OUTPUT - 100 (beverage is not made; full amount paid is returned)

Case: "Inventory.setChocolate()".
--- Scenario 1 --- (setting chocolate inventory to a negative amount)
EXISTS - chocolate = 15
INPUT - (-1)
EXPECTED OUTPUT - 15 (negative value rejected, inventory unchanged)

Case: "Inventory.setMilk()".
--- Scenario 1 --- (setting milk inventory to a negative amount)
EXISTS - milk = 15
INPUT - (-1)
EXPECTED OUTPUT - 0 (triggers the else branch in Inventory.setMilk())

Case: "Recipe.setAmtCoffee()".
--- Scenario 1 --- (setting a recipe's coffee amount to a negative value)
EXISTS - r5.amtCoffee = 3
INPUT - (-1)
EXPECTED OUTPUT - 3 (negative value rejected, amount unchanged)

Case: "Recipe.setAmtSugar()".
--- Scenario 1 --- (setting a recipe's sugar amount to a negative value)
EXISTS - r5.amtSugar = 1
INPUT - (-1)
EXPECTED OUTPUT - 1 (negative value rejected, amount unchanged)