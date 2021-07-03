<h1>Cadastro de Séries e Filmes</h1>

<h2>Exercício em C# para prática de Orientação a Objetos</h2>

Este programa foi desenvolvido em aula proporcionada pela Digital Innovation One, através do desenvolvedor Eliézer Zarpelão.

Seguem os acréscimos em relação ao desenvolvido em aula e eventuais desafios encontrados:

- criação de método para eliminar código repetido utilizado para incluir e alterar objeto:

  para isso criei o método "preencherCampos". Esse método retorna o objeto a incluir ou atualizar e por isso coloquei ele como parâmetro dos métodos chamados: 

  - repositorioSerie.Insere(preencherCampos(-1));

  - repositorioSerie.Atualiza(indiceSerie, preencherCampos(indiceSerie));

  Este método exige um parâmetro que é utilizado para saber qual série atualizar ou, quando "-1", criar. Através de um operador ternário gera o objeto a retornar. Se "-1" passa como parâmetro do construtor de new Serie o id: repositorioSerie.Proximo(), que cria o novo objeto ou então o "indiceSerie" para o objeto a ser atualizado. Desta forma foi possível inclusive aproveitar o código da parte de criação do objeto.

  

- Correção do método AtualizarSerie() para exibir "Nenhuma série cadastrada.", no caso da lista estar vazia.-  

- Colocação de todos os métodos que haviam sido criados para a Classe Serie dentro da EntidadeBase, para poderem ser herdados por nova classe chamada Filme

- Inclusão da opção inicial de navegar entre FILMES e SÉRIES, com passagem de opção na assinatura do método, aproveitando os mesmos métodos na sequência, apenas selecionando sempre entre a opção FILME ou SÉRIE.

- Alteração dos métodos para representar de forma genérica Séries ou Filmes. Exemplo, inserirSerie() para Inserir();

- Correção de alguns dos "bugs" para evitar parada do programa por digitação não permitida;

Obs.: Ainda é possível melhorar/refatorar o programa em vários pontos, mas creio que já atendeu aos objetivos de demonstrar o entendimento das características básicas de Orientação a Objetos, assinatura de métodos, passagem de parâmetros, Interfaces, Classes Abstratas, etc., proposta pela aula. Simplificaria muito, por exemplo, acrescentar apenas um atributo ao objeto para diferenciar de Serie e Filme.
