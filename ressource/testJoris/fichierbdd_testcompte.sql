use bdd_quizz;
delete from compte where pk_compte >= 0;
ALTER TABLE compte AUTO_INCREMENT = 1;
delete from permission where pk_permission >= 0;
alter table permission auto_increment = 1;
insert into permission(nom, generer_quizz, ajouter_quest, modifier_quest, modifier_compte, suppr_question, supprimer_compte)
	values ('Administrateur', true, true, true, true, true, true), 
    ('Recruteur', true, true, true, false, true, false), 
    ('Candidat', false, false, false, false, false, false);

select * from compte;
select * from permission;