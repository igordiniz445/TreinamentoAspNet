
Create procedure buscarTodasAsCompras as
	Select c.idCompra,c.nomeComprador, c.cpf, c.dataCompra, v.modelo, v.ano, c.placa, v.valor 
		from compra as c join veiculos as v on v.id = c.idVeiculo 


Create procedure buscarCompraByCpf(@cpf varchar(11))as
	Select c.idCompra,c.nomeComprador, c.cpf, c.dataCompra, v.modelo, v.ano, c.placa, v.valor 
		from compra as c join veiculos as v on v.id = c.idVeiculo 
		where c.cpf = @cpf;

Create procedure buscarCompraByPlaca(@placa varchar(7))as
	Select c.idCompra,c.nomeComprador, c.cpf, c.dataCompra, v.modelo, v.ano, c.placa, v.valor 
		from compra as c join veiculos as v on v.id = c.idVeiculo 
		where c.placa = @placa;

Create procedure buscarTodosOsVeiculos as 
	Select * from veiculos;

Create procedure realizarCompra(@nome varchar(45) ,@cpf varchar(11) , @placa varchar(7), @idVeiculo as int) as 
	INSERT into compra values (@idVeiculo, @cpf, @nome, getdate(),@placa)

exec buscarTodosOsVeiculos;
exec buscarTodasAsCompras
exec buscarCompraByCpf '10604622551'
exec buscarCompraByPlaca 'gtx3080'