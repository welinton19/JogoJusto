#language: pt

Funcionalidade: Meta

Com o login de um Admin na plataforma jogojusto,
o admin tem a capacidade de criar metas para as empresas cadastradas,
com o objetivo de promover práticas sustentáveis e responsáveis no contexto ESG.

Contexto:
    Dado que o administrador está autenticado com email "isabella@example.com" e password "SenhaForte123"

@CriarMeta
Cenario: Cadastrar nova meta para empresa com sucesso
    Quando ele envia uma requisição POST para criar "/api/metaesg" com o seguinte payload:
        | tipoMetaEsg         | descricaoMetaEsg                               | valorReferenciaMetaEsg | valorAtualMetaEsg | prazoMetaEsg | empresaId |
        | Redução de Emissões | Reduzir as emissões de carbono em 20% até 2025 | 20                   | 0                | 2026-12-31T00:00:00.000Z     | 2         |
    Então ele deve receber uma resposta com status code 200
    E o corpo da resposta deve conter a mensagem "Meta ESG criada com sucesso"

@ListarMetas
Cenario: Listar metas cadastradas com sucesso
    Quando ele envia uma requisição GET para listarS "/api/metaesg"
    Então ele deve receber uma resposta com status code 200
    E o corpo da resposta deve conter a lista de metas cadastradas

@AtualizarMeta
Cenario: Atualizar meta existente com sucesso
    Quando ele envia uma requisição PUT para  "/api/metaesg/6" com o seguinte payload:
        | tipoMetaEsg         | descricaoMetaEsg                               | valorAtualMetaEsg | prazoMetaEsg             | empresaId |
        | Redução de Emissões | Reduzir as emissões de carbono em 25% até 2025 | 25                | 2026-12-31T00:00:00.000Z | 2         |
    Então ele deve receber uma resposta com status code 200
    E o corpo da resposta deve conter a mensagem "Meta ESG atualizada com sucesso."

@PesquisarMetaPorID
Cenario: Pesquisar meta existente por ID
    Então ele envia uma requisição GET para obter por ID "/api/metaesg/2"
    Então ele deve receber uma resposta com status code 200
    E o corpo da resposta deve conter os detalhes da meta com ID 2

@DeletarMeta
Cenario: Deletar meta existente com sucesso
    Então ele deve enviara uma requisição DELETE para "/api/metaesg/2"
    Então ele deve receber uma resposta com status code 200
    E o corpo da resposta deve conter a mensagem "Meta ESG excluída com sucesso."
