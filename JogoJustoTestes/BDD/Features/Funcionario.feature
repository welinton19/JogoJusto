# language: pt

Funcionalidade: Gerenciamento de Funcionários
Como departamento de recursos humanos de uma empresa, 
quero gerenciar os funcionários cadastrados para garantir 
a diversidade e inclusão nos departamentos.

Contexto: 
Dado que o administrador está autenticado com email "isabella@example.com" e password "SenhaForte123"

@CadastrarFuncionario
Cenario: Cadastrar novo funcionário com sucesso
Quando ele envia uma requisição POST para "/api/funcionario" com os dados do funcionário:
		| nome              | cargo    | departamentoId | genero   | raca  | cpf            | dataNascimento | dataContratacao |		
		| Silvana Barros    | Analista |              4 | Feminino | Parda | 457.646.900-28 | 1990-05-15     | 2026-05-02      |
	Entao ele deve receber uma resposta com status code 200 para funcionario
	E o corpo da resposta do funcionario deve conter a mensagem "Funcionário criado com sucesso."

@ListarFuncionarios
Cenario: Listar todos os funcionários com sucesso
	Quando ele solicita a lista de funcionários cadastrados enviando uma requisição GET para "/api/funcionario"
	Entao a resposta deve conter uma lista de funcionários
	

@BuscarFuncionarioPorID
Cenario: Buscar funcionário existente por ID
	Quando ele envia uma requisição GET para "/api/funcionario/2" para buscar um funcionário existente por ID
	Entao ele deve receber uma resposta com status code 200 para funcionario
	E o corpo da resposta do funcionario deve conter o campo "funcionarioId"

@BuscarFuncionarioInexistente
Cenario: Buscar funcionário inexistente por ID
	Quando ele envia uma requisição GET para "/api/funcionario/25" para buscar um funcionário inexistente por ID
	Entao ele deve receber uma resposta com status code 404
	E o corpo da resposta deve conter a mensagem "Funcionário não encontrado."







