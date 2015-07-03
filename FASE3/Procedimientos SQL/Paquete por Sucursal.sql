Select s.nombre, count(p.cod_paquete) as Recibidos, 
sum(case when p.estado = 'Perdido' then 1 else 0 end) as Perdidos,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') then 1 else 0 end) as Entregados,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') 
then ((Convert(float,p.costo) * Convert(float,i.porcentaje))) 
else 0 end) as Impuestos,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') 
then ((Convert(float,p.libras)* Convert(float,s.costo_lb))) 
else 0 end) as Costo_Libra,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') 
then ((Convert(float,p.costo)* Convert(float, s.comision))) 
else 0 end) as Comisiones
from ProyectoIPC2.dbo.Paquetes p, ProyectoIPC2.dbo.Impuestos i, ProyectoIPC2.dbo.Lotes l, ProyectoIPC2.dbo.Sucursales s
where p.cod_impuesto=i.cod_impuesto and p.cod_lote=l.cod_lote and l.cod_sucursal= s.cod_sucursal  group by s.nombre; 
