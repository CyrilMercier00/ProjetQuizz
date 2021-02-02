use bdd_quizz;
delete from compte where pk_compte >= 0;
ALTER TABLE compte AUTO_INCREMENT = 1;
delete from permission where pk_permission >= 0;
alter table compte auto_increment = 1;
select * from permission;
select * from compte;

ALTER TABLE compte ADD COLUMN mot_de_passe varchar(20) NOT NULL;
ALTER TABLE permission RENAME Permission;