-- Seleccionar todos los clientes ordenados por nombre del cliente
SELECT * FROM dbo.Clientes ORDER BY NOM_CLIENTE

-- Seleccionar los clientes cuya localidad sea Madrid
SELECT * FROM dbo.Clientes WHERE LOC_CLIENTE = 'Madrid'

-- Seleccionar todos los clientes cuyo código postal pertenezca a la provincia de Sevilla
SELECT * FROM dbo.Clientes WHERE CP_CLIENTE LIKE '41%'

-- Seleccionar todos los clientes cuyo cósigo sea inferior a 10 o cuyo nombre de cliente comience por la letra A
SELECT * FROM dbo.Clientes WHERE COD_CLIENTE < 10 OR NOM_CLIENTE LIKE 'A%'

-- Contar cuántos clientes existen por cada localidad
SELECT LOC_CLIENTE,COUNT(*) FROM dbo.Clientes GROUP BY LOC_CLIENTE

-- Borrar los clientes cuyo nombre comience por la letra Z y termine por la letra Z
DELETE FROM dbo.Clientes WHERE NOM_CLIENTE LIKE 'Z%z'

-- Modificar el valor del código postal de los clientes cuya localidad sea Madrid con el valor 28001
UPDATE dbo.Clientes SET CP_CLIENTE = '28001' WHERE LOC_CLIENTE = 'Madrid'

-- Seleccionar los clientes cuyo importe de sus VENTAS sea distinto de cero
SELECT CL.COD_CLIENTE, CL.NOM_CLIENTE, CL.CP_CLIENTE, CL.LOC_CLIENTE FROM dbo.Clientes CL
JOIN dbo.Ventas VT ON CL.COD_CLIENTE = VT.COD_CLIENTE WHERE VT.IMPORTE != 0

-- Seleccionar todos los clientes junto con el importe de las ventas de cada uno.
SELECT CL.COD_CLIENTE, CL.NOM_CLIENTE, CL.CP_CLIENTE, CL.LOC_CLIENTE, VT.IMPORTE FROM dbo.Clientes CL
JOIN dbo.Ventas VT ON CL.COD_CLIENTE = VT.COD_CLIENTE

-- Modificar el importe de las ventas de los clientes a cero para aquellos clientes cuyo nombre contenga al menos una letra A.
UPDATE dbo.Ventas SET IMPORTE = 0 FROM dbo.Ventas VT INNER JOIN dbo.Clientes CL ON CL.COD_CLIENTE = VT.COD_CLIENTE WHERE CL.NOM_CLIENTE LIKE '%a%'