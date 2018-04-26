Desenvolvimento de projeto voltado para an�lise de custos e controle de estoque na produ��o de alimentos. Trabalho voltado principalmente para aprendizado.

A ideia inicial do sistema � a seguinte, muitas pessoas produzem alimentos em casa, ou at� mesmo em pequenas empresas, por�m n�o sabem exatamente quanto tem de custo cada produto n�o tendo uma base l�gica para precifica��o. Por exemplo: uma confeitera que faz bolos para anivers�rios como renda extra.

O sistema funcion�ra da seguinte forma:

1 - Cadastro de insumos: o ponto inicial � cadastrar os insumos utilizados para produ��o de determinado alimento e sua unidade de medida, hipot�ticamente vamos imaginar que para fazer um bolo seja necess�rio apenas: ovos, farinha de trigo e fermento. Ent�o inicialmente vai ser cadastrado esses ingredientes e suas unidades de medida, independente de quantidade, e j� ficar�o salvos no sistema n�o havendo necessidade de novo cadastro mesmo que seja para produ��o de outro alimento no futuro. Esbo�o exemplo:
 _____________________________________________________ 
| Nome do insumo: Farinha de trigo                    |
| Unidade medida: Quilos (kg)                         |
|_____________________________________________________|

2 - Cadastrar produto: agora o objetivo � cadastrar o produto que ser� produzido, continuando o exemplo anterior, vamos cadastrar o bolo propriamente dito. Nessa fase, al�m de cadastrar o bolo, cadastramos tamb�m a composi��o dele, ou seja, supondo que para fazer um bolo de 1/2kg seja necess�rio 3 ovos, 450g de farinha e 10g de fermento, ent�o iremos colocar essas quantias dentro do cadastro do produto. Esbo�o exemplo:
 _____________________________________________________ 
| Nome do produto: Bolo                               |
| Unidade medida: Quilos (kg)                         |
| Insumos necess�rios para produzir 1 kg: 6 un de Ovo |
| 0,9 kg de Farinha de Trigo                          |
| 0,02 kg de Fermento                                 |
|_____________________________________________________|
Obs: observar que no exemplo coloquei medidas para um bolo de 500g, por�m como a unidade de medida do bolo � em kg, no cadatro preenchi o necess�rio para produ��o de 1 unidade de medida, que no caso do bolo � kg.

3 - Entrada em estoque: ap�s feito os cadastros iniciais, � o momento que incluir insumos e produtos em estoque para come�ar o controle de custos e de estoque. Portanto, vamos inserir uma entrada de insumos no sistema, a quantidade total que est� entrando em estoque e o valor total que custou esses insumos. Esbo�o exemplo:
 _____________________________________________________ 
| Nome do insumo: Farinha de trigo                    |
| Quantidade em kg: 5                                 |
| Valor total em R$: 10,00                            |
|_____________________________________________________|
Obs: atraves do valor e quantidade, o sistema vai identificar qual o valor do unit�rio do insumo para depois calcular o custo de determinado produto.

4 - Produ��o: depois de dar entrada nos insumos necess�rios para produ��o, � a hora da produ��o. Vamos selecionar qual o produto vamos produzir, no nosso exemplo, o bolo e qual a quantidade de bolo que vamos produzir. O sistema ir� validar se existe a quantidade de insumos suficiente em estoque para a produ��o. Se houver quantidade suficiente em estoque, o sistema vai calular o custo dos produtos de acordo com as entradas de insumos no estoque, vaii baixar o estoque de insumos, e vai aumentar o estoque de produtos. Esbo�o exemplo:
 _____________________________________________________ 
| ENTRADA DE DADOS                                    |
| Nome do produto: Bolo                               |
| Quantidade a ser produzida em kg: 2                 |
|_____________________________________________________|
| RETORNO DO SISTEMA                                  |
| Farinha de trigo: 1,8 kg - R$ 4,00                  |
| Ovos: 12 un - R$ 4,00                               |
| Fermento: 0,04 kg - R$ 0,39                         |
|                                                     |
| Custo total da produ��o: R$ 8,39                    |
|_____________________________________________________| 

5 - Venda: agora que j� teremos um produto pronto, resta apenas a venda. Ser� escolhido o produto para venda e a quantidade, o sistema vai validar se h� quantidade suficiente em estoque, vai baixar e retornar o lucro ou preju�zo. Esbolo exemplo:
 _____________________________________________________ 
| ENTRADA DE DADOS                                    |
| Nome do produto: Bolo                               |
| Quantidade a ser vendida em kg: 1 kg                |
| Valor da venda: R$ 15,00                            |
|_____________________________________________________|
| RETORNO DO SISTEMA                                  |
| Valor da venda: R$ 15,00                            |
| Custo de produ��o: R$ 4,20                          |
| Lucro: R$ 10,80                                     |
|_____________________________________________________|

6 - Al�m destas fun��es, o sistema tamb�m disponibilizar� relat�rios de entrada e sa�da de produtos e insumos, de vendas e de produ��o.

O projeto ser� desenvolvido onas minhas horas vagas para meu aprendizado na linguagem de C#. Aceito sugest�es para melhorias e dicas.

Marcelo Henrique Cez�rio