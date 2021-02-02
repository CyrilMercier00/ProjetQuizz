use bdd_quizz;
select * from compte;

delete from compte where pk_compte >= 0;
ALTER TABLE compte AUTO_INCREMENT = 1;