drop database dbempresa;
CREATE DATABASE dbempresa;
use dbempresa;
create table oficinas(
Oficina integer not null,
Ciudad char(15) not null,
Region char(10) not null,
Dir integer not null,
Objetivo integer,
Ventas numeric not null);
select * from oficinas;
insert into oficinas (Oficina,Ciudad,Region,Dir,Objetivo,Ventas)
values ('22','Toledo','Centro',108,27500,34432),
('11','Valencia','Este',106,52500,40063),
(12,'Barcelona','Este',104,7000,29328),
(13,'Alicate','Este',105,30000,39327),
(21,'Madrid','Centro',108,60000,81309);

create table clientes(
Numcliente integer not null,
Empresa char(50) not null,
Repcliente integer not null,
Limitecredito numeric);
select * from clientes;
insert into clientes (Numcliente,Empresa,Repcliente, Limitecredito)
values (2111,'EVBE S.A',103,50000),
(2102,'Exclusivas del Este S.L',101,65000),
(2103,'Pino S.L.','105',50000),
(2123,'Hnos. Martinez S.A.',102,40000),
(2107,'Distribuciones Sur',110,35000),
(2115,'AFS S.A.',101,20000),
(2101,'Exclusivas Soriano',106,65000),
(2112,'Lopez Asociados S.L.',108,50000),
(2121,'Hernandez & hijos S.L.',103,45000),
(2114,'Componentes Fernandez',102,20000),
(2124,'Domingo S.L.',107,40000),
(2108,'Zapater Importaciones',109,55000),
(2117,'Hnos. Ramon S.L.',106,35000),
(2122,'JPF S.L.',105,30000),
(2120,'Distribuciones Montiel',102,50000),
(2106,'Construcciones Leon',102,65000),
(2119,'Martinez & Garcia S.L.',109,25000),
(2118,'Exclusivas Norte S.A.',108,60000),
(2113,'Importaciones Martin',104,20000),
(2109,'Roda & Castedo S.L.',103,25000),
(2105,'MALB S.A.',101,45000);

create table productos (
idfab char(3) not null,
idproducto char(5) not null,
Descripcion char(20) not null,
Precio numeric not null,
Existencias integer not null);
select * from productos;
insert into productos (idfab,idproducto,Descripcion,Precio,Existencias)
values ('REI','2A45C','V Stago Trinquete',79,210),
('ACI','4100Y','Extractor',2750,25),
('QSA','XK47','Reductor',355,38),
('BIC','41672','Plate',180,0),
('IMM','779C','Riostra 2-Tm',1875,9),
('ACI','41003','Articulo Tipo 3',107,207),
('ACI','41004','Articulo Tipo 4',117,139),
('BIC','41003','Manivela',652,3),
('IMM','887P','Perno Riostra',250,24),
('QSA','XK48','Reductor',134,203),
('REI','2A44L','Bisagra Izqda.',4500,12),
('FEA','112','Cubierta',148,115),
('IMM','887H','Soporte Riostra',54,223),
('BIC','41089','Reten',225,78),
('ACI','41001','Articulo Tipo 1',55,277),
('IMM','775C','Riostra 1-Tm',1425,5),
('ACI','41007','Montador',2500,28),
('OSA','XK48A','Reductor',117,37),
('ACI','41002','Articulo Tipo 2',76,167),
('REI','2A44R','Bisagra Dcha',4500,12),
('IMM','773C','Riostra 1/2 Tm',975,28),
('ACI','4100X','Ajustador',25,37),
('FEA','114','Bancada Motor',243,15),
('IMM','887X','Retenedor Riostra',475,32),
('REI','2A44G','Pasador Bisagra',350,14);

create table pedidos (
Pedido integer not null,
Fechapedido date not null,
Clie integer not null,
Rep integer not null,
Fab char(3) not null,
Producto char(5) not null,
Cant integer not null,
Importe numeric not null);
select * from pedidos;
insert into pedidos (Pedido,Fechapedido,Clie,Rep,Fab,Producto,Cant,Importe)
values (112961,'1999-12-17',2117,106,'REI','2A44L',7,31500),
(113012,'2000-01-11',2111,105,'ACI','41003',35,3745),
(112989,'2000-01-03',2101,106,'FEA','114',6,1458),
(113051,'2000-02-10',2118,108,'QSA','XK47',4,1420),
(112968,'1999-10-12',2102,110,'ACI','41004',9,3978),
(113036,'2000-01-30',2107,110,'ACI','4100Z',9,22500),
(113045,'2000-02-02',2112,108,'REI','2A44R',10,45000),
(112963,'1999-12-17',2103,105,'ACI','41004',28,3276),
(113013,'2000-01-14',2118,108,'BIC','41003',1,652),
(113058,'2000-02-23',2108,109,'FEA','112',10,1480),
(112997,'2000-01-08',2124,107,'BIC','41003',1,652),
(112983,'1999-12-27',2103,105,'ACI','41004',6,702),
(113024,'2000-01-20',2114,108,'QSA','XK47',20,7100),
(113062,'2000-02-24',2124,107,'FEA','114',10,2430),
(112979,'1999-12-12',2114,102,'ACI','41002',6,15000),
(113027,'2000-01-22',2103,105,'ACI','41002',54,4104),
(113007,'2000-01-08',2112,108,'IMM','775C',3,2835),
(113059,'2000-02-29',2109,107,'IMM','775C',22,31350),
(113034,'2000-01-29',2107,110,'REI','2A45C',8,632),
(112992,'1999-11-04',2118,108,'ACI','41002',10,760),
(113055,'2000-02-15',2108,101,'ACI','4100Z',6,2100),
(112975,'2000-02-15',2111,103,'REI','2A44G',6,150),
(113065,'2000-02-27',2120,102,'IMM','779C',2,3750),
(113048,'2000-02-10',2106,102,'REI','2A45C',24,1896),
(112993,'2000-01-04',2106,102,'QSA','XK47',6,2130),
(113069,'2000-02-27',2102,102,'IMM','779C',6,6675),
(113003,'2000-01-25',2108,109,'QSA','XK47',2,776),
(113049,'2000-02-10',2118,108,'ACI','4100Y',11,37500),
(112987,'1999-12-31',2103,105,'ACI','4100X',24,600),
(113057,'2000-02-18',2111,103,'REI','2A44R',5,22500),
(113042,'2000-02-02',2113,101,'ACI','41003',2,22500);

create table repventas (
Numempleado integer not null,
Nombre varchar(30) not null,
Edad integer,
Oficinarep integer,
Titulo char(30),
Contrato date not null,
Director integer,
Cuota numeric,
Ventas numeric not null);
select * from repventas;
insert into repventas (Numempleado,Nombre,Edad,Oficinarep,Titulo,Contrato,Director,Cuota,Ventas)
values (106,'Jose Maldonado',52,11,'VP Ventas','1998-06-14',null,25000,32958),
(104,'Carlos Martinez',33,12,'Dir. Ventas','1997-05-19',106,17500,0),
(105,'Belen Aguirre',37,12,'Dir. Ventas','1998-02-12',106,30000,39327),
(109,'Maria Garcia',31,13,'Dir. Ventas','1998-02-12',106,27500,7105),
(108,'Lorenzo Fernandez',31,11,'Rep. Ventas','1999-10-12',106,30000,58533),
(102,'Soledad Martinez',62,21,'Dir. Ventas','1999-10-12',108,30000,22776),
(101,'Daniel Gutierrez',48,21,'Rep. Ventas','1996-12-10',104,27500,26628),
(110,'Antonio Valle',45,12,'Rep. Ventas','1996-10-20',101,null,23123),
(103,'Pedro Cruz',41,null,'Rep. Ventas','2000-01-13',104,25000,2700),
(107,'Natalia Martin',29,12,'Rep. Ventas','1997-03-01',108,27500,34432);



select nombre,cuota,ventas
from repventas
where ventas < cuota and ventas < 300000;

select nombre,cuota,ventas
from repventas
where ventas < cuota or ventas < 300000;



select dir
from oficinas;

select distinct dir
from oficinas;

select Ciudad, region, ventas as'SUPERHABIT'
from oficinas;

select Ciudad, region, ventas
from oficinas
order by 3 desc;

select *
from oficinas;

select Ciudad, region ventas
from oficinas;

select *
from oficinas
where ventas > objetivo;

select empresa, Limitecredito
from clientes
where Limitecredito >= 40000;

select Nombre, Ventas, Cuota
from repventas
where Numempleado = 105;




select empresa, Limitecredito + 100 as 'NUEVO CREDITO'
from clientes;

select *
from productos
where precio in (79,107,55,25);

select *
from clientes
where Empresa like 'E%';

select *
from clientes
where Empresa like '_a%';

select distinct Fechapedido
from pedidos;

select oficina, ciudad, region, ventas
from oficinas
order by region asc, ciudad asc;

select nombre, ventas, cuota
from repventas
where Ventas not between (0.8 * Cuota) and (1.2 * Cuota);

select * 
from repventas
where Oficinarep in (11,13,22);

select *
from clientes where Empresa like 'A%';


select p.Pedido, p.Importe, c.Empresa, c.Limitecredito
from pedidos p, clientes c
where p.Clie = c.Numcliente;

select o.Oficina, o.Ciudad, r.Nombre as Director, r.Titulo, o.Objetivo
from oficinas o, repventas r
where o.Dir = r.Numempleado and o.Objetivo > 60000;

select p.Pedido, p.Importe, c.Empresa, r.Nombre
from pedidos p, clientes c, repventas r
where p.Clie = c.Numcliente and p.Rep = r.Numempleado and p.Importe > 25000;

select r.Nombre, o.Ciudad, o.Region
from repventas r, oficinas o
where r.Oficinarep = o.Oficina;

select p.Pedido, p.Importe, c.Empresa, c.Limitecredito
from pedidos p, clientes c
where p.Clie = c.Numcliente;








#1
SELECT
    r.Nombre,
    o.Ciudad,
    o.Region
FROM
    repventas AS r,
    oficinas AS o
WHERE
    r.Oficinarep = o.Oficina;

#2
SELECT
    p.Pedido,
    p.Importe,
    c.Empresa,
    c.Limitecredito
FROM
    pedidos AS p,
    clientes AS c
WHERE
    p.Clie = c.Numcliente;

#3
SELECT
    o.Oficina,
    o.Ciudad,
    r.Nombre AS Nombre_Director,
    r.Titulo
FROM
    oficinas AS o,
    repventas AS r
WHERE
    o.Dir = r.Numempleado
    AND r.Titulo LIKE 'Dir%';


