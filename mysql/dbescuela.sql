CREATE DATABASE db_escuela;

use db_escuela;

create table depart (
dept varchar(4) not null,
dedif varchar(2),
ddespacho int,
dchfno varchar(3) );

select * from depart;

insert into depart (dept,dedif,ddespacho,dchfno)
values ('THEO','HU',200,'110'),
('CIS','SC',300,'80'),
('D.G','SC',100,null),
('PHIL','HU',100,'60');


create table curso (
cno varchar(3) not null,
cnombre varchar(35) not null,
cdescp varchar(30) not null,
cred int,
ctarifa decimal(5,2),
cdept varchar(4) );

select * from curso;

insert into curso (cno,cnombre,cdescp,cred,ctarifa,cdept)
values ('C11', 'INTROD. DE CC.', 'PARA NOVATOS', 3, 100.00, 'CIS'),
('C33', 'MATEMATICAS DISCRETAS', 'MUY UTIL', 3, 0.00, 'CIS'),
('P11', 'RAZONAMIENTO DEDUCTIVO', 'ABSOLUTAMENTE NECESARIO', 3, 0.00, 'PHIL'),
('C55', 'ARQUITECT. COMPUTADORES', 'MAQ. VON NEUMANN', 3, 100.00, 'CIS'),
('C54', 'BASES DE DATOS RELACIONALES', 'IMPRESCINDIBLE', 3, 500.00, 'PHIL'),
('P21', 'EMPIRISMO', 'VERLO PARA CREERLO', 3, 50.00, 'PHIL'),
('P33', 'EXISTENCIALISMO', 'PARA USARLOS CIS', 3, 50.00, 'PHIL'),
('T11', 'ESCOLASTICISMO', 'PARA MI MISMO', 6, 0.00, 'THEO'),
('T12', 'FUNDAMENTALISMO', 'PARA DESCUIDADOS', 3, 90.00, 'THEO'),
('T33', 'HEDONISMO', 'PARA AVAROS', 3, 90.00, 'THEO'),
('T44', 'COMUNISMO', 'PARA AVAROS', 6, 300.00, 'THEO');

create table clase (
cno char(3) not null,
sec char(2) not null,
cinstrfno varchar(10) not null,
cdia varchar(10) not null,
chora char(14) not null,
cedif char(2) not null,
cdesp int not null);

select * from clase;

insert into clase (cno,sec,cinstrfno,cdia,chora,cedif,cdesp)
values ('C11','01','08','Lu','08:00-09:00 AM','SC',305),
('C11','02','08','Ma','08:00-09:00 AM','SC',306),
('C33','01','80','Mi','09:00-10:00 AM','SC',305),
('C55','01','85','Ju','11:00-12:00 AM','HU',306),
('P11','01','06','Ju','09:00-10:00 AM','HU',102),
('P33','01','06','Vi','11:00-12:00 AM','HU',201),
('T11','01','10','Lu','10:00-11:00 AM','HU',101),
('T11','02','65','Lu','10:00-11:00 AM','HU',102),
('T33','01','65','Mi','11:00-12:00 AM','HU',101);


create table matricula (
cno varchar(3) not null,
sec varchar(2) not null,
sno varchar(3),
fec_mat date,
hora_mat time );

select * from matricula;

insert into matricula (cno,sec,sno,fec_mat,hora_mat)
values ('C11','01','325','1987-01-04','09:41:30'),
('C11','01','800','1987-12-15','11:49:00'),
('C11','02','100','1987-12-17','09:32:00'),
('C11','02','150','1987-12-17','09:32:30'),
('P33','01','100','1987-12-23','11:30:00'),
('P33','01','800','1987-12-23','11:23:00'),
('T11','01','100','1987-12-23','11:21:00'),
('T11','01','150','1987-12-15','11:35:30'),
('T11','01','800','1987-12-15','14:00:00');


create table estudiante (
sno char(3) not null,
snombre char(30) not null,
sdomi varchar(15) not null,
stlfno char(12) not null,
sfnacim char(6) not null,
siq smallint not null,
sadvfno char(3) not null,
sesp char(4) not null );

select * from estudiante;

insert into estudiante (sno,snombre,sdomi,stlfno,sfnacim,siq,sadvfno,sesp)
values ('325','Curley Dubay','Connecticut','203-123-4567','780517',122,'10','THEO'),
('150','Larry Dubay','Connecticut','203-123-4567','780517',121,'80','CIS'),
('100','Moe Dubay','Connecticut','203-123-4567','780517',120,'10','THEO'),
('800','Rocky Balboa','CpENNSYLVANIA','112-112-1122','461004',99,'60','PHIL');


create table personal (
enombre char(15) not null,  
cargo char(10) not null, 
esueldo integer not null, 
dept char(4));

select * from personal;

insert into personal (enombre,cargo,esueldo,dept)
values ('LUCAS','EVANG1',53,'THEO'),
('MARCOS','EVANG2',52,'THEO'),
('MATEO','EVANG3',51,'THEO'),
('DICK NIX','LADRÓN',25001,'PHIL'),
('HANK KISS','BUFÓN',25000,'PHIL'),
('JUAN','EVANG4',54,'THEO'),
('EUCLIDES','AYTE. LAB.',1000,'D.G'),
('ARQUIMEDES','AYTE. LAB.',200,'ENG'),
('DA VINCI','AYTE. LAB.',500,null);


create table claustro (
fno varchar(3) not null,
fnombre  char(15) not null,
fdomi varchar(25),
ffcanti date,
fnumbep smallint,
fsueldo decimal(7,2),
fdep char(4) );

select * from claustro;

insert into claustro (fno,fnombre,fdomi,ffcanti,fnumbep,fsueldo,fdep)
values ('06','KATHY PEPE','CALLE DE LA PIEDRA, 7','1979-01-15',null,35000.00,'PHIL'),
('10','JESSIE MARTIN','DR. DEL ESTE, 4','1969-09-01',null,45000.00,'THEO'),
('08','JOSE COHN','APTDO. CORREOS 1138','1979-07-09',null,35000.00,'CIS'),
('85','AL HARTLEY','CALLE DE LA PLATA','1979-09-05',null,45000.00,'CS'),
('60','JULIA MARTIN','DR. ESTE, 4','1969-09-01',null,45000.00,'PHIL'),
('65','LISA BOBAK','CAMINO DE LA RISA, 77','1981-09-06',null,36000.00,'THEO'),
('80','BARB HLAVATY','CALLE DEL SUR, 489','1982-01-16',null,35000.00,'CIS');




USE db_escuela;


SELECT
    p.enombre,
    p.esueldo,
    c.ctarifa,
    (c.ctarifa - p.esueldo) AS diferencia
FROM
    personal AS p,
    curso AS c
WHERE
    p.dept = c.cdept
    AND (c.ctarifa - p.esueldo) >= 52;

