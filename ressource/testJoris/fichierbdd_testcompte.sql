use bdd_quizz;
delete from compte where pk_compte >= 0;
ALTER TABLE compte AUTO_INCREMENT = 1;
delete from permission where pk_permission >= 0;
alter table permission auto_increment = 1;
select * from permission;
select * from compte;