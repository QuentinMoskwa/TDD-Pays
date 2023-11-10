# TDD-Pays

Feature : Récupération des codes pays

Si le pays est bon je peux demander uniquement le code alpha-2 en string.
Si le pays est bon je peux demander uniquement le code alpha-3 en string.
Si le pays n'est pas trouvé alors il renvoit un message en string tel que "le pays rentré n'est pas dans la bdd".


Scenario : Je récupère le code alpha-2 d'un pays
GIVEN : Le pays que je demande est "FRANCE" 
WHEN : Je demande le code alpha-2 du pays
THEN : Je récupère "FR"

Scenario : Je récupère le code alpha-3 d'un pays
GIVEN : Le pays que je demande est "FRANCE" 
WHEN : Je demande le code alpha-2 du pays
THEN : Je récupère "FRA"

Scenario : Je récupère la code d'un pays qui n'existe pas
GIVEN : Le pays que je demande est "Fransse"
WHEN : Je demande le code alpha-2 du pays
THEN : Je récupère "Le code alpha-2 demandé n'as pas pu être trouvé"

Scenario : J'essaye de récupérer un code mais la donnée est inexistante 
GIVEN : Le pays que je demande est "Fransse"
WHEN : Je demande le code alpha-3 du pays
THEN : Je récupère "Le code alpha-3 demandé n'as pas pu être trouvé"