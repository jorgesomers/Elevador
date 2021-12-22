# Elevador

Projeto final do curso de C# Samsung Ocean

Requisitos:

**Métodos:**

***Inicializar*** : deve receber como parâmetros a capacidade do elevador e o total de
andares no prédio (os elevadores sempre começam no térreo e vazio);

***Entrar*** : deve acrescentar uma pessoa no elevador (só deve acrescentar se ainda houver
espaço);

***Sair*** : deve remover uma pessoa do elevador (só deve remover se houver alguém
dentro dele);

***Subir*** : deve subir um andar (não deve subir se já estiver no último andar);

***Descer*** : deve descer um andar (não deve descer se já estiver no térreo);

Realizado:

Criação de Predio com qtd de Andares, qtd de Elevadores e Capacidades.

Métodos - 
-> Id - identificação do elevador

-> Sobe - Elevador Sobe até limite qtd Andares

-> Desce - Elevador Desce até Zero

-> MaxOcup - ocupação maxima do elevador

-> MaxAndar - numero máximo de andares 

-> Embarcou - numero atual de ocupacao 

-> VcEmbarcou - se voce está no elevador

-> AndarAtual - metodo que retorna o andar atual e configura em qual andar está e nao deixa passar dos limites 

-> Acao(nAcao) - nAcao listada abaixo -

TipoAcao.SOBE;

TipoAcao.DESCE;

TipoAcao.VOCEENTRA;

TipoAcao.VOCESAI;

TipoAcao.VISITAENTRA;

TipoAcao.VISITASAI;

