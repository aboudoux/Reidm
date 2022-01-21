Feature: Etude des immeubles

Cett fonctionnalité permet de gérer les immeubles à étudier, c'est à dire la collecte des informations
pour prendre une décision d'achat.
pour l'instant il n'y a pas de traitement spécifique. juste de l'enregistrement de données issues du terrain.


Scenario: Ajout d'un nouvel immeuble a étudier
	Given Aucun immeuble n'est à étudier
	When J'ajoute un nouvel immeuble a étudier du nom de "TEST IMMEUBLE"
	Then Un nouvel immeuble nommé "TEST IMMEUBLE" est à étudier.

Scenario: Modification des informations d'un immeuble
	Given Une liste d'immeubles à étuder
	| Immeuble |
	| TEST1    |
	When Je modifie la valeur "Surface" de l'immeuble "TEST1" en 20
	And Je modifie la valeur "BuildYear" de l'immeuble "TEST1" en 2005
	And Je modifie la valeur "PropertyTax" de l'immeuble "TEST1" en 2700
	And Je modifie la valeur "SellingPrice" de l'immeuble "TEST1" en 300000
	And Je modifie la valeur "Address" de l'immeuble "TEST1" en "12 rue du test"
	And Je modifie la valeur "Comments" de l'immeuble "TEST1" en "recemment rénové"
	And Je modifie la valeur "LastWorks" de l'immeuble "TEST1" en "Chambre enfant refaite"
	And Je modifie la valeur "WantAddLink" de l'immeuble "TEST1" en "http://test.com"
	And Je modifie la valeur "Attics" de l'immeuble "TEST1" en true
	And Je modifie la valeur "Basement" de l'immeuble "TEST1" en true
	And Je modifie la valeur "ClassifiedArea" de l'immeuble "TEST1" en true
	And Je modifie la valeur "SeparateElectricMeters" de l'immeuble "TEST1" en true
	And Je modifie la valeur "SeparateWaterMeters" de l'immeuble "TEST1" en true
	And Je modifie la valeur "SewageServices" de l'immeuble "TEST1" en true
	And Je modifie la valeur "TownGas" de l'immeuble "TEST1" en true
	
	Then L'information "Surface" de l'immeuble "TEST1" à pour valeur 20
	And L'information "BuildYear" de l'immeuble "TEST1" à pour valeur 2005
	And L'information "PropertyTax" de l'immeuble "TEST1" à pour valeur 2700
	And L'information "SellingPrice" de l'immeuble "TEST1" à pour valeur 300000
	And L'information "Address" de l'immeuble "TEST1" à pour valeur "12 rue du test"
	And L'information "Comments" de l'immeuble "TEST1" à pour valeur "recemment rénové"
	And L'information "LastWorks" de l'immeuble "TEST1" à pour valeur "Chambre enfant refaite"
	And L'information "WantAddLink" de l'immeuble "TEST1" à pour valeur "http://test.com"
	And L'information "Attics" de l'immeuble "TEST1" à pour valeur true
	And L'information "Basement" de l'immeuble "TEST1" à pour valeur true
	And L'information "ClassifiedArea" de l'immeuble "TEST1" à pour valeur true
	And L'information "SeparateElectricMeters" de l'immeuble "TEST1" à pour valeur true
	And L'information "SeparateWaterMeters" de l'immeuble "TEST1" à pour valeur true
	And L'information "SewageServices" de l'immeuble "TEST1" à pour valeur true
	And L'information "TownGas" de l'immeuble "TEST1" à pour valeur true

Scenario: Liste des immeubles avec details sur prix et surface
Given Aucun immeuble n'est à étudier
	And J'ajoute un nouvel immeuble a étudier du nom de "TEST1"
	And Je modifie la valeur "Surface" de l'immeuble "TEST1" en 20
	And Je modifie la valeur "SellingPrice" de l'immeuble "TEST1" en 300000

	And J'ajoute un nouvel immeuble a étudier du nom de "TEST2"
	And Je modifie la valeur "Surface" de l'immeuble "TEST2" en 12
	And Je modifie la valeur "SellingPrice" de l'immeuble "TEST2" en 250000
Then La liste des immeubles à étudier est
| Immeuble | Surface | SellingPrice |
| TEST1    | 20      | 300000       |
| TEST2    | 12      | 250000       |