Feature: Gestion des contacts

Module permettant de gerer les contacts dans l'application

Scenario: Ajout d'un nouveau contact
	Given Aucun contact n'est visible dans l'application
	When J'ajoute un nouveau contact du nom de "MR TEST"
	Then La liste des contacts est
	| Name    | Phone | Email | Quality | Infos |
	| MR TEST |       |       |         |       |

Scenario: Modification d'un contact
	Given Aucun contact n'est visible dans l'application
	And J'ajoute un nouveau contact du nom de "TEST1"
	And J'ajoute un nouveau contact du nom de "TEST2"
	When Je modifie la valeur "Phone" du contact "TEST1" en "01.01.01.01.01"
	And Je modifie la valeur "Email" du contact "TEST1" en "TEST1@TEST1.com"
	And Je modifie la valeur "Quality" du contact "TEST1" en "Propriétaire"
	And Je modifie la valeur "Infos" du contact "TEST1" en "test 1"
	And Je modifie la valeur "Name" du contact "TEST1" en "LOL1"

	And Je modifie la valeur "Phone" du contact "TEST2" en "02.02.02.02.02"
	And Je modifie la valeur "Email" du contact "TEST2" en "TEST2@TEST2.com"
	And Je modifie la valeur "Quality" du contact "TEST2" en "Agent"
	And Je modifie la valeur "Infos" du contact "TEST2" en "test 2"
	And Je modifie la valeur "Name" du contact "TEST2" en "LOL2"
	Then La liste des contacts est
	| Name | Phone          | Email           | Quality          | Infos  |
	| LOL1 | 01.01.01.01.01 | TEST1@TEST1.com | Propriétaire     | test 1 |
	| LOL2 | 02.02.02.02.02 | TEST2@TEST2.com | Agent immobilier | test 2 |

Scenario: Suppression d'un contact
	Given Une liste de contacts exitants
	| Name  |
	| TEST1 |
	| TEST2 |
	| TEST3 |
	When Je supprime le contact "TEST2"
	When Je supprime le contact "TEST3"
	Then La liste des contacts est
	| Name  | Phone | Email | Quality | Infos |
	| TEST1 |       |       |         |       |

