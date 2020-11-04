
Create procedure buscarTodasAsCompras as
	Select c.nomeComprador as 'Nome Completo', c.cpf as 'CPF', 
		c.dataCompra as 'Data da Compra', v.modelo as 'Modelo', 
		v.ano as 'Ano', c.placa as 'Placa', v.valor as 'Valor'
		from compra as c join veiculos as v on v.id = c.idVeiculo 


Create procedure buscarCompraByCpf(@cpf varchar(11))as
	Select c.cpf as 'CPF',c.nomeComprador as 'Nome Completo', 
		c.dataCompra as 'Data da Compra', v.modelo as 'Modelo', 
		v.ano as 'Ano', c.placa as 'Placa', v.valor as 'Valor' 
		from compra as c join veiculos as v on v.id = c.idVeiculo 
		where c.cpf = @cpf;

Create procedure buscarCompraByPlaca(@placa varchar(7))as
	Select c.placa as 'Placa',c.nomeComprador as 'Nome Completo', c.cpf as 'CPF', c.dataCompra as 'Data da Compra', v.modelo as 'Modelo', 
		v.ano as 'Ano', v.valor  as 'Valor' 
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
