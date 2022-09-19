Aplicativo de referência de exemplo de microsserviços .NET Aplicativo de referência .NET Core de exemplo, original documentação Microsoft, baseado em uma arquitetura simplificada de microsserviços e contêineres Docker.
Segurança: oauth2, openConectID, Microsoft.IdentityServer. Fila RabbitMQ e GatwayAPI.
Ref:  Arquitetura de microsserviços com ASP.NET, .NET 'Core' 6, Oauth2, OpenID, Identity Server, RabbitMQ, Ocelot, C# com Leandro Costa Udemy;

Lembrando: O foco é MICROSERVIÇOS


![image](https://user-images.githubusercontent.com/22334765/189756861-d6500026-db21-42ec-ae92-d8219130ff19.png)

Build Status (GitHub Actions)

![image](https://user-images.githubusercontent.com/22334765/189757584-3b892478-df82-4d3b-929c-b2a16b4b660f.png)

Visão geral da arquitetura
Esse aplicativo de referência é multiplataforma no lado do servidor e do cliente, graças aos serviços .NET 6 capazes de executar em contêineres Linux ou Windows, dependendo do seu host Docker, e ao Xamarin para aplicativos móveis executados em Android, iOS ou Windows/ UWP mais qualquer navegador para os aplicativos da Web do cliente. A arquitetura propõe uma implementação de arquitetura orientada a microsserviços com múltiplos microsserviços autônomos (cada um possuindo seus próprios dados/db) e implementando diferentes abordagens dentro de cada microsserviço (padrões simples CRUD vs. DDD/CQRS) usando HTTP como protocolo de comunicação entre os aplicativos cliente e os microsserviços e suporta comunicação assíncrona para propagação de atualizações de dados em vários serviços com base em eventos de integração e um barramento de eventos (um agente de mensagens leve, para escolher entre RabbitMQ ou Azure Service Bus,roteiro .

![image](https://user-images.githubusercontent.com/22334765/189757787-db4aa01b-7ea4-4fab-a990-5edfa54a5f40.png)

Documentação e orientação relacionadas
Você pode encontrar o Guia/eBook de referência relacionado com foco na arquitetura e desenvolvimento de aplicativos .NET em contêineres e baseados em microsserviços (link para download disponível abaixo), que explica em detalhes como desenvolver esse tipo de estilo de arquitetura (microsserviços, contêineres Docker, design orientado a domínio para determinados microsserviços) além de outros estilos de arquitetura mais simples, como aplicativos monolíticos que também podem viver como contêineres do Docker.

Há também eBooks adicionais com foco no ciclo de vida de Containers/Docker (DevOps, CI/CD, etc.) com Microsoft Tools, já publicados, além de um eBook adicional com foco em padrões de aplicativos corporativos com Xamarin.Forms. Você pode baixá-los e começar a revisar esses Guias/eBooks aqui:
![image](https://user-images.githubusercontent.com/22334765/189757931-a6cb12a8-a506-4a32-aefd-340acf30e40e.png)
Para mais e-books gratuitos, confira o centro de arquitetura .NET . Se você tiver um feedback de e-book, informe-nos criando um novo problema aqui: https://github.com/dotnet-architecture/ebooks/issues

Você é novo em microsserviços e desenvolvimento nativo da nuvem ?
Dê uma olhada no curso gratuito Criar e implantar um microsserviço ASP.NET Core nativo da nuvem no MS Learn. Este módulo explica conceitos de microsserviços, tecnologias nativas da nuvem e reduz o atrito na introdução ao eShopOnContainers.
