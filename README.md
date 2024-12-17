Examen Final de POO2
Script utilizado para la base de datos
use Negocios2018

select * from tb_categorias

insert into tb_categorias values (9, 'Electricas', 'Taladros, Rotomartillo')
insert into tb_categorias values (10, 'Manuales', 'Destornilladores, Martillos')
insert into tb_categorias values (11, 'Cascos', 'Cascos')
insert into tb_categorias values (12, 'Guantes', 'Guantes')
insert into tb_categorias values (13, 'Cajas', 'Cajas de herramientas')

CREATE TABLE tb_herramienta ( 
	idHer VARCHAR(7) PRIMARY KEY, 
	desHer VARCHAR(100), 
	medHer VARCHAR(50), 
	idcategoria INT, 
	preUni DECIMAL(10,2), 
	stock INT, 
	FOREIGN KEY (idcategoria) REFERENCES tb_categorias(idcategoria) 
)

//Se utilizo copilot para la creacion masiva de datos
INSERT INTO tb_herramienta (idHer, desHer, medHer, idcategoria, preUni, stock) VALUES
('H001', 'Martillo de carpintero', '500g', 10, 12.50, 100), 
('H002', 'Destornillador Phillips', '15cm', 9, 3.75, 200), 
('H003', 'Llave inglesa', '10"', 10, 8.40, 150), 
('H004', 'Alicate de corte', '6"', 10, 5.60, 120), 
('H005', 'Sierra manual', '20cm', 10, 7.20, 80), 
('H006', 'Taladro eléctrico', '500W', 9, 45.00, 50), 
('H007', 'Cinta métrica', '5m', 10, 4.30, 300), 
('H008', 'Casco Naranja', 'M', 11, 6.25, 100), 
('H009', 'Lijadora orbital', '200W', 9, 38.50, 60), 
('H010', 'Cortaúñas grande', '12cm', 10, 2.10, 500), 
('H011', 'Pistola de silicona', '150W', 9, 12.00, 90), 
('H012', 'Soplete de gas', '1000°C', 9, 25.00, 75), 
('H013', 'Juego de llaves Allen', '9 piezas', 10, 14.70, 120), 
('H014', 'Caja de herramientas', '20"', 13, 35.00, 40), 
('H015', 'Brocha de pintura', '2"', 10, 3.50, 250), 
('H016', 'Cincel de madera', '8"', 10, 7.00, 80), 
('H017', 'Gramil', '20cm', 9, 10.00, 60), 
('H018', 'Sargento de apriete', '50cm', 10, 11.50, 100), 
('H019', 'Guantes de trabajo', 'Talla L', 11, 5.00, 200), 
('H020', 'Casco Amarillo', 'L', 12, 20, 1000)
GO

create or alter proc usp_herramientas
AS
select * from tb_herramienta
go

create or alter proc usp_categoria
as
select IdCategoria, NombreCategoria from tb_categorias
go

create or alter proc usp_buscar_herramienta
@idher varchar(5)
as
select top 1 *
from tb_herramienta
where idHer = @idher
go

create or alter proc usp_Merge_Herramienta
@id VARCHAR(7), 
@desc VARCHAR(100), 
@med VARCHAR(50), 
@idcategoria INT, 
@preUni DECIMAL(10,2), 
@stock INT
as
merge tb_herramienta as target
using(select @id, @desc, @med, @idcategoria, @preUni, @stock) as source(id, descripcion, med, idcategoria, preuni, stock)
on target.idHer = source.id
when MATCHED then
	UPDATE set target.desHer = source.descripcion, target.medHer = source.med, target.idCategoria = source.idcategoria,
	target.preUni = source.preuni, target.stock = source.stock
when NOT MATCHED then
	insert values (source.id, source.descripcion, source.med, source.idcategoria, source.preuni, source.stock);
go

create or alter proc usp_eliminar_herramienta
@idher varchar(7)
as
delete tb_herramienta
where idHer = @idher
go

exec usp_eliminar_herramienta H001
