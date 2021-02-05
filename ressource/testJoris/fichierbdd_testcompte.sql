use bdd_quizz;
delete from compte where pk_compte >= 0;
ALTER TABLE compte AUTO_INCREMENT = 1;
delete from permission where pk_permission >= 0;
alter table permission auto_increment = 1;
insert into permission(generer_quizz, ajouter_quest, modifier_quest, suppr_question)
	values (true, true, true, true), (true, false, false, false), (false, false, false, false);

select * from compte;
select * from permission;