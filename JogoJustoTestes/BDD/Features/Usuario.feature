#language: pt

Funcionalidade: Usuario

Criar um novo usuario 

@TesteCriarUsuarioValido
Cenario: Criar um novo usuário com dados válidos
    Dado que o usuário tem dados válidos
    Quando enviar os dados para criar um novo usuário
    Então deve receber status 200 Usuário criado com sucesso.

@TesteCriarUsuarioInvalido
Cenario: Criar  usuário com dados inválidos
    Dado que o usuário tem dados inválidos
    Quando enviar os dados para criar um novo usuário
    Então deve receber status 500 usuário já existente ou dados inválidos



 