select i.categoria, Count(p.cod_impuesto) as Cantidad_de_importacion, 
Sum((convert(float,s.comision)* p.costo) + 
(convert(float,s.costo_lb)* p.libras)) as Ganancias
from ProyectoIPC2.dbo.Impuestos i, ProyectoIPC2.dbo.Paquetes p, ProyectoIPC2.dbo.Sucursales s, ProyectoIPC2.dbo.Facturas f 
where f.cod_paquete=p.cod_paquete and i.cod_impuesto=p.cod_impuesto and s.cod_sucursal = 1 
group by i.categoria order by Count(p.cod_impuesto) desc;
