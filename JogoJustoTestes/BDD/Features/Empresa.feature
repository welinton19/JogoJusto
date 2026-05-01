# language: pt

Funcionalidade: Gerenciamento de Empresas
Como administrador da plataforma JogoJusto
Quero gerenciar empresas cadastradas
Para garantir a integridade dos dados organizacionais no contexto ESG

Contexto: 
Dado que o administrador está autenticado com email "isabella@example.com" e password "SenhaForte123"

@CadastrarEmpresa
Cenario: Cadastrar nova empresa com sucesso
Quando ele envia uma requisição POST para "/api/empresa" com o seguinte payload:
	| nome         | cnpj           | endereco         |
	| Empresa XYZ   | 12.345.678/0001-90 | Rua Exemplo, 123 |
	Entao ele deve receber uma resposta com status code 200
	E o corpo da resposta deve conter a mensagem "Empresa criada com sucesso."

@ListarEmpresas
Cenario: Listar todas as empresas com sucesso
Quando ele envia uma requisição GET para "/api/empresa"
	Entao ele deve receber uma resposta com status code 200
	E a resposta deve conter uma lista de empresas

@BuscarEmpresaPorID
Cenario: Buscar empresa existente por ID
Quando ele envia uma requisição GET para "/api/empresa/1"
	Entao ele deve receber uma resposta com status code 200
	E o corpo da resposta deve conter o campo "empresaId"

@BuscarEmpresaInexistente
Cenario: Buscar empresa inexistente por ID
Quando ele envia uma requisição GET para "/api/empresa/999"
	Entao ele deve receber uma resposta com status code 404
	E o corpo da resposta deve conter a mensagem "Empresa não encontrada."


