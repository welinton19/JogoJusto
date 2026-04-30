#language: pt

Funcionalidade: Login

Entra na aplicação com login

@TesteLoginValido
Cenario: Verificar se login válido
    Dado que o usuário tem um login válido
    Quando enviar Email e Senha corretos
    Então deve receber status 200 de login com sucesso

	
@TesteLoginInvalido
Cenario: Verificar se login inválido
    Dado que o usuário tem um login inválido
    Quando enviar Email e Senha incorretos
    Então deve receber status 401 erro de login