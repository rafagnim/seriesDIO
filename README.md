<h1>Cadastro de Séries</h1>

<h2>Exercício em C# para prática de Orientação a Objetos</h2>

Este programa foi desenvolvido em aula proporcionada pela Digital Innovation One, através do desenvolvedor Eliézer Zarpelão.

Seguem os acréscimos em relação ao desenvolvido em aula e eventuais desafios encontrados:

- criação de método para eliminar código repetido utilizado para incluir e alterar objeto:

  para isso criei o método "preencherCampos". Esse método retorna o objeto a incluir ou atualizar e por isso coloquei ele como parâmetro dos métodos chamados: 

  - repositorio.Insere(preencherCampos(-1));

  - repositorio.Atualiza(indiceSerie, preencherCampos(indiceSerie));

  Este método exige um parâmetro que é utilizado para saber qual série atualizar ou quando "-1" criar. Através de um operador ternário gera o objeto a retornar. Se "-1" passa como parâmetro do construtor de new Serie o id: repositorio.Proximo(), que cria o novo objeto ou então o "indiceSerie" para o objeto a ser atualizado. Desta forma foi possível inclusive aproveitar o código da parte de criação do objeto.

- 
