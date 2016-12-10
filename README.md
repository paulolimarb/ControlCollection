# ControlCollection
* Api para gestão de coleções utilizando o elasticsearch como base de dados.

* Abaixo o código para a criação do "indice" e do "tipo" no elasticsearch

* /basecollection/ <- nome do indice/base de dados

"settings": {
    "index": {
      "number_of_shards": 3,
      "number_of_replicas": 0 
    }
}

* Como a instalação é feita em uma maquina local não é possível gerar réplicas.

* /contact/ <- nome do "tipo/tabela" para armazenar os contatos
* /itemcollection/ <- nome do "tipo/tabela" para armazenar os itens da coleção

* Para inversão de controle e injeção de dependência está sendo utilizado o Framework - Simple Injector

* Os arquivos HTML estão na pasta "content"
