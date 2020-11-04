
Create procedure buscarTodasAsCompras as
	Select c.idCompra,c.nomeComprador, c.cpf, c.dataCompra, v.modelo, v.ano, c.placa, v.valor 
		from compra as c join veiculos as v on v.id = c.idVeiculo 


Create procedure buscarCompraByCpf(@cpf varchar(11))as
	Select c.cpf,c.nomeComprador, c.dataCompra, v.modelo, v.ano, c.placa, v.valor 
		from compra as c join veiculos as v on v.id = c.idVeiculo 
		where c.cpf = @cpf;

Create procedure buscarCompraByPlaca(@placa varchar(7))as
	Select c.placa,c.nomeComprador, c.cpf, c.dataCompra, v.modelo, v.ano, v.valor 
		from compra as c join veiculos as v on v.id = c.idVeiculo 
		where c.placa like '%'+@placa+'%';

Create procedure buscarTodosOsVeiculos as 
	Select * from veiculos;

Create procedure realizarCompra(@nome varchar(45) ,@cpf varchar(11) , @placa varchar(7), @idVeiculo as int) as 
	INSERT into compra values (@idVeiculo, @cpf, @nome, getdate(),@placa)

Create procedure buscarVeiculoPorId(@id integer) as
	Select * from veiculos where id = @id

exec buscarTodosOsVeiculos;
exec buscarTodasAsCompras
exec buscarCompraByCpf '10604622551'
exec buscarCompraByPlaca 'gtx3080'
