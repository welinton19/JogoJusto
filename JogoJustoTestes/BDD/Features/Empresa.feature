#language: pt

Funcionalidade: Empresa
Como administrador da plataforma JogoJusto
Quero gerenciar empresas cadastradas
Para garantir a integridade dos dados organizacionais no contexto ESG

Contexto: 
Given que o administrador está autenticado com email "admin@jogojusto.com.br" e senha "admin123"

Cenário: Listar todas as empresas com sucesso
Quando ele envia uma requisição GET para "/api/empresa"
	Então ele deve receber uma resposta com status code 200
	E a resposta deve conter uma lista de empresas

Cenário: Buscar empresa existente por ID
Quando ele envia uma requisição GET para "/api/empresa/1"
	Então ele deve receber uma resposta com status code 200
	E o corpo da resposta deve conter o campo "empresaId"

Cenário: Buscar empresa inexistente por ID
Quando ele envia uma requisição GET para "/api/empresa/999"
	Então ele deve receber uma resposta com status code 404
	E o corpo da resposta deve conter a mensagem "Empresa não encontrada"


