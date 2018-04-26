Desenvolvimento de projeto voltado para análise de custos e controle de estoque na produção de alimentos. Trabalho voltado principalmente para aprendizado.

A ideia inicial do sistema é a seguinte, muitas pessoas produzem alimentos em casa, ou até mesmo em pequenas empresas, porém não sabem exatamente quanto tem de custo cada produto não tendo uma base lógica para precificação. Por exemplo: uma confeitera que faz bolos para aniversários como renda extra.

O sistema funcionára da seguinte forma:

1 - Cadastro de insumos: o ponto inicial é cadastrar os insumos utilizados para produção de determinado alimento e sua unidade de medida, hipotéticamente vamos imaginar que para fazer um bolo seja necessário apenas: ovos, farinha de trigo e fermento. Então inicialmente vai ser cadastrado esses ingredientes e suas unidades de medida, independente de quantidade, e já ficarão salvos no sistema não havendo necessidade de novo cadastro mesmo que seja para produção de outro alimento no futuro. Esboço exemplo:
 _____________________________________________________ 
| Nome do insumo: Farinha de trigo                    |
| Unidade medida: Quilos (kg)                         |
|_____________________________________________________|

2 - Cadastrar produto: agora o objetivo é cadastrar o produto que será produzido, continuando o exemplo anterior, vamos cadastrar o bolo propriamente dito. Nessa fase, além de cadastrar o bolo, cadastramos também a composição dele, ou seja, supondo que para fazer um bolo de 1/2kg seja necessário 3 ovos, 450g de farinha e 10g de fermento, então iremos colocar essas quantias dentro do cadastro do produto. Esboço exemplo:
 _____________________________________________________ 
| Nome do produto: Bolo                               |
| Unidade medida: Quilos (kg)                         |
| Insumos necessários para produzir 1 kg: 6 un de Ovo |
| 0,9 kg de Farinha de Trigo                          |
| 0,02 kg de Fermento                                 |
|_____________________________________________________|
Obs: observar que no exemplo coloquei medidas para um bolo de 500g, porém como a unidade de medida do bolo é em kg, no cadatro preenchi o necessário para produção de 1 unidade de medida, que no caso do bolo é kg.

3 - Entrada em estoque: após feito os cadastros iniciais, é o momento que incluir insumos e produtos em estoque para começar o controle de custos e de estoque. Portanto, vamos inserir uma entrada de insumos no sistema, a quantidade total que está entrando em estoque e o valor total que custou esses insumos. Esboço exemplo:
 _____________________________________________________ 
| Nome do insumo: Farinha de trigo                    |
| Quantidade em kg: 5                                 |
| Valor total em R$: 10,00                            |
|_____________________________________________________|
Obs: atraves do valor e quantidade, o sistema vai identificar qual o valor do unitário do insumo para depois calcular o custo de determinado produto.

4 - Produção: depois de dar entrada nos insumos necessários para produção, é a hora da produção. Vamos selecionar qual o produto vamos produzir, no nosso exemplo, o bolo e qual a quantidade de bolo que vamos produzir. O sistema irá validar se existe a quantidade de insumos suficiente em estoque para a produção. Se houver quantidade suficiente em estoque, o sistema vai calular o custo dos produtos de acordo com as entradas de insumos no estoque, vaii baixar o estoque de insumos, e vai aumentar o estoque de produtos. Esboço exemplo:
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
| Custo total da produção: R$ 8,39                    |
|_____________________________________________________| 

5 - Venda: agora que já teremos um produto pronto, resta apenas a venda. Será escolhido o produto para venda e a quantidade, o sistema vai validar se há quantidade suficiente em estoque, vai baixar e retornar o lucro ou prejuízo. Esbolo exemplo:
 _____________________________________________________ 
| ENTRADA DE DADOS                                    |
| Nome do produto: Bolo                               |
| Quantidade a ser vendida em kg: 1 kg                |
| Valor da venda: R$ 15,00                            |
|_____________________________________________________|
| RETORNO DO SISTEMA                                  |
| Valor da venda: R$ 15,00                            |
| Custo de produção: R$ 4,20                          |
| Lucro: R$ 10,80                                     |
|_____________________________________________________|

6 - Além destas funções, o sistema também disponibilizará relatórios de entrada e saída de produtos e insumos, de vendas e de produção.

O projeto será desenvolvido onas minhas horas vagas para meu aprendizado na linguagem de C#. Aceito sugestões para melhorias e dicas.

Marcelo Henrique Cezário