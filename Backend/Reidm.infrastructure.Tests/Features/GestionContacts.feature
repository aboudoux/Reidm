Feature: Gestion des contacts

Module permettant de gerer les contacts dans l'application

Scenario: Ajout d'un nouveau contact
	Given Aucun contact n'est visible dans l'application
	When J'ajoute un nouveau contact du nom de "MR TEST"
	Then La liste des contacts est
	| Name    | Phone | Email |
	| MR TEST |       |       |

Scenario: Modification d'un contact
	Given Aucun contact n'est visible dans l'application
	And J'ajoute un nouveau contact du nom de "TEST1"
	And J'ajoute un nouveau contact du nom de "TEST2"
	When Je modifie la valeur "Phone" du contact "TEST1" en "01.01.01.01.01"
	And Je modifie la valeur "Email" du contact "TEST1" en "TEST1@TEST1.com"
	And Je modifie la valeur "Phone" du contact "TEST2" en "02.02.02.02.02"
	And Je modifie la valeur "Email" du contact "TEST2" en "TEST2@TEST2.com"
	Then La liste des contacts est
	| Name  | Phone          | Email           |
	| TEST1 | 01.01.01.01.01 | TEST1@TEST1.com |
	| TEST2 | 02.02.02.02.02 | TEST2@TEST2.com |

Scenario: Suppression d'un contact

