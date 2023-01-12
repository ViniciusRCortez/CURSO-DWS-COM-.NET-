# CURSO-DWS-COM-.NET-
  Projeto para Avaliação do Curso Desenvolvimento de Web Services com .NET.

## Projeto Base:
  Como no Modulo I do PDF disponibilizado para o curso fala que poderiamos escolher entre algumas opções de versão do .NET para servir de API base para ser alterada nesse projeto atual, foi escolhida então a versão do .NET 6, que se encontra no seguinte diretório do repositório disponibilizado no curso: 
https://github.com/brunocastrohs/teaching/tree/main/backend_for_beginners/api-rest-net6.

## Melhorias Implementadas:
  Ao estudar as demais versões do projeto base, foi percebido que alguns recursos que estavam presentes em versões anteriores do .NET não estavam disponiveis na versão escolhida, portanto foi feita a implementação desses recursos, sua listagem se encontra abaixo:
- Criação do CRUD para a entidade Product, assim que foi gerado um CRUD básico para Product utilizando da classe ProductController.
- Para funcionamento do CRUD de Product, foram criadas as classes ProductService, ProductRepository, ProductResource e SaveProductResource. 
- Criação da lógica de autenticação através da classe User e do AuthenticationController, juntamente com suas respectivas dependências.

Além de atualizar para a versão atualizada algumas funcionalidades já existentes, foi também criadas novas funcionalidades, descritas na listagem abeixo:
- Mudança na forma de persistência de dados, pois ao invês de salvar os dados na memória os dados estão sendo persistidos em um banco de dados relacional SQLite, pois permite que sejam trabalhados com dados além dos populados e permite facil implementação em maquinas de terceiros, pois o SQLite não precisa de um servidor para rodar e qualquer computador pode rodar o codigo sem alterar configurações na string de conexão.
- Criados dois novos endpoints para Product, permitindo requisições de busca(Get) de Products alvo através do Id ou do Name.
- Criada a entidade Customer para servir de base de dados sobre as informações dos clientes de algum empreendimento que consumir nossa API
- Gerado um CRUD básico para Customers, através do CustomersController e seus dependências de Service, Repository e etc.
- Além dos endpoints para buscar(Get) em todos os Customers e endpoints para requisições básicas de um CRUD, foi implementado endpoints para requisições de busca(Get) das informações de um Customer alvo através do Id, do Name e uma filtragem com base em Credit positivo ou negativo. 


## Testes Feitos:
Os teste feitos para nossa API foram utilizando o software Postman, onde nele foram feitas as requisições para cada um dos endpoints e programados alguns testes automatizados para verificar a funcionalidade da API, através do Postman, foram exportas os json com a coleção de teste(Collection) e os resultados dos testes(TestRun), além de dois prints de tela evidenciando que a API foi submetida a 60 testes e passou por todos.
